using System;
using System.Collections.Generic;
using System.Linq;
using aaasm.engine.col;
using aaasm.engine.io;

namespace aaasm.engine.lxpr
{
    internal partial class Lex1
    {
        #region helper methods

        private static bool MM__PreCmd_ConsiderCond(Handler handler, bool elif)
        {
            if (!elif) return handler.If.Active == handler.If.Level;
            return (handler.If.Active + 1) == handler.If.Level && (!handler.If.Met);
        }

        private static Expr MM__PreCmd_GetExpression(Handler handler, string expect)
        {
            // Check input count
            if (handler.Input.Current.Length == 1)
                throw new BadSrcException($"Expected a {expect}", handler.Input.Current[0].RefPnt);
            // Parse input as expression
            var tokens = MM_Analyze(handler, MM_ExpandMacros(handler, 1, null, out _));
            return Expr.Analyze(tokens, handler.Rules.Expression,
                failRefPnt: handler.Input.Current[0].RefPnt);
        }

        private static string MM__PreCmd_GetMacroName(Handler handler, bool allowAdditionalArgs = false)
        {
            if (!allowAdditionalArgs) MM__PreCmd_ThrowIfTooManyArgs(handler, 2);
            if (handler.Input.Current.Length > 1) return (string)handler.Input.Current[1].RawData.Raw;
            throw new BadSrcException("Expected a macro name", handler.Input.Current[0].RefPnt);
        }

        private static void MM__PreCmd_ThrowIfTooManyArgs(Handler handler, int max)
        {
            if (handler.Input.Current.Length <= max) return;
            var token = handler.Input.Current[max];
            throw BadSrcException.Unexpected(token.RawData, token.RefPnt);
        }

        private static void MM__PreCmd_ThrowIfNotInIfBlock(Handler handler)
        {
            if (handler.If.Level > 0) return;
            throw BadSrcException.Unexpected(
                handler.Input.Current[0].RawData, 
                refPnt: handler.Input.Current[0].RefPnt);
        }

        private static void MM__PreCmd_If(Handler handler, Action<bool> action, bool elif)
        {
            if (MM__PreCmd_ConsiderCond(handler, elif))
            {
                var exprResult = MM__PreCmd_GetExpression(handler, "condition").Compute(handler.Context);
                try
                {
                    var boolConv = exprResult.Type.BoolConv();
                    action(boolConv.ToBool(exprResult));
                }
                catch (EValueException e) when (handler.Input.Current.Length > 1)
                { throw new BadSrcException(e.Message, refPnt: handler.Input.Current[1].RefPnt); }
                catch (EValueException e)
                { throw new BadSrcException(e.Message, refPnt: handler.Input.Current[0].RefPnt); }
            }
            else
            {
                action(false); // Dummy value
            }
            ++handler.Input.Pos;
        }
        
        private static void MM__PreCmd_IfDef(Handler handler, Action<bool> action, bool not, bool elif)
        {
            if (MM__PreCmd_ConsiderCond(handler, elif))
            {
                var name = MM__PreCmd_GetMacroName(handler);
                var condition = handler.Persistent.Macros.Curr.TryGet(name, out _);
                action(not ? (!condition) : condition);
            }
            else
            {
                action(false); // Dummy value
            }
            ++handler.Input.Pos;
        }

        #endregion

        #region methods

        private static void MM_PreCmd_ECHO(Handler handler)
        {
            if (handler.If.Level == handler.If.Active)
            {
                // Print each argument as an expression
                var tokens = MM_Analyze(handler, MM_ExpandMacros(handler, 1, null, out _));
                var arg_beg = 0;
                var arg_end = 0;
                var args = 0;
                void print()
                {
                    IEnumerable<LexToken> getArg()
                    {
                        for (int i = arg_beg; i < arg_end; ++i)
                        yield return tokens[i];
                    }
                    if (arg_beg == arg_end) return;
                    if (args++ > 0) Console.Write(" ");
                    var expr = Expr.Analyze(getArg(), handler.Rules.Expression,
                        failRefPnt: handler.Input.Current[0].RefPnt);
                    Console.Write(expr.Debug(handler.Context));
                }
                if (handler.Rules.PreCmdArgSep is not null)
                {
                    while (arg_end < tokens.Count)
                    {
                        var token = tokens[arg_end];
                        if (token.Rough.RawData.Raw == handler.Rules.PreCmdArgSep)
                        { print(); arg_beg = ++arg_end; }
                        else
                        { ++arg_end; }
                    }
                }
                else
                {
                    arg_end = tokens.Count;
                }
                print(); Console.WriteLine();
            }
            ++handler.Input.Pos;
        }

        private static void MM_PreCmd_INCLUDE(Handler handler)
        {
            if (handler.If.Level == handler.If.Active)
            {
                var exprResult = MM__PreCmd_GetExpression(handler, "string").Compute(handler.Context);
                try
                {
                    // Find path
                    var path = handler.Context.GetFile(exprResult);
                    // Setup search directories
                    List<NormalPath> searchDirs = [..handler.Context.Params.SearchDirectories];
                    if (!handler.Params.Expression.DoNotAddIncludeDirs)
                    {
                        var includeDir = ExprUtil.GetParentDir(path);
                        searchDirs.Remove(includeDir); // Remove if already is list
                        searchDirs.Add(includeDir); // Add to end of list
                    }
                    // Setup parameters
                    var @params = handler.Params;
                    @params.Expression.SearchDirectories = new(searchDirs);
                    // Lexically-analyze included file
                    SrcString includedSrc = new(ExprUtil.ReadAllText(path), srcpath: path);
                    var included = Lex.MM_Run(includedSrc, handler.Rules, @params, handler.Persistent);
                    handler.Output.AddRange(included.Lines);
                }
                catch (EValueException e)
                {
                    throw new BadSrcException(e.Message, refPnt: handler.Input.Current[1].RefPnt);
                }
            }
            ++handler.Input.Pos;
        }

        private static void MM_PreCmd_DEFINE(Handler handler)
        {
            if (handler.If.Level == handler.If.Active)
            {
                // Get macro name
                var name = MM__PreCmd_GetMacroName(handler, true);
                if (!LexParUtil.IsLegalName(name))
                {
                    throw new BadSrcException(
                        $"Illegal macro name: {name}",
                        handler.Input.Current[1].RefPnt);
                }
                if (handler.Persistent.Macros.Curr.TryGet(name, out _))
                {
                    throw new BadSrcException(
                        $"There is already a macro named {name}",
                        handler.Input.Current[1].RefPnt);
                }
                // Get macro definition
                bool isFuncLike = false;
                HashSet<string> @params = [];
                List<RoughToken> body = [];
                if (handler.Input.Current.Length > 2)
                {
                    if (handler.Rules.MacroBrackets is not null)
                    {
                        int pos = 2;
                        // Parameters
                        if (handler.Input.Current[pos].RawData.Raw == handler.Rules.MacroBrackets.Open)
                        {
                            int revertPos = pos;
                            bool failIfClose = false;
                            bool failIfComma = true;
                            while (true)
                            {
                                // Next token
                                if (++pos == handler.Input.Current.Length) break;
                                RoughToken ptoken = handler.Input.Current[pos];
                                // Is this a closing bracket?
                                if (ptoken.RawData.Raw == handler.Rules.MacroBrackets.Close)
                                {
                                    if (!failIfClose)
                                    {
                                        isFuncLike = true;
                                        ++pos;
                                    }
                                    break;
                                }
                                // No!
                                bool isComma = 
                                    handler.Rules.MacroParamSep is null || 
                                    ptoken.RawData.Raw == handler.Rules.MacroParamSep;
                                if (failIfComma)
                                {
                                    // This must be a parameter name
                                    if (isComma) break;
                                    if (!LexParUtil.IsLegalName(ptoken.RawData.Raw))
                                        break;
                                    if (@params.Contains((string)ptoken.RawData.Raw))
                                        break;
                                    @params.Add((string)ptoken.RawData.Raw);
                                    failIfClose = false;
                                    failIfComma = false;
                                }
                                else
                                {
                                    // This must be a comma
                                    if (!isComma) break;
                                    failIfClose = true;
                                    failIfComma = true;
                                }
                            }
                            // In case parameter parsing failed
                            if (!isFuncLike)
                            {
                                pos = revertPos;
                                @params.Clear();
                                body.Clear();
                            }
                        }
                        // Body
                        while (pos < handler.Input.Current.Length)
                            body.Add(handler.Input.Current[pos++]);
                    }
                }
                handler.Persistent.Macros.Define(
                    new(name, 
                    isFuncLike,
                    new(@params), 
                    handler.Input.Current[1].RefPnt,
                    new(body)));
            }
            ++handler.Input.Pos;
        }

        private static void MM_PreCmd_UNDEF(Handler handler)
        {
            if (handler.If.Level == handler.If.Active)
            {
                var name = MM__PreCmd_GetMacroName(handler);
                if (!handler.Persistent.Macros.Curr.TryGet(name, out _))
                {
                    throw new BadSrcException(
                        $"Undefined macro: {name}", handler.Input.Current[1].RefPnt);
                }
                handler.Persistent.Macros.Undefine(name);
            }
            ++handler.Input.Pos;
        }

        private static void MM_PreCmd_IF(Handler handler)
        {
            MM__PreCmd_If(handler, handler.If.If, false);
        }

        private static void MM_PreCmd_ELSE(Handler handler)
        {
            MM__PreCmd_ThrowIfTooManyArgs(handler, 1);
            MM__PreCmd_ThrowIfNotInIfBlock(handler);
            handler.If.Else(true);
            ++handler.Input.Pos;
        }

        private static void MM_PreCmd_ELIF(Handler handler)
        {
            MM__PreCmd_ThrowIfNotInIfBlock(handler);
            MM__PreCmd_If(handler, handler.If.Else, true);
        }

        private static void MM_PreCmd_ENDIF(Handler handler)
        {
            MM__PreCmd_ThrowIfTooManyArgs(handler, 1);
            MM__PreCmd_ThrowIfNotInIfBlock(handler);
            handler.If.EndIf();
            ++handler.Input.Pos;
        }

        private static void MM_PreCmd_IFDEF(Handler handler)
        {
            MM__PreCmd_IfDef(handler, handler.If.If, false, false);
        }

        private static void MM_PreCmd_IFNDEF(Handler handler)
        {
            MM__PreCmd_IfDef(handler, handler.If.If, true, false);
        }

        private static void MM_PreCmd_ELIFDEF(Handler handler)
        {
            MM__PreCmd_ThrowIfNotInIfBlock(handler);
            MM__PreCmd_IfDef(handler, handler.If.Else, false, true);
        }

        private static void MM_PreCmd_ELIFNDEF(Handler handler)
        {
            MM__PreCmd_ThrowIfNotInIfBlock(handler);
            MM__PreCmd_IfDef(handler, handler.If.Else, true, true);
        }

        #endregion
    }
}
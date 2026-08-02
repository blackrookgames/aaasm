using System;
using cmdaxe;
using aaasm.cmd;
using aaasm.engine.io;
using aaasm.engine.lxpr;
using System.IO;

using mos6502 = aaasm.cpu.mos6502;
using System.Collections.Generic;

namespace aaasm
{
    [Command(name: "ass", group: "6502", desc: "Runs the assembler")]
    class Cmd_6502_ass : Command
    {
        #region const

        private const string DEFAULT_OUT = $"output{Const.EXT_OUTPUT}";

        #endregion

        #region parameters

        [Required(
            name: "src", 
            desc: "Source file (*.asm)")]
        NormalPath? src;

        [OptionWArg(
            name: "out", 
            shortcut: 'o', 
            desc: $"Output file (*{Const.EXT_OUTPUT}); default is {DEFAULT_OUT}",
            argType: "path")]
        NormalPath? @out;

        [OptionWArg(
            name: "out_lex",
            desc: "If specified, lexically analyzed source code will be saved here",
            argType: "path")]
        NormalPath? out_lex;

        [OptionWArg(
            name: "def", 
            shortcut: 'D', 
            desc: "Macro definition (parameters not supported)",
            argType: "name[=value]")]
        MacroDef[]? defs;

        [OptionWArg(
            name: "include", 
            shortcut: 'I', 
            desc: "Search directory (used to locate included files)",
            argType: "directory")]
        NormalPath[]? includes;

        #endregion

        #region methods

        public override void Main()
        {
            try
            {
                // Open source file
                SrcString source;
                using (var f = CmdUtil.FileOpenRead(src!))
                    source = new (StreamUtil.ReadAllText(f), src);
                // Gather search directories
                List<NormalPath> searchDirs = [CmdUtil.GetParentDir(src!)];
                if (includes is not null) searchDirs.AddRange(includes);
                // Setup lexicial analysis parameters
                LexParams lexParams = new();
                lexParams.Expression.SearchDirectories = new(searchDirs);
                if (defs is not null) lexParams.MacroDefs = new(defs);
                // Lexicial analysis
                var lex = Lex.Run(source, mos6502.Rules.LEX, lexParams);
                if (out_lex is not null)
                {
                    using StringWriter w = new();
                    void write(LexToken token)
                    {
                        if (token.Brackets is not null)
                            w.Write($"{token.Brackets.Open} ");
                        else
                            w.Write($"{token.Rough.RawData.Raw} ");
                        foreach (var child in token.Children)
                            write(child);
                        if (token.Brackets is not null)
                            w.Write($"{token.Brackets.Close} ");
                    }
                    foreach (var line in lex.Lines)
                    {
                        foreach (var t in line) write(t);
                        w.WriteLine();
                    }
                    CmdUtil.WriteAllText(out_lex, w.ToString());
                }
            }
            catch (BadSrcException e)
            {
                using StringWriter w = new();
                // Reference point
                if (e.RefPnt.HasValue && e.RefPnt.Value.Path is not null)
                {
                    // Path
                    w.WriteLine(e.RefPnt.Value.Path);
                    // Line
                    if (e.RefPnt.Value.Line > 0)
                        w.WriteLine($"Line:  {e.RefPnt.Value.Line}");
                    // Column
                    if (e.RefPnt.Value.Col > 0)
                        w.WriteLine($"Col:   {e.RefPnt.Value.Col}");
                }
                // Message
                w.Write(e.Message);
                // Final
                throw new CommandException(w.ToString());
            }
        }

        #endregion
    }
}
using System;
using System.IO;
using System.Linq;
using aaasm.engine.lxpr;
using aaasm.engine.col;
using cmdaxe;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace aaasm
{
    [Command(name: "calc", desc: DESC)]
    class Cmd_calc : Command
    {
        private const string DESC = 
            "Calculator";

        #region static

        static Cmd_calc()
        {
            LexRulesInit lexRules = new();
            lexRules.Comments = ImmNullArray<LexCommentRules>.EMPTY;
            lexRules.LineContinue = null;
            lexRules.RoughSymbols = new(from s in (
                (from c in "()[]#,+-*/%&|^~<>!" select new string(c.ToString()))
                .Concat(["<<", ">>", ">>>", "!=", "==", "<=", ">=", "&&", "||"])
                ) select (CIStr)s);
            LEXRULES = new(lexRules);
        }

        private static readonly LexRules LEXRULES;

        #endregion

        #region helper methods

        private static void MM_Print(object value, ConsoleColor color)
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = color;
                Console.WriteLine(value);
            }
            finally
            {
                Console.ForegroundColor = prevColor;
            }
        }

        private static void MM_PrintError(string message) =>
            MM_Print(message, ConsoleColor.Red);

        private static void MM_Execute(string input)
        {
            try
            { Lex.Run(new($"@ECHO {input}"), LEXRULES, new()); }
            catch (BadSrcException e)
            { MM_PrintError(e.Message); }
            catch (CommandException e)
            { MM_PrintError(e.Message); }
        }

        #endregion

        #region methods

        public override void Main()
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            try
            {
                // Intro
                Console.WriteLine("Calculator Tool");
                Console.WriteLine("Type 'order' for order of operations");
                Console.WriteLine("Type 'func' for available functions");
                Console.WriteLine("Type 'exit' to quit");
                // Loop
                while (true)
                {
                    Console.Write("> ");
                    string? input = Console.ReadLine();
                    if (input is not null)
                    {
                        if (input == "order")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Order of operations");
                            Console.WriteLine("<func> ()          Functions, parentheses");
                            Console.WriteLine("- ~ < >            Unary: Negation, Bitwise NOT, Lo-Byte, Hi-Byte");
                            Console.WriteLine("* / %              Multiplication, Division, Modulus");
                            Console.WriteLine("+ -                Addition, Subtraction");
                            Console.WriteLine("<< >> >>>          Bit-shift: Left, Signed Right, Unsigned Right");
                            Console.WriteLine("& | ^              Bitwise: AND, OR, XOR");
                            Console.WriteLine("== != < <= > >=    Comparison");
                            Console.WriteLine("&& || !            Boolean");
                            Console.WriteLine();
                        }
                        else if (input == "func")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Functions");
                            Console.WriteLine("U8     Convert to 8-bit unsigned integer");
                            Console.WriteLine("I8     Convert to 8-bit signed integer");
                            Console.WriteLine("U16    Convert to 16-bit unsigned integer");
                            Console.WriteLine("I16    Convert to 16-bit signed integer");
                            Console.WriteLine("U32    Convert to 32-bit unsigned integer");
                            Console.WriteLine("I32    Convert to 32-bit signed integer");
                            Console.WriteLine("U64    Convert to 64-bit unsigned integer");
                            Console.WriteLine("I64    Convert to 64-bit signed integer");
                            Console.WriteLine("F32    Convert to 32-bit floating-point decimal");
                            Console.WriteLine("F64    Convert to 64-bit floating-point decimal");
                            Console.WriteLine();
                        }
                        else if (input == "exit")
                        {
                            break;
                        }
                        else
                        {
                            MM_Execute(input);
                        }
                    }
                }
            }
            finally
            {
                Console.ForegroundColor = prevColor;
            }
        }

        #endregion
    }
}
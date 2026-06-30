using System;
using System.Linq;
using cmdaxe;
using aaasm.engine.cmd;
using aaasm.engine.data;
using aaasm.engine.io;
using System.Text;

namespace aaasm
{
    [Command(name: "ass", desc: "Runs the assembler")]
    class Cmd_ass : Command
    {
        #region const

        private const string DEFAULT_OUT = $"output{Const.EXT_OUTPUT}";

        #endregion

        #region parameters

        [Required(
            name: "src", 
            desc: "Source file (*.asm)")]
        string src;

        [OptionWArg(
            name: "out", 
            shortcut: 'o', 
            desc: $"Output file (*{Const.EXT_OUTPUT}); default is {DEFAULT_OUT}",
            argType: "path")]
        string @out;

        [OptionWArg(
            name: "Def", 
            shortcut: 'D', 
            desc: "Macro definition (parameters not supported)",
            argType: "name[=value]")]
        string[] defs;

        [OptionWArg(
            name: "Include", 
            shortcut: 'I', 
            desc: "Search directory (used to locate included files)",
            argType: "directory")]
        string[] includes;

        #endregion

        #region methods

        public override void Main()
        {
            SrcStr[] srcLines;
            using (var s = CmdUtil.FileOpenRead(src))
                srcLines = DataUtil.ReadSource(s);
            using (var s = CmdUtil.FileOpenWrite("test.txt"))
                StreamUtil.WriteAllLines(s, Encoding.ASCII, from srcLine in srcLines select srcLine.Raw);
            
            
            foreach (var line in srcLines)
            {
                if (line.Length > 0)
                {
                    Console.WriteLine($"Line {line[0].PLC.Line:000} {line} {line[^1].PLC.Col}");
                }
                else
                {
                    Console.WriteLine();
                }
            }
            


            FileMagic4 f = new ("6502");
            Console.WriteLine($"{(int)f:X8}");
            
            
                

            Console.WriteLine("Hello world!");
        }

        #endregion
    }
}
using System;
using cmdaxe;
using aaasm.cmd;
using aaasm.engine.io;
using aaasm.engine.lexpar;
using mos6502 = aaasm.engine.lexpar.mos6502;

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

        /*
        [OptionWArg(
            name: "Def", 
            shortcut: 'D', 
            desc: "Macro definition (parameters not supported)",
            argType: "name[=value]")]
        UserMacro[]? defs;
        */

        [OptionWArg(
            name: "Include", 
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
                // Stage-0
                var lex0 = Lex0.Run(source, mos6502.Rules.LEX0);
                foreach (var line in lex0.Lines)
                {
                    foreach (var t in line)
                        Console.Write($"{{{t.RawData.Raw}}}");
                    Console.WriteLine();
                }
            }
            catch (BadSrcException e)
            {
                bool noOrigin = (!e.RefPnt.HasValue) || e.RefPnt.Value.Path is null;
                string origin = noOrigin ? "" : (
                    $"\"{e.RefPnt!.Value.Path}\"\n"+
                    $"Line:  {e.RefPnt!.Value.Line}\n"+
                    $"Col:   {e.RefPnt!.Value.Col}\n");
                throw new CommandException($"{origin}{e.Message}");
            }
        }

        #endregion
    }
}
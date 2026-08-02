using System;
using cmdaxe;
using aaasm.engine.io;
using aaasm.engine.lxpr;

using aaasm.cmd;
using aaasm.cpu.mos6502;
using aaasm.engine.data;
using aaasm.engine.help;
using aaasm.engine.col;
using System.Data;

namespace aaasm
{
    [Command(name: "test", desc: "Test command")]
    class Cmd_test : Command
    {
        #region cmdaxe

        [Required]
        private string? label;

        #endregion

        #region methods

        public override void Main()
        {
            ExprRules rules = new(new());
            Console.WriteLine(rules.IsValidLabelDeclaration(new(label)));
        }

        #endregion
    }
}
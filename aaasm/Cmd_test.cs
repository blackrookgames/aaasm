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
            LexRoughRegexPattern regex = new(@"\d");
            Console.WriteLine(regex.MatchAt((Str)"012345", 1));
            Console.WriteLine(regex.MatchAt((Str)"2A2345", 1));
            Console.WriteLine(regex.MatchAt((Str)"312345", 1));
            Console.WriteLine(regex.MatchAt((Str)"a12345", 1));
        }

        #endregion
    }
}
using System;
using cmdaxe;

namespace aaasm
{
    [Command(name: "6502", desc: DESC)]
    class Cmd_6502 : SuperCommand
    {
        private const string DESC = 
            "MOS 6502 8-bit processor";

        protected override string? PP_SubGroupName => "6502";
    }
}
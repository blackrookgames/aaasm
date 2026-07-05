using System;
using cmdaxe;
using aaasm.cmd;
using aaasm.engine.io;
using aaasm.engine.lexpar;
using gbz80 = aaasm.engine.lexpar.gbz80;

namespace aaasm
{
    [Command(name: "gbz80", desc: DESC)]
    class Cmd_gbz80 : SuperCommand
    {
        private const string DESC = 
            "Sharp SM83 8-bit Processor found in the Nintendo Gameboy\n" +
            "This processor is a hybrid of the Zilog Z80 and the Intel 8080.";

        protected override string? PP_SubGroupName => "gbz80";
    }
}
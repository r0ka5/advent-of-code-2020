using System;
using System.Collections.Generic;
using System.Text;

namespace day8task
{
    public class Instruction
    {
	    public Action Action { get; set; }
        public int    Points { get; set; }
    }

    public enum Action
    {
	    acc,
	    jmp,
	    nop
    }
}

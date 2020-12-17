using System;
using System.Collections.Generic;
using System.Text;

namespace day8task
{
    public static class Parser
    {
	    public static Instruction Parse(string instruction)
	    {
		    var instruct = instruction.Split(" ");
		    return new Instruction()
		    {
			    Action = Enum.Parse<Action>(instruct[0]),
			    Points = Int32.Parse(instruct[1])
		    };
	    }
    }
}

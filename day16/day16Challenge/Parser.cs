using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace day16Challenge
{
    public static class Parser
    {
	    public static List<int> ParseTicket(string ticket)
	    {
		    var ticketArray = ticket.Split(',');
		    return Array.ConvertAll(ticketArray, x => 
			                            Int32.Parse(x)).ToList();
	    }
        public static Rule ParseRule(string ruleStr)
	    {
            var rule      = new Rule();
            var ruleSplit = ruleStr.Split(new string[] {":", "-", " or "}, StringSplitOptions.None);
            rule.Name = ruleSplit[0];
            rule.Ranges.Add(new Range()
            {
	            Min = Int32.Parse(ruleSplit[1]),
	            Max = Int32.Parse(ruleSplit[2])
            });
            rule.Ranges.Add(new Range()
            {
	            Min = Int32.Parse(ruleSplit[3]),
	            Max = Int32.Parse(ruleSplit[4])
            });
            return rule;
	    }

    }
}

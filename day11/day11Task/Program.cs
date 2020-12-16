using System;
using System.Collections.Generic;
using System.Linq;

namespace day11Task
{
    public class Program
    {
	    static void Main(string[] args)
	    {
		    string line;
		    var    file   = new System.IO.StreamReader(@"input.txt");
		    var    layout = new List<List<char>>();
		    while ((line = file.ReadLine()) != null)
		    {
			    layout.Add(line.ToList());
		    }

		    var prevLayout = layout;
		    var counter    = 0;
		    while (true)
		    {
			    counter++;
			    var newLayout = RulesEngine.ApplyRules(prevLayout);
			    if (RulesEngine.AreEqual(newLayout, prevLayout))
				    break;
			    prevLayout = newLayout;
		    }

		    var result = RulesEngine.GetOccupiedCount(prevLayout);
			Console.WriteLine(result);
	    }
    }
}

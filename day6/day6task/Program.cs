using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace day6task
{
    class Program
    {
        static void Main(string[] args)
        {
	        string line;
	        var    file  = new System.IO.StreamReader(@"input.txt");
	        var    lines = new List<string>();

			var items = new List<List<string>>();
			var item  = new List<string>();
			while ((line = file.ReadLine()) != null)
	        {
		        if (string.IsNullOrEmpty(line))
		        {
			        items.Add(item);
			        item = new List<string>();
					continue;
		        }

		        item.Add(line);
	        }
	        items.Add(item);

			var sum = 0;
	        foreach (var str in items)
	        {
		        sum += GetDistinctNumber(str);
	        }

			Console.WriteLine(sum);
			Console.ReadLine();
        }

        private static int GetDistinctNumber(List<string> line)
        {
	        var fullLine = "";
	        line.ForEach(x => fullLine += x);
	        int count     = 0;
	        var strArray=fullLine.Distinct().ToArray();
	        foreach (var chara in strArray)
	        {
		        if (charExists(line, chara))
		        {
			        count++;
		        }
			}

	        return count;
        }

        private static bool charExists(List<string> line, char character)
        {
	        foreach (var VARIABLE in line)
	        {
		        if (!VARIABLE.Contains(character))
		        {
			        return false;
		        }
	        }
			return true;
        }



	}
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace day16Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
	        string line;
	        var    file   = new System.IO.StreamReader(@"input.txt");
	        var    ticketResult = new TicketResult();
	        while ((line = file.ReadLine()) != "your ticket:")
	        {
		        if (line != "")
			        ticketResult.Rules.Add(Parser.ParseRule(line));
	        }
	        while ((line = file.ReadLine()) != "nearby tickets:")
	        {
		        if (line != "")
			        ticketResult.YourTicket = Parser.ParseTicket(line);
	        }
	        while ((line = file.ReadLine()) != null)
	        {
		        if (line != "")
			        ticketResult.NearbyTickets.Add(Parser.ParseTicket(line));
	        }

	        var values = Util.GetValidTickets(ticketResult);

			values.Add(ticketResult.YourTicket);

			var classes = Util.GetClassNames(ticketResult, values);

			var validRows = new List<RowClass>();
			while(classes.Count>0)
            {

				var grouped = classes.GroupBy(x => x.Row,
				                              (baserow, count) => new
				                              {
					                              key   = baserow,
					                              count = count.Count(),
					                              name  = count.First()
				                              }).ToList();
				var res            = grouped.First(x => x.count == 1);
				var invalidClasses = classes.Where(x => x.Class == res.name.Class || x.Row == res.name.Row).ToList();
				foreach (var invalidClass in invalidClasses)
				{
					classes.Remove(invalidClass);
				}
				validRows.Add(res.name);
            }

			long result = (long)1;
			foreach (var rowClass in validRows.Where(x=>x.Class.Contains("departure")))
			{
				result = (long)ticketResult.YourTicket[rowClass.Row] * result;
			}

			Console.WriteLine(result);
        }
	}
}

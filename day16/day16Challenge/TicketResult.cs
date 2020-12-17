using System;
using System.Collections.Generic;
using System.Text;

namespace day16Challenge
{
	public class TicketResult
	{
		public List<Rule>      Rules         { get; set; } = new List<Rule>();
		public List<int>       YourTicket    { get; set; } = new List<int>();
		public List<List<int>> NearbyTickets { get; set; } = new List<List<int>>();
	}

	public class Rule
    {
	    public string      Name  { get; set; }
        public List<Range> Ranges { get; set ; } = new List<Range>();
    }

    public class Range
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    public class RowClass
    {
        public int Row   { get; set; }
        public string Class { get; set; }
    }
}

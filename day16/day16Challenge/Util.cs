using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace day16Challenge
{
	public static class Util
	{
		public static List<int> GetInvalidValues(TicketResult ticketResult)
		{
			var invalidValues = new List<int>();

			foreach (var nearbyTicket in ticketResult.NearbyTickets)
			{
				foreach (var ticket in nearbyTicket)
				{
					var applies = false;
					foreach (var rule in ticketResult.Rules)
					{
						foreach (var range in rule.Ranges)
						{
							if (ticket >= range.Min && ticket <= range.Max)
							{
								applies = true;
							}
						}
					}

					if (!applies)
					{
						invalidValues.Add(ticket);
					}
				}
			}

			return invalidValues;
		}

		public static List<List<int>> GetValidTickets(TicketResult ticketResult)
		{
			var valid = new List<List<int>>();

			foreach (var nearbyTicket in ticketResult.NearbyTickets)
			{
				var applies = true;

				foreach (var ticket in nearbyTicket)
				{
					var numberValid = false;
					foreach (var rule in ticketResult.Rules)
					{
						numberValid = numberValid || RuleIsValid(rule, ticket);
					}

					if (!numberValid)
						applies = false;
				}
				if (applies)
				{
					valid.Add(nearbyTicket);
				}
			}

			return valid;
		}

		public static List<RowClass> GetClassNames(TicketResult ticketResult, List<List<int>> validTickets)
		{
			var result = new List<RowClass>();
			for (int v = 0; v < validTickets[0].Count; v++)
			{
				foreach (var rule in ticketResult.Rules)
				{
					var valid = TicketValid(rule, validTickets, v);
					if (valid)
						result.Add(new RowClass(){ Class = rule.Name, Row = v});
				}
			}
			return result;
		}

		private static bool TicketValid(Rule rule, List<List<int>> tickets, int collumn)
		{
			for (int i = 0; i < tickets.Count; i++)
			{
				if (!RuleIsValid(rule, tickets[i][collumn]))
					return false;
			}
			return true;
		}


		private static bool RuleIsValid(Rule rule, int ticket)
		{
			foreach (var range in rule.Ranges)
			{
				if (ticket >= range.Min && ticket <= range.Max)
				{
					return true;
				}
			}

			return false;
		}
	}
}

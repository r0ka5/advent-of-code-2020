using System;
using System.Collections.Generic;
using System.Linq;

namespace day7task
{
	class Program
	{
		static void Main(string[] args)
		{
			string line;
			var    file    = new System.IO.StreamReader(@"input.txt");
			var    bagList = new List<BagWithContent>();
			while ((line = file.ReadLine()) != null)
			{
				bagList.Add(Parser.Parse(line));
			}

			var nonRootItem = bagList.Where(x => x.Name != "shiny gold").ToList();
			var rootItem    = bagList.First(x => x.Name == "shiny gold");

			var count = calculateInDepth(nonRootItem, rootItem);

			Console.WriteLine(count);
		}

		private static int calculateInDepth(List<BagWithContent> list, BagWithContent item)
		{
			var sum = 0;
			if (item.Items.Count == 0)
				return 0;

			foreach (var itemItem in item.Items)
			{
				sum += itemItem.Count * (1 + calculateInDepth(list, list.First(x => x.Name == itemItem.Name.Trim())));
			}

			return sum;
		}

		//static void Main(string[] args)
		//{
		//	string line;
		//	var    file    = new System.IO.StreamReader(@"input.txt");
		//	var    bagList = new List<BagWithContent>();
		//	while ((line = file.ReadLine()) != null)
		//	{
		//		bagList.Add(Parser.Parse(line));
		//	}

		//	var rootItem = bagList.Where(x => x.Name == "shiny gold").ToList();

		//	var count       = 0;
		//	foreach (var bagWithContent in nonRootItem)
		//	{
		//		if (ContainsItem(bagList, bagWithContent))
		//		{
		//			count++;
		//		}
		//	}

		//	Console.WriteLine(count);
		//}

		public static bool ContainsItem(List<BagWithContent> list , BagWithContent item )
		{
			bool result = false;

			if (item.Items.Any(x => x.Name == "shiny gold"))
				return true;
			else
			{
				if (item.Items.Count == 0)
					return false;
				foreach (var itemItem in item.Items)
				{
					result = result || ContainsItem(list, list.First(x => x.Name == itemItem.Name.Trim()));
				}
			}
			return result;
		}
	}
}

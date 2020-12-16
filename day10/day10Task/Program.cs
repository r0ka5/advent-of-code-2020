using System;
using System.Collections.Generic;
using System.Linq;

namespace day10Task
{
	class Program
	{
		static void Main(string[] args)
		{
			string line;
			var    file     = new System.IO.StreamReader(@"input.txt");
			var    adapters = new List<int>();
			while ((line = file.ReadLine()) != null)
			{
				adapters.Add(Int32.Parse(line));
			}

			adapters.Add(0);
			adapters.Add(adapters.Max() + 3);
			var adaptersOrdered     = adapters.OrderBy(x => x).ToList();
			var adaptersOrderedDesc = adapters.OrderByDescending(x => x).ToList();

			var tree = new List<TreeItem>();
			foreach (var adapter in adaptersOrderedDesc)
			{
				var  steps  = GetAllAvailableSteps(adaptersOrdered, adapter);
				long routes = 0;
				foreach (var step in steps)
				{
					var existingSteps = tree.FirstOrDefault(x => x.RootItem == step);
					if (existingSteps != null)
						routes += existingSteps.Routes;
					else
					{
						routes++;
					}
				}

				tree.Add(new TreeItem() {ChildItems = steps, RootItem = adapter, Routes = routes});
			}

			var result = tree.First(x => x.RootItem == 0);
			Console.Write(result.Routes);

		}

		public static List<int> GetAllAvailableSteps(List<int> adapters, int step)
		{
			var index         = adapters.IndexOf(step);
			var availableList = new List<int>();
			for (int i = 1; i <= 3; i++)
			{
				if (adapters.Count > index + i)
				{
					var adapterValue = adapters[index + i];
					if (adapterValue - step <= 3)
						availableList.Add(adapterValue);
				}
			}

			if (availableList.Count() == 0)
				availableList.Add(adapters.Last());

			return availableList;
		}
	}
}

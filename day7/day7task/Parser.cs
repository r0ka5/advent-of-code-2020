using System;
using System.Collections.Generic;
using System.Text;

namespace day7task
{
    public static class Parser
    {
	    public static BagWithContent Parse(string line)
	    {
		    var mainBag = line.Split("bags")[0];
			var content = line.Split("contain")[1];
			var items   = content.Split(',', '.');

			var bagWithContent = new BagWithContent() {Name = mainBag.Trim(), Items = new List<Item>()};

			for (int i = 0; i < items.Length-1; i++)
			{
				if (items[i].Contains("no other bags"))
					break;
				var itemSpacesRemoved = items[i].Trim();
				var count             = Int32.Parse(itemSpacesRemoved[0].ToString());
				var itemName          = itemSpacesRemoved.Substring(1, itemSpacesRemoved.Length-1).Replace("bags","").Replace("bag", "");
				bagWithContent.Items.Add(new Item()
				{
					Count = count,
					Name = itemName.Trim()
				});
			}

			return bagWithContent;
	    }
    }
}

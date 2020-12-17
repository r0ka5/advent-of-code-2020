using System;
using System.Collections.Generic;
using System.Text;

namespace day7task
{
    public class BagWithContent
    {
        public string               Name  { get; set; }
        public List<Item>           Items { get; set; }

    }

    public class Item
    {
        public string Name  { get; set; }
	    public int    Count { get; set; }
    }
}

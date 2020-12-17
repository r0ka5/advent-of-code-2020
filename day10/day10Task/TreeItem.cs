using System;
using System.Collections.Generic;
using System.Text;

namespace day10Task
{
    public class TreeItem
    {
	    public int            RootItem      { get; set; }
        public List<int>      ChildItems    { get; set; }
        public long            Routes        { get; set; }

    }
}

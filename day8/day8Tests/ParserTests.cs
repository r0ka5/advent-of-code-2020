using Microsoft.VisualStudio.TestTools.UnitTesting;
using day8task;
using System;
using System.Collections.Generic;
using System.Text;

namespace day8task.Tests
{
    [TestClass()]
    public class ParserTests
    {
        [TestMethod()]
        public void ParseTest()
        {
	        var item = Parser.Parse("jmp +167");
            Assert.AreEqual(item.Action, Action.jmp);
            Assert.AreEqual(item.Points, 167);
        }
        [TestMethod()]
        public void ParseTestNegative()
        {
	        var item = Parser.Parse("acc -8");
	        Assert.AreEqual(item.Action, Action.acc);
	        Assert.AreEqual(item.Points, -8);
        }
    }
}
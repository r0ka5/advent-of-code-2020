using day7task;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day7Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestParser()
        {
	        var result = Parser.Parse("vibrant orange bags contain 3 plaid tan bags, 4 dotted blue bags, 3 bright gold bags, 3 bright white bags.");
            Assert.AreEqual(result.Name, "vibrant orange");
            Assert.AreEqual(result.Items.Count, 4);
        }
    }
}

using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using password;

namespace Password.Tests
{
    [TestClass]
    public class PasswordTests
    {
        [TestMethod]
        [DataRow(1, 3, "a", "aaabbbbbb", true)]
        [DataRow(1, 3, "a", "aaabbbbaabb", false)]
        public void ValidateCondition(int min, int max, string letter, string password, bool isValid)
        {
            var isValidResult = MainClass.isValid(min, max, letter, password);
            Assert.AreEqual(isValid, isValidResult);
        }

        [TestMethod]
        [DataRow(1, 3, "a", "aabaaa", true)]
        [DataRow(1, 3, "a", "aaaaaaaaaa", false)]
        public void Validate2ndCondition(int position1, int position2, string letter, string password, bool isValid)
        {
            var isValidResult = MainClass.isValid2ndRule(position1, position2, letter, password);
            Assert.AreEqual(isValid, isValidResult);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using day11Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace day11Task.Tests
{
    [TestClass()]
    public class RulesEngineTests
    {
        [TestMethod()]
        public void ApplyRulesTest1()
        {
            var seats = @"#.LL.LL.L#
#LLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLL#
#.LLLLLL.L
#.LLLLL.L#".Split(new char[] { '\n', '\r' }).ToList();
            List<List<char>> layout = new List<List<char>>();

            foreach (var line in seats)
            {
                if (line.Length > 0)
                    layout.Add(line.ToList());
            }

            var expectedResult = @"#.L#.##.L#
#L#####.LL
L.#.#..#..
##L#.##.##
#.##.#L.##
#.#####.#L
..#.#.....
LLL####LL#
#.L#####.L
#.L####.L#".Split(new char[] { '\n', '\r' }).ToList();
            List<List<char>> expectedLayout = new List<List<char>>();

            foreach (var line in expectedResult)
            {
                if (line.Length > 0)
                    expectedLayout.Add(line.ToList());
            }

            var result = RulesEngine.ApplyRules(layout);
            var equal = RulesEngine.AreEqual(expectedLayout, result);
            Assert.AreEqual(true, equal);
        }

        [TestMethod()]
        public void ApplyRulesTest2()
        {
            var seats = @"#.#L.L#.##
#LLL#LL.L#
L.#.L..#..
#L##.##.L#
#.#L.LL.LL
#.#L#L#.##
..L.L.....
#L#L##L#L#
#.LLLLLL.L
#.#L#L#.##".Split(new char[] { '\n', '\r' }).ToList();
            List<List<char>> layout = new List<List<char>>();

            foreach (var line in seats)
            {
                if (line.Length > 0)
                    layout.Add(line.ToList());
            }

            var expectedResult = @"#.#L.L#.##
#LLL#LL.L#
L.#.L..#..
#L##.##.L#
#.#L.LL.LL
#.#L#L#.##
..L.L.....
#L#L##L#L#
#.LLLLLL.L
#.#L#L#.##".Split(new char[] { '\n', '\r' }).ToList();
            List<List<char>> expectedLayout = new List<List<char>>();

            foreach (var line in expectedResult)
            {
                if (line.Length > 0)
                    expectedLayout.Add(line.ToList());
            }

            var result = RulesEngine.ApplyRules(layout);
            var equal = RulesEngine.AreEqual(expectedLayout, result);
            Assert.AreEqual(true, equal);
        }

        [TestMethod()]
        public void ApplyRulesTest3()
        {
            var seats = @"#.##.L#.##
#L###LL.L#
L.#.#..#..
#L##.##.L#
#.##.LL.LL
#.###L#.##
..#.#.....
#L######L#
#.LL###L.L
#.#L###.##".Split(new char[] { '\n', '\r' }).ToList();
            List<List<char>> layout = new List<List<char>>();

            foreach (var line in seats)
            {
                if (line.Length > 0)
                    layout.Add(line.ToList());
            }

            var expectedResult = @"#.#L.L#.##
#LLL#LL.L#
L.L.L..#..
#LLL.##.L#
#.LL.LL.LL
#.LL#L#.##
..L.L.....
#L#LLLL#L#
#.LLLLLL.L
#.#L#L#.##".Split(new char[] { '\n', '\r' }).ToList();
            List<List<char>> expectedLayout = new List<List<char>>();

            foreach (var line in expectedResult)
            {
                if (line.Length > 0)
                    expectedLayout.Add(line.ToList());
            }

            var result = RulesEngine.ApplyRules(layout);
            var equal = RulesEngine.AreEqual(expectedLayout, result);
            Assert.AreEqual(true, equal);
        }

        [TestMethod()]
        public void GetVisibleOccupiedSeatsCountTest()
        {
	        var seats = @".......#.
...#.....
.#.......
.........
..#L....#
....#....
.........
#........
...#.....".Split(new char[] { '\n', '\r' }).ToList();
	        List<List<char>> layout = new List<List<char>>();

	        foreach (var line in seats)
	        {
		        if (line.Length > 0)
			        layout.Add(line.ToList());
	        }
            var count = RulesEngine.GetVisibleOccupiedSeatsCount(layout, 4, 3);

            Assert.AreEqual(count, 8);

        }

        [TestMethod()]
        public void GetVisibleOccupiedSeatsCountTestZerp()
        {
	        var seats = @".##.##.
#.#.#.#
##...##
...L...
##...##
#.#.#.#
.##.##.".Split(new char[] { '\n', '\r' }).ToList();
	        List<List<char>> layout = new List<List<char>>();

	        foreach (var line in seats)
	        {
		        if (line.Length > 0)
			        layout.Add(line.ToList());
	        }
	        var count = RulesEngine.GetVisibleOccupiedSeatsCount(layout, 3, 3);

	        Assert.AreEqual(count, 0);

        }
    }
}
using System;
using System.IO;

namespace day3
{
	public class Program
	{
		static void Main(string[] args)
		{
			string line;
			var    file           = new System.IO.StreamReader(@"input.txt");
			var    pathToright1   = 0;
			var    pathToright3   = 0;
			var    pathToright5   = 0;
			var    pathToright7   = 0;
			var    pathToright12  = 1;

			long[] trees  = {(long)0, 0, 0, 0, 0 };

			var lineCount = 1;

			while ((line = file.ReadLine()) != null)
			{
				if (pathToright1 != 0)
				{
					while (line.Length < pathToright7)
					{
						line += line;
					}

					if (TreeExists(pathToright1, line))
						trees[0]++;
					if (TreeExists(pathToright3, line))
						trees[1]++;
					if (TreeExists(pathToright5, line))
						trees[2]++;
					if (TreeExists(pathToright7, line))
						trees[3]++;
					if (lineCount % 2 == 1)
					{
						if (TreeExists(pathToright12, line))
							trees[4]++;
						pathToright12 += 1;
					}
				}

				lineCount++;
				pathToright1 += 1;
				pathToright3 += 3;
				pathToright5 += 5;
				pathToright7 += 7;
			}

			long result = trees[0] * trees[1] * trees[2] * trees[3] * trees[4];
			Console.WriteLine(result);
		}

		public class PathRule
		{
			public int Down  { get; set; }
			public int Right { get; set; }
		}

		public static bool TreeExists(int right, string path)
		{
			while (path.Length < right)
			{
				path += path;
			}
			return path[right] == '#';
		}

		//static void Main(string[] args)
		//{
		//    string line;
		//    var    validPasswords = 0;
		//    var    file           = new System.IO.StreamReader(@"input.txt");
		//    var    pathToright    = 0;
		//    var    trees          = 0;
		//    while ((line = file.ReadLine()) != null)
		//    {
		//        if (pathToright != 0)
		//        {
		//            while (line.Length < pathToright)
		//            {
		//                line = line + line;
		//            }
		//            if (line[pathToright] == '#')
		//                trees++;
		//        }

		//        pathToright = pathToright + 3;
		//    }
		//    Console.WriteLine(trees);
		//}
	}
}

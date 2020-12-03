using System;
using System.IO;

namespace day3
{
    public class Program
    {

        static void Main(string[] args)
        {
            string line;
            var    validPasswords = 0;
            var    file           = new System.IO.StreamReader(@"input.txt");
            var    pathToright1   = 0;
            var    pathToright3   = 0;
            var    pathToright5   = 0;
            var    pathToright7   = 0;
            var    pathToright12   = 1;

            long trees1 = 0;
            long trees3 = 0;
            long trees5 = 0;
            long trees7 = 0;
            long trees2 = 0;

            var lineCount = 1;

            while ((line = file.ReadLine()) != null)
            {
                if (pathToright1 != 0)
                {
                    while (line.Length < pathToright7)
                    {
                        line = line + line;
                    }
                    if (line[pathToright1] == '#')
                        trees1++;
                    if (line[pathToright3] == '#')
                        trees3++;
                    if (line[pathToright5] == '#')
                        trees5++;
                    if (line[pathToright7] == '#')
                        trees7++;
                    if (lineCount % 2 ==1)
                    {
                        if(line[pathToright12] == '#')
                            trees2++;
                        pathToright12 = pathToright12 + 1;
                    }
                }

                lineCount++;
                pathToright1 = pathToright1 + 1;
                pathToright3 = pathToright3 + 3;
                pathToright5 = pathToright5 + 5;
                pathToright7 = pathToright7 + 7;
            }

            long result = trees1 * trees2 * trees3 * trees5 * trees7;
            Console.WriteLine(result);
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

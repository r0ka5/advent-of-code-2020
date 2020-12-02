using System;
using System.Collections.Generic;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader file = new System.IO.StreamReader("input.txt");
            string line;

            var inputList = new List<int>();
            while ((line = file.ReadLine()) != null)
            {
                inputList.Add(Int32.Parse(line));
            }

            foreach (var item in inputList)
            {
                foreach (var item2 in inputList)
                {
                    foreach (var item3 in inputList)
                    {
                        var result = item + item2 + item3;
                        if (result == 2020)
                        {
                            Console.WriteLine(item * item2 * item3);
                            Console.ReadLine();
                        }
                    }
                }
            }
        }
    }
}

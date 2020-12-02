using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace password
{
    public static class MainClass
    {
        public static void ExecuteProgram()
        {
            string line;
            var    validPasswords = 0;
            var    file           = new System.IO.StreamReader(@"input.txt");
            while ((line = file.ReadLine()) != null)
            {
                var result   = Regex.Split(line, @"(-|:|\s)", RegexOptions.IgnoreCase);
                var min      = int.Parse(result[0]);
                var max      = int.Parse(result[2]);
                var letter   = result[4];
                var password = result[8];
                if (isValid2ndRule(min, max, letter, password))
                {
                    validPasswords++;
                }
            }

            Console.WriteLine(validPasswords);
        }

        public static bool isValid2ndRule(int position1, int position2, string letter, string password)
        {
            return (letter.Contains(password[position1 - 1]) ^ letter.Contains(password[position2 - 1]));
        }

        public static bool isValid(int min, int max, string letter, string password)
        {
            var letterCount = password.Count(letter.Contains);

            return (letterCount >= min && letterCount <= max);
        }
    }
}

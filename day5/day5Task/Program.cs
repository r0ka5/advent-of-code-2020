using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace day5Task
{
    class Program
    {
        static void Main(string[] args)
        {
	        string line;
			int?[] places = new int?[1024];
	        var    file  = new System.IO.StreamReader(@"input.txt");
	        while ((line = file.ReadLine()) != null)
	        {
		        var seatId = GetSeatId(line);
		        places[seatId] = seatId;
	        }

	        for (int i = 1; i < places.Length; i++)
	        {
		        if (places[i] == null && places[i - 1] != null && places[i + 1] != null)
		        {
			        Console.WriteLine(i);
			        break;
		        }
	        }
	        Console.ReadLine();
        }

        private static int GetSeatId(string passport)
        {
	        passport = passport.Replace("F", "0");
			passport = passport.Replace("L", "0");
			passport = passport.Replace("B", "1");
			passport = passport.Replace("R", "1");

			var row =passport.Substring(0, 7);
			
			var col =  passport.Substring(7, 3);
			var rowInt=Convert.ToInt32(row, 2);
			var colInt= Convert.ToInt32(col, 2);

	        var seatId = 8 * rowInt + colInt;
			return seatId;
        }
    }
}

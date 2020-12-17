using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace day11Task
{
    public static class RulesEngine
    {
	    public static List<List<char>> ApplyRules(List<List<char>> layout)
	    {
			var newLayout = new List<List<char>>();
			for (var indexRow = 0; indexRow < layout.Count; indexRow++)
			{
				var layoutApl = layout[indexRow];
				newLayout.Add(new List<char>());
				for (var l=0; l<layoutApl.Count; l++)
				{
					var value    = layoutApl[l];
					var occupied = GetVisibleOccupiedSeatsCount(layout, indexRow, l);
					if (value == 'L' && occupied == 0)
					{
						newLayout[indexRow].Add('#');
					}
					else if (value == '#' && occupied >= 5)
					{
						newLayout[indexRow].Add('L');
					}
					else
					{
						newLayout[indexRow].Add(value);
					}
				}
			}
			return newLayout;
	    }

	    public static int GetVisibleOccupiedSeatsCount(List<List<char>> layout, int indexRow, int indexCollumn)
	    {
		    var counter = 0;
		    var a       = 1;
			    while (true)
			    {
				    try
				    {
					    if (layout[indexRow][indexCollumn + a] == '#')
					    {
						    counter++;
						    break;
					    }
					    if (layout[indexRow][indexCollumn + a] == 'L')
					    {
						    break;
					    }
				}
				    catch
				    {
					    break;
				    }

				    a++;
			    }
			    var b = 1;
			    while (true)
			    {
                try
                {
                    if (layout[indexRow][indexCollumn - b] == '#')
                    {
                        counter++;
                        break;
                    }
                    if (layout[indexRow][indexCollumn - b] == 'L')
                    {
	                    break;
                    }
				}
                catch (Exception)
                {
	                break;
                }
				    b++;
			    }

			    var c = 1;
			    while (true)
			    {
                try
                {
                    if (layout[indexRow + c][indexCollumn] == '#')
                    {
                        counter++;
                        break;
                    }
                    if (layout[indexRow + c][indexCollumn] == 'L')
                    {
	                    break;
                    }
				}
                catch (Exception)
                {

	                break;
                }
				    c++;
			    }

			    var d = 1;
			    while (true)
			    {
                try
                {
                    if (layout[indexRow - d][indexCollumn] == '#')
                    {
                        counter++;
                        break;
                    }
                    if (layout[indexRow - d][indexCollumn] == 'L')
                    {
	                    break;
                    }
				}
                catch (Exception)
                {

	                break;
                }
				    d++;
			    }

			    var e = 1;
			    while (true)
			    {
                try
                {
                    if (layout[indexRow + e][indexCollumn + e] == '#')
                    {
                        counter++;
                        break;
                    }
                    if (layout[indexRow + e][indexCollumn + e] == 'L')
                    {
	                    break;
                    }
				}
                catch (Exception)
                {

                    break;
                }
				    e++;
			    }

			    var f = 1;
			    while (true)
			    {
                try
                {
                    if (layout[indexRow - f][indexCollumn - f] == '#')
                    {
                        counter++;
                        break;
                    }
                    if (layout[indexRow - f][indexCollumn - f] == 'L')
                    {
	                    break;
                    }
				}
                catch (Exception)
                {

                    break;
                }
				    f++;
			    }

			    var g = 1;
			    while (true)
			    {
                try
                {
                    if (layout[indexRow + g][indexCollumn - g] == '#')
                    {
                        counter++;
                        break;
                    }
                    if (layout[indexRow + g][indexCollumn - g] == 'L')
                    {
	                    break;
                    }
				}
                catch (Exception)
                {

                    break;
                }
				    g++;
			    }

			    var h = 1;
			    while (true)
			    {
                try
                {
                    if (layout[indexRow - h][indexCollumn + h] == '#')
                    {
                        counter++;
                        break;
                    }
                    if (layout[indexRow - h][indexCollumn + h] == 'L')
                    {
	                    break;
                    }
				}
                catch (Exception)
                {

                    break;
                }
				    h++;
			    }

			    return counter;
	    }

		private static int GetAdjacentOccupiedSeatsCount(List<List<char>> layout, int indexRow, int indexCollumn)
	    {
		    var counter = 0;
		    for (int i = indexRow > 0 ? indexRow - 1 : 0; i <= indexRow + 1 && i <= layout.Count-1; i++)
		    {
			    for (int c = indexCollumn > 0 ? indexCollumn - 1 : 0;
				    c <= indexCollumn + 1 && c <= layout[i].Count-1;
				    c++)
			    {
				    if ((i!=indexRow || c!=indexCollumn) && layout[i][c] == '#')
					    counter++;
			    }

		    }

		    return counter;
	    }

	    public static bool AreEqual(List<List<char>> layout, List<List<char>> layoutExpected)
	    {
		    foreach (var layou in layout)
		    {
			    var index = layout.IndexOf(layou);
			    var equal =layoutExpected[index].SequenceEqual(layou);
			    if (!equal)
				    return false;
		    }

		    return true;
	    }

	    public static int GetOccupiedCount(List<List<char>> layout)
	    {
		    var counter = 0;
		    foreach (var la in layout)
		    {
			    foreach (var l in la)
			    {
				    if (l == '#')
					    counter++;
			    }
		    }

		    return counter;
	    }
	}
}

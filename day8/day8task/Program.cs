using System;
using System.Collections.Generic;
using System.Linq;

namespace day8task
{
	class Program
	{
		static void Main(string[] args)
		{
			string line;
			var    file         = new System.IO.StreamReader(@"input.txt");
			var    instructions = new List<Instruction>();
			while ((line = file.ReadLine()) != null)
			{
				instructions.Add(Parser.Parse(line));
			}

			foreach (var instruction in instructions.Where(x => x.Action == Action.nop || x.Action == Action.jmp))
			{
				switch (instructions[instructions.IndexOf(instruction)].Action)
				{
					case Action.jmp:
						instructions[instructions.IndexOf(instruction)].Action = Action.nop;
						break;
					case Action.nop:
						instructions[instructions.IndexOf(instruction)].Action = Action.jmp;
						break;
				}

				var success      = false;
				int accumulator  = 0;
				int index        = 0;
				var indexTouched = new List<int>();
				while (true)
				{
					if (index >= instructions.Count)
					{
						success = true;
						break;
					}

					if (indexTouched.Exists(x => x == index))
					{
						break;
					}

					indexTouched.Add(index);
					switch (instructions[index].Action)
					{
						case Action.jmp:
							index += instructions[index].Points;
							break;
						case Action.acc:
							accumulator += instructions[index].Points;
							index++;
							break;
						case Action.nop:
							index++;
							break;
					}
				}

				if (success)
				{
					Console.WriteLine(accumulator);
					break;
				}
				else
				{
					switch (instructions[instructions.IndexOf(instruction)].Action)
					{
						case Action.jmp:
							instructions[instructions.IndexOf(instruction)].Action = Action.nop;
							break;
						case Action.nop:
							instructions[instructions.IndexOf(instruction)].Action = Action.jmp;
							break;
					}
				}
			}
		}
	}
}
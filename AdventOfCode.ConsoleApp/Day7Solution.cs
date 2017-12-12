using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.ConsoleApp
{
    public class Day7Solution
    {
        public static void Run()
        {
            string input;
            using (var reader = new StreamReader("day7input.txt"))
            {
                input = reader.ReadToEnd();
            }

            var rows = input.Split(new[] {"\r", "\n"}, StringSplitOptions.RemoveEmptyEntries);
            var programs = new Dictionary<string, Day07.Program>();
            foreach (var row in rows)
            {
                var program = Day07.Program.Parse(row);
                programs.Add(program.Name, program);
            }
            foreach (var program in programs)
            {
                if (program.Value.HasChildren)
                {
                    foreach (var child in program.Value.ChildrenNames)
                    {
                        programs[child].Parent = program.Value;
                        program.Value.Children.Add(programs[child]);
                    }
                }
            }

            var root = programs.FirstOrDefault(p => p.Value.Parent == null).Value;
            foreach (var child in root.Children)
            {
                Console.WriteLine($"{child.Name} {child.Weight} {child.GetWeight()}");
            }
        }
    }
}

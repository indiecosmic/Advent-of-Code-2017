using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day07 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 7");
            var input = GetInput();

            var rows = input.Split(new[] {"\r", "\n"}, StringSplitOptions.RemoveEmptyEntries);
            var programs = new Dictionary<string, AdventOfCode.Day07.Program>();
            foreach (var row in rows)
            {
                var program = AdventOfCode.Day07.Program.Parse(row);
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
            Console.WriteLine($"Root name: {root.Name}");

            var unBalancedChild = root.Children.GroupBy(c => c.GetWeight()).FirstOrDefault(c => c.Count() == 1).FirstOrDefault();


            foreach (var child in unBalancedChild.Children)
            {
                Console.WriteLine($"{child.Name} {child.Weight} {child.GetWeight()}");
            }
        }
    }
}

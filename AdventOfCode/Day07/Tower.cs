using System;
using System.Linq;

namespace AdventOfCode.Day07
{
    public class Tower
    {
        public Program Root { get; }

        private Tower(Program root)
        {
            Root = root;
        }

        public static Tower Parse(string input)
        {
            var rows = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var programs = rows.Select(Program.Parse).ToDictionary(program => program.Name);
            foreach (var program in programs.Where(p => p.Value.HasChildren))
            {
                foreach (var child in program.Value.ChildrenNames)
                {
                    programs[child].Parent = program.Value;
                    program.Value.Children.Add(programs[child]);
                }
            }
            return new Tower(programs.FirstOrDefault(p => p.Value.Parent == null).Value);
        }

        public Program FindUnbalancedProgram()
        {
            return FindUnbalancedProgram(Root);
        }

        private static Program FindUnbalancedProgram(Program parent)
        {
            foreach (var child in parent.Children)
            {
                if (!child.IsBalanced)
                {
                    return FindUnbalancedProgram(child);
                }
            }
            return parent;
        }
    }
}

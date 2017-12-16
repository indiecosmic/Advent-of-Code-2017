using System;
using System.Linq;
using AdventOfCode.Day07;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day07 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 7");
            var input = GetInput();
            var tower = Tower.Parse(input);

            Console.WriteLine("Part 1");
            Console.WriteLine($"Root name: {tower.Root.Name}");

            Console.WriteLine("Part 2");
            var unbalanced = tower.FindUnbalancedProgram();
            var children = unbalanced.Children.GroupBy(c => c.TotalWeight);
            var oddChild = children.First(c => c.Count() == 1).First();
            var weightDiff = oddChild.TotalWeight - unbalanced.Children.First(c => c.TotalWeight != oddChild.TotalWeight).TotalWeight;
            var result = weightDiff > 0 ? oddChild.Weight - weightDiff : oddChild.Weight + weightDiff;
            Console.WriteLine($"Weight need to be: {result}");
        }
    }
}

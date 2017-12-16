using System;
using AdventOfCode.Day03;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day03 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 3");

            Console.WriteLine("Part 1");
            var calc = new ManhattanDistance(new SequenceWriter());
            Console.WriteLine($"Distance: {calc.CalculateSteps(368078)}");

            Console.WriteLine("Part 2");
            calc = new ManhattanDistance(new SumAdjacent());
            Console.WriteLine($"First Value: {calc.FindFirstValueLargerThanInput(368078)}");
            Console.WriteLine();
        }
    }
}

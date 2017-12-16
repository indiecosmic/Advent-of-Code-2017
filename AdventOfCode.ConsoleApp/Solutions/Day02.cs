using System;
using AdventOfCode.Day02;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day02 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 2");
            var input = GetInput();

            Console.WriteLine("Part 1");
            var calculator = new ChecksumCalculator(new MinMaxDiff());
            var result = calculator.Calculate(input);

            Console.WriteLine($"Result: {result}");

            Console.WriteLine("Part 2");
            calculator = new ChecksumCalculator(new EvenDivisible());
            result = calculator.Calculate(input);

            Console.WriteLine($"Result: {result}");
            Console.WriteLine();
        }
    }
}

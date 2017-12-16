using System;
using System.Linq;
using AdventOfCode.Day16;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day16 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 16");

            var input = GetInput();

            var startPositions = "abcdefghijklmnop".ToArray();
            var dance = Dance.Parse(input);

            Console.WriteLine("Part 1");

            var result = dance.Run(startPositions);
            Console.WriteLine($"Result: {new string(result)}");

            Console.WriteLine("Part 2");

            result = dance.Run(startPositions, 1000000000);

            Console.WriteLine($"Result: {new string(result)}");
        }



    }
}

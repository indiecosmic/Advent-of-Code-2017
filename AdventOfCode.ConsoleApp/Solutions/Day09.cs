using System;
using AdventOfCode.Day09;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day09 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 9");
            var input = GetInput();

            var processor = new StreamProcessor();
            var groups = processor.FindGroups(input);
            var count = processor.CountCharactersInsideGarbage(input);
            Console.WriteLine($"Total score: {groups.GetScore()}");
            Console.WriteLine($"Characters inside garbage: {count}");
        }
    }
}

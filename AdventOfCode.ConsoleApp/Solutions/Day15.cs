using System;
using AdventOfCode.Day15;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day15
    {
        public void Run()
        {
            Console.WriteLine("Day 15");
            const int aFactor = 16807;
            const int bFactor = 48271;

            Console.WriteLine("Part 1");

            var generatorA = new Generator(aFactor, 591);
            var generatorB = new Generator(bFactor, 393);
            var result = Judge.JudgePairs(generatorA, generatorB, 40000000);
            Console.WriteLine($"Result: {result}");

            Console.WriteLine("Part 2");

            generatorA = new Generator(aFactor, 591, true, 4);
            generatorB = new Generator(bFactor, 393, true, 8);
            result = Judge.JudgePairs(generatorA, generatorB, 5000000);
            Console.WriteLine($"Result: {result}");
        }
    }
}

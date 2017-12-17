using System;
using AdventOfCode.Day17;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day17 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 17");

            var spinlock = new Spinlock();
            const int input = 348;

            Console.WriteLine("Part 1");
            var result = spinlock.Repeat(2017, input);

            Console.WriteLine($"Result {result}");

            Console.WriteLine("Part 2");
            result = new Spinlock().RepeatAndReturnValueAt1(50000000, input);
            Console.WriteLine($"Result {result}");
        }
    }
}

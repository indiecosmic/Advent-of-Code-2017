using System;
using AdventOfCode.Day03;

namespace AdventOfCode.ConsoleApp
{
    public class Day03Solution
    {
        public static void Run()
        {
            var calc = new ManhattanDistance(new SequenceWriter());

            Console.WriteLine($"Distance: {calc.CalculateSteps(368078)}");

            calc = new ManhattanDistance(new SumAdjacent());
            Console.WriteLine($"First Value: {calc.FindFirstValueLargerThanInput(368078)}");
        }
    }
}

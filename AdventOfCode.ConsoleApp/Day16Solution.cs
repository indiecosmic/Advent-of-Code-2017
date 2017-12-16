using System;
using System.IO;
using System.Linq;
using AdventOfCode.Day16;

namespace AdventOfCode.ConsoleApp
{
    public static class Day16Solution
    {
        public static void Run()
        {
            Console.WriteLine("Day 16");

            string input;
            using (var reader = new StreamReader("day16input.txt"))
            {
                input = reader.ReadToEnd();
            }
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

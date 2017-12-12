using System;
using System.IO;
using AdventOfCode.Day09;

namespace AdventOfCode.ConsoleApp
{
    public static class Day09Solution
    {
        public static void Run()
        {
            string input;
            using (var reader = new StreamReader("day09input.txt"))
            {
                input = reader.ReadToEnd().Trim();
            }

            var processor = new StreamProcessor();
            var groups = processor.FindGroups(input);
            var count = processor.CountCharactersInsideGarbage(input);
            Console.WriteLine($"Total score: {groups.GetScore()}");
            Console.WriteLine($"Characters inside garbage: {count}");
        }
    }
}

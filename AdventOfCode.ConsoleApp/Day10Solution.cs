using System;
using System.Linq;
using AdventOfCode.Day10;

namespace AdventOfCode.ConsoleApp
{
    public class Day10Solution
    {
        public static void Run()
        {
            var numbers = new int[256];
            for (var i = 0; i < numbers.Length; i++)
                numbers[i] = i;

            const string input = "129,154,49,198,200,133,97,254,41,6,2,1,255,0,191,108";
            var lengths = input.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(i => Convert.ToInt32(i)).ToArray();
            var knotHash = new KnotHash(new ListReverser());

            var result = knotHash.Calculate(numbers, lengths);
            Console.WriteLine($"Result: {result}");

            var hex = knotHash.Calculate(input);

            Console.WriteLine($"Knot hash: {hex}");
        }
        
    }
}

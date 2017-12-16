using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Day06;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day06 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 6");
            var initialState = new[] { 14, 0, 15, 12, 11, 11, 3, 5, 1, 6, 8, 4, 9, 1, 8, 4 };

            var history = new List<int[]>();
            var memoryBank = new MemoryBank(initialState);
            var seenBefore = false;
            var count = 0;
            while (!seenBefore)
            {
                var currentState = memoryBank.GetState();
                if (history.Exists(s => s.SequenceEqual(currentState)))
                {
                    seenBefore = true;
                    var index = history.FindIndex(s => s.SequenceEqual(currentState));
                    Console.WriteLine($"Number of cycles: {count - index}");
                }
                else
                {
                    history.Add(currentState);
                }
                memoryBank.Redistribute();
                count++;
            }

            Console.WriteLine($"Number of operations: {history.Count}");
        }
    }
}

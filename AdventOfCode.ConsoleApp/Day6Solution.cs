using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day6;

namespace AdventOfCode.ConsoleApp
{
    public class Day6Solution
    {
        public static void Run()
        {
            var initialState = new[] { 14,0,15,12,11,11,3,5,1,6,8,4,9,1,8,4 };
            //var initialState = new[] { 0,2,7,0 };
            var history = new List<int[]>();
            var memoryBank = new MemoryBank(initialState);
            var seenBefore = false;
            while (!seenBefore)
            {
                var currentState = memoryBank.GetState();
                if (history.Exists(s => s.SequenceEqual(currentState)))
                {
                    seenBefore = true;
                    var index = history.FindIndex(s => s.SequenceEqual(currentState));
                    Console.WriteLine($"Found in index {index}");
                }
                else
                {
                    history.Add(currentState);
                    
                }
                memoryBank.Redistribute();
            }

            Console.WriteLine($"Number of operations: {history.Count}");
        }
    }
}

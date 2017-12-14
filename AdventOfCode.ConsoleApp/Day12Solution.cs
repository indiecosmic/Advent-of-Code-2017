using System;
using System.IO;
using AdventOfCode.Day12;

namespace AdventOfCode.ConsoleApp
{
    public class Day12Solution
    {
        public static void Run()
        {
            Console.WriteLine("Day 12");
            string input;
            using (var reader = new StreamReader("day12input.txt"))
            {
                input = reader.ReadToEnd();
            }
            var pipeSystem = PipeSystem.Parse(input);
            var programs = pipeSystem.FindProgramsInGroup(0);
            Console.WriteLine($"Number of programs: {programs.Length}");
            var count = pipeSystem.FindTotalNumberOfGroups();
            Console.WriteLine($"Number of groups: {count}");
        }
    }
}

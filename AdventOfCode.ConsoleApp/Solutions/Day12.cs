using System;
using AdventOfCode.Day12;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day12 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 12");
            var input = GetInput();

            var pipeSystem = PipeSystem.Parse(input);
            var programs = pipeSystem.FindProgramsInGroup(0);
            Console.WriteLine($"Number of programs: {programs.Length}");
            var count = pipeSystem.FindTotalNumberOfGroups();
            Console.WriteLine($"Number of groups: {count}");
        }
    }
}

using System;
using System.IO;
using System.Linq;
using AdventOfCode.Day05;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day05 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 5");
            var input = GetInput();
            var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var initialState = lines.Select(l => Convert.ToInt32(l)).ToArray();

            Console.WriteLine("Part 1");
            var maze = new Maze(initialState, new SimpleOffsetRule());
            var count = 1;
            while(maze.Jump())
            {
                count++;
            }
            Console.WriteLine($"Steps until exit: {count}");

            Console.WriteLine("Part 2");
            maze = new Maze(initialState, new ComplexOffsetRule());
            count = 1;
            while (maze.Jump())
            {
                count++;
            }
            Console.WriteLine(count);
        }
    }
}

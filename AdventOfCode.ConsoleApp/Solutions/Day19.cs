using System;
using AdventOfCode.Day19;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day19 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 19");
            var input = GetInput(false);

            var maze = Maze.Parse(input);
            while (true)
            {
                if (maze.AtFinish())
                    break;

                if (maze.CanMove())
                    maze.Move();
                else
                {
                    maze.Turn();
                }
            }

            Console.WriteLine($"Result {maze.Letters}, {maze.Count} steps");
        }
    }
}

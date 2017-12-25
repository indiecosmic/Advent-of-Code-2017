using System;
using System.Collections.Generic;
using AdventOfCode.Day22;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day22 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 22");
            var input = GetInput();

            Console.WriteLine("Part 1");
            var map = Map.Parse(input);
            var position = (0, 0);
            var direction = (0, 1);
            var virus = new Virus(position, direction);
            for (var i = 0; i < 10000; i++)
            {
                map = virus.Work(map);
            }
            Console.WriteLine($"Result: {virus.InfectionCount}");


        }
        
    }
}

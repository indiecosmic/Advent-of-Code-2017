using System;
using AdventOfCode.Day11;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day11 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 11");
            var input = GetInput();

            var calculator = new CubeCoordinates();
            var fewestNumberOfSteps = calculator.CalculateFewestNumberOfSteps(input);
            Console.WriteLine($"Steps needed: {fewestNumberOfSteps}");

            var furthestDistance = calculator.CalculateFurthestDistance(input);
            Console.WriteLine($"Furthest distance: {furthestDistance}");
        }
    }
}

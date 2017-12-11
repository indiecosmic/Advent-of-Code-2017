using System;
using System.IO;
using AdventOfCode.Day11;

namespace AdventOfCode.ConsoleApp
{
    public static class Day11Solution
    {
        public static void Run()
        {
            string input;
            using (var reader = new StreamReader("day11input.txt"))
            {
                input = reader.ReadToEnd();
            }
            var calculator = new CubeCoordinates();
            var fewestNumberOfSteps = calculator.CalculateFewestNumberOfSteps(input);
            Console.WriteLine($"Steps needed: {fewestNumberOfSteps}");

            var furthestDistance = calculator.CalculateFurthestDistance(input);
            Console.WriteLine($"Furthest distance: {furthestDistance}");
        }
    }
}

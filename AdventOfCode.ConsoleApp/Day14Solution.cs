﻿using System;
using AdventOfCode.Day14;

namespace AdventOfCode.ConsoleApp
{
    public class Day14Solution
    {
        public static void Run()
        {
            Console.WriteLine("Day 14");
            Console.WriteLine("Part 2");
            var diskDefragmenter = new DiskDefragmenter();
            var input = "ljoxqyyw";
            var usedSquares = diskDefragmenter.CalculateNumberOfUsedSquares(input);

            Console.WriteLine($"Used squares: {usedSquares}");

            Console.WriteLine("Part 2");
            var regions = diskDefragmenter.CalculateNumberOfRegions(input);

            Console.WriteLine($"Number of regions: {regions}");
        }
    }
}

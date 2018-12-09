using System;
using System.Collections.Generic;

namespace AdventOfCode.Day21
{
    public class EnhancementRule
    {
        public int InputSize { get; }

        public int OutputSize { get; }
        private readonly List<char[,]> _patterns;
        private readonly char[,] _output;

        private EnhancementRule(int inputSize, int outputSize, List<char[,]> patterns, char[,] output)
        {
            _patterns = patterns;
            _output = output;
            InputSize = inputSize;
            OutputSize = outputSize;
        }

        public static EnhancementRule Parse(string input)
        {
            var parts = input.Split(new[] { " ", "=>" }, StringSplitOptions.RemoveEmptyEntries);
            var inputPattern = parts[0].Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

            var patterns = new List<char[,]>();
            var pattern = BuildPattern(inputPattern);
            patterns.Add(pattern);
            patterns.Add(Flip(pattern));
            var rotated = Rotate(pattern, inputPattern.Length);
            patterns.Add(rotated);
            patterns.Add(Flip(rotated));
            rotated = Rotate(rotated, inputPattern.Length);
            patterns.Add(rotated);
            patterns.Add(Flip(rotated));
            rotated = Rotate(rotated, inputPattern.Length);
            patterns.Add(rotated);
            patterns.Add(Flip(rotated));

            var outputPattern = parts[1].Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            var output = BuildPattern(outputPattern);

            return new EnhancementRule(inputPattern.Length, outputPattern.Length, patterns, output);
        }

        private static char[,] BuildPattern(string[] input)
        {
            var pattern = new char[input.Length, input.Length];
            for (var row = 0; row < input.Length; row++)
            {
                for (var col = 0; col < input.Length; col++)
                {
                    pattern[col, row] = input[col][row];
                }
            }
            return pattern;
        }

        public bool Matches(Grid grid)
        {
            if (grid.Pixels.GetLength(0) != InputSize) return false;

            foreach (var pattern in _patterns)
            {
                if (IsMatch(pattern, grid.Pixels, InputSize))
                    return true;
            }

            return false;
        }

        private static bool IsMatch(char[,] source, char[,] target, int size)
        {
            for (var row = 0; row < size; row++)
            {
                for (var col = 0; col < size; col++)
                {
                    if (source[col, row] != target[col, row])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private static char[,] Rotate(char[,] matrix, int size)
        {
            var ret = new char[size, size];

            for (var i = 0; i < size; ++i)
            {
                for (var j = 0; j < size; ++j)
                {
                    ret[i, j] = matrix[size - j - 1, i];
                }
            }
            return ret;
        }

        private static char[,] Flip(char[,] arrayToFlip)
        {
            var rows = arrayToFlip.GetLength(0);
            var columns = arrayToFlip.GetLength(1);
            var flippedArray = new char[rows, columns];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    flippedArray[i, j] = arrayToFlip[(rows - 1) - i, j];
                }
            }
            return flippedArray;
        }

        public Grid Enhance(Grid grid)
        {
            if (!Matches(grid)) throw new ArgumentException("Grid is not matching");

            var result = new char[OutputSize, OutputSize];
            for (var x = 0; x < OutputSize; x++)
            {
                for (var y = 0; y < OutputSize; y++)
                {
                    result[x, y] = _output[x, y];
                }
            }

            return new Grid(result);
        }
    }
}

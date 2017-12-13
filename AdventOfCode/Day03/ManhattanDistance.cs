using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day03
{
    public class ManhattanDistance
    {
        private readonly IMemoryWriter _memoryWriter;

        public ManhattanDistance(IMemoryWriter memoryWriter)
        {
            _memoryWriter = memoryWriter;
        }

        public int CalculateSteps(int fromSquare)
        {
            var spiralSize = (int)Math.Ceiling(Math.Sqrt(fromSquare));
            if (spiralSize % 2 == 0) spiralSize++;

            var spiral = GenerateSpiral(spiralSize);
            var location = spiral.FirstOrDefault(s => s.Value == fromSquare);

            return Math.Abs(location.Key.Item1) + Math.Abs(location.Key.Item2);
        }

        public int FindFirstValueLargerThanInput(int input)
        {
            var spiralSize = (int)Math.Ceiling(Math.Sqrt(input));
            if (spiralSize % 2 == 0) spiralSize++;

            var spiral = GenerateSpiral(spiralSize);
            return spiral.Values.Max();
        }

        public Dictionary<(int, int), int> GenerateSpiral(int size)
        {
            var dict = new Dictionary<(int, int), int>();

            var x = 0;
            var y = 0;
            dict[(x, y)] = 1;

            if (size == 1) return dict;

            var inc = 1;
            var dir = 1;
            var mem = 1;
            for (; ; )
            {
                for (var i = 1; i < inc + 1; i++)
                {
                    mem++;
                    x = (dir == 1) ? x + 1 : (dir == 3) ? x - 1 : x;
                    y = (dir == 2) ? y - 1 : (dir == 4) ? y + 1 : y;
                    var result = _memoryWriter.Write(dict, (x,y), mem );
                    if (result >= size * size) return dict;
                }
                dir = (dir == 4) ? 1 : dir + 1;
                if ((dir == 1) || (dir == 3)) inc++;
            }
        }

    }
}

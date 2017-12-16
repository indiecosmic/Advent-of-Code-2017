using System.Collections.Generic;

namespace AdventOfCode.Day03
{
    public interface IMemoryWriter
    {
        int Write(Dictionary<(int, int), int> grid, (int, int) location, int sequence);
    }

    public class SequenceWriter : IMemoryWriter
    {
        public int Write(Dictionary<(int, int), int> grid, (int, int) location, int sequence)
        {
            grid[(location.Item1, location.Item2)] = sequence;
            return sequence;
        }
    }

    public class SumAdjacent : IMemoryWriter
    {
        public int Write(Dictionary<(int, int), int> grid, (int, int) location, int sequence)
        {
            var sum = 0;
            for (var x = location.Item1 - 1; x <= location.Item1 + 1; x++)
            {
                for (var y = location.Item2 - 1; y <= location.Item2 + 1; y++)
                {
                    if (x == location.Item1 && y == location.Item2) continue;
                    if (grid.ContainsKey((x, y))) sum += grid[(x, y)];
                }
            }
            grid[location] = sum;
            return sum;
        }
    }
}

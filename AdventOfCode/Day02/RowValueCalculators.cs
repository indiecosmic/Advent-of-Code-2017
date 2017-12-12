using System;
using System.Linq;

namespace AdventOfCode.Day02
{
    public interface IRowValueCalculator
    {
        int Calculate(int[] row);
    }
    public class MinMaxDiff : IRowValueCalculator
    {
        public int Calculate(int[] row)
        {
            return row.Max() - row.Min();
        }
    }

    public class EvenDivisible : IRowValueCalculator
    {
        public int Calculate(int[] row)
        {
            for (var i = 0; i < row.Length; i++)
            {
                for (var j = 0; j < row.Length; j++)
                {
                    if (i == j) continue;
                    if (row[i] % row[j] != 0) continue;
                    var max = Math.Max(row[i], row[j]);
                    var min = Math.Min(row[i], row[j]);
                    return max / min;
                }
            }
            return 0;
        }
    }
}

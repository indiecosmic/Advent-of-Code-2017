using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day02
{
    public class ChecksumCalculator
    {
        private readonly IRowValueCalculator _rowValueCalculator;

        public ChecksumCalculator(IRowValueCalculator rowValueCalculator)
        {
            _rowValueCalculator = rowValueCalculator;
        }

        public int Calculate(string input)
        {
            var rows = ParseInputRows(input);
            var sum = 0;
            foreach (var row in rows)
            {
                sum += _rowValueCalculator.Calculate(row);
            }
            return sum;
        }

        private static IEnumerable<int[]> ParseInputRows(string input)
        {
            var rows = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return rows.Select(ParseRow).ToList();
        }

        private static int[] ParseRow(string row)
        {
            var numbers = row.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return numbers.Select(number => Convert.ToInt32(number)).ToArray();
        }
    }
}

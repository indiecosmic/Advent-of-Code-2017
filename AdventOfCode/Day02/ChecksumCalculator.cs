using System;
using System.Collections.Generic;

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

        private IList<int[]> ParseInputRows(string input)
        {
            var rows = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var result = new List<int[]>();
            foreach (var row in rows)
            {
                result.Add(ParseRow(row));
            }
            return result;
        }

        private int[] ParseRow(string row)
        {
            var numbers = row.Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
            var results = new List<int>();
            foreach (var number in numbers)
            {
                results.Add(Convert.ToInt32(number));
            }
            return results.ToArray();
        }
    }
}

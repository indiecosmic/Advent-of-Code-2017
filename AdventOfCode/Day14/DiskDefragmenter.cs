using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day10;

namespace AdventOfCode.Day14
{
    public class DiskDefragmenter
    {
        private readonly KnotHash _knotHash;

        public DiskDefragmenter()
        {
            _knotHash = new KnotHash(new ListReverser());
        }

        public IEnumerable<byte[]> CreateGrid(string input)
        {
            var grid = new List<byte[]>();
            for (var i = 0; i < 128; i++)
            {
                var key = $"{input}-{i}";
                var knotHash = _knotHash.Calculate(key);
                var gridRow = ConvertHexStringToBinaryArray(knotHash);
                grid.Add(gridRow);
            }
            return grid;
        }

        public int CalculateNumberOfUsedSquares(string input)
        {
            var grid = CreateGrid(input);
            return grid.Sum(row => row.Sum(square => square));
        }

        private byte[] ConvertHexStringToBinaryArray(string input)
        {
            var result = new List<byte>();
            for (var i = 0; i < input.Length; i++)
            {
                var binary = ConvertToBinary(input.Substring(i, 1));
                result.AddRange(binary);
            }

            return result.ToArray();
        }

        private byte[] ConvertToBinary(string s)
        {
            var num = Convert.ToByte(s, 16);
            var binaryString = Convert.ToString(num, 2).PadLeft(4, '0');
            return binaryString.Select(x => byte.Parse($"{x}")).ToArray();
        }
    }
}

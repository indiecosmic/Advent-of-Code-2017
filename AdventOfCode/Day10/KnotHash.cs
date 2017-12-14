using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day10
{
    public class KnotHash
    {
        private ListReverser _reverser;

        public KnotHash(ListReverser reverser)
        {
            _reverser = reverser;
        }

        public int Calculate(int[] numbers, int[] lengths)
        {
            var currentPosition = 0;
            var skipSize = 0;
            for (var i = 0; i < lengths.Length; i++)
            {
                _reverser.Reverse(numbers, currentPosition, lengths[i]);
                currentPosition += lengths[i] + skipSize;
                if (currentPosition > numbers.Length - 1) currentPosition -= numbers.Length;
                skipSize++;
            }

            return numbers[0] * numbers[1];
        }

        public byte[] CalculateSparseHash(byte[] bytes, byte[] lengths)
        {
            var numbers = (byte[])bytes.Clone();
            var currentPosition = 0;
            var skipSize = 0;

            for (var round = 0; round < 64; round++)
            {
                for (var i = 0; i < lengths.Length; i++)
                {
                    _reverser.Reverse(numbers, currentPosition, lengths[i]);
                    currentPosition += lengths[i] + skipSize;
                    while (currentPosition > numbers.Length - 1) currentPosition -= numbers.Length;
                    skipSize++;
                }
            }


            return numbers;
        }

        public byte[] CalculateDenseHash(byte[] bytes)
        {
            List<byte> result = new List<byte>();
            
            for (var i = 0; i < bytes.Length; i += 16)
            {
                byte current = bytes[i];
                for (var j = 1; j < 16; j++)
                {
                    current = (byte) (current ^ bytes[i + j]);
                }
                result.Add(current);
            }
            return result.ToArray();
        }
    }
}

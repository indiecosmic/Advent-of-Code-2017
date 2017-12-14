using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day10
{
    public class KnotHash
    {
        private readonly ListReverser _reverser;

        public KnotHash(ListReverser reverser)
        {
            _reverser = reverser;
        }

        public string Calculate(string input)
        {
            byte[] asciiCodes = Encoding.ASCII.GetBytes(input);
            byte[] suffix = { 17, 31, 73, 47, 23 };
            var lengths = Combine(asciiCodes, suffix);

            var bytes = new byte[256];
            for (var i = 0; i < bytes.Length; i++)
                bytes[i] = (byte)i;

            var sparseHash = CalculateSparseHash(bytes, lengths);
            var denseHash = CalculateDenseHash(sparseHash);
            return ByteArrayToString(denseHash);
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

        private byte[] CalculateSparseHash(byte[] bytes, byte[] lengths)
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

        private byte[] CalculateDenseHash(byte[] bytes)
        {
            var result = new List<byte>();
            
            for (var i = 0; i < bytes.Length; i += 16)
            {
                var current = bytes[i];
                for (var j = 1; j < 16; j++)
                {
                    current = (byte) (current ^ bytes[i + j]);
                }
                result.Add(current);
            }
            return result.ToArray();
        }

        private static byte[] Combine(byte[] first, byte[] second)
        {
            var ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }

        private static string ByteArrayToString(byte[] ba)
        {
            var hex = new StringBuilder(ba.Length * 2);
            foreach (var b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}

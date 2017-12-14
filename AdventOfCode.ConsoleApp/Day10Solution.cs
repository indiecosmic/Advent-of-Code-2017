using System;
using System.Linq;
using System.Text;
using AdventOfCode.Day10;

namespace AdventOfCode.ConsoleApp
{
    public class Day10Solution
    {
        public static void Run()
        {
            var numbers = new int[256];
            for (var i = 0; i < numbers.Length; i++)
                numbers[i] = i;

            var input = "129,154,49,198,200,133,97,254,41,6,2,1,255,0,191,108";
            var lengths = input.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(i => Convert.ToInt32(i)).ToArray();
            var knotHash = new KnotHash(new ListReverser());

            var result = knotHash.Calculate(numbers, lengths);
            Console.WriteLine($"Result: {result}");

            byte[] asciiCodes = Encoding.ASCII.GetBytes(input);
            byte[] suffix = { 17, 31, 73, 47, 23 };
            var byteLengths = Combine(asciiCodes, suffix);

            var bytes = new byte[256];
            for (var i = 0; i < bytes.Length; i++)
                bytes[i] = (byte)i;

            var sparseHash = knotHash.CalculateSparseHash(bytes, byteLengths);
            var denseHash = knotHash.CalculateDenseHash(sparseHash);
            var hex = ByteArrayToString(denseHash);

            Console.WriteLine($"Knot hash: {hex}");
        }

        public static byte[] Combine(byte[] first, byte[] second)
        {
            var ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}

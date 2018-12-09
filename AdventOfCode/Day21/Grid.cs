using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day21
{
    public class Grid
    {
        public char[,] Pixels { get; }

        public Grid(char[,] pixels)
        {
            Pixels = pixels;
        }

        public bool DivisibleBy(int divider)
        {
            return Pixels.GetLength(0) % divider == 0;
        }

        public Grid[] Divide(int divider)
        {
            if (!DivisibleBy(divider))
                throw new ArgumentException($"Grid cannot be divided by {divider}", nameof(divider));

            var pieceCount = Pixels.GetLength(0) / divider;
            var pieceSize = divider;
            var pieces = new List<Grid>();

            for (var rowOffset = 0; rowOffset < pieceCount; rowOffset++)
            {
                for (var colOffset = 0; colOffset < pieceCount; colOffset++)
                {
                    var pixels = new char[pieceSize, pieceSize];

                    for (var row = 0; row < pieceSize; row++)
                    {
                        for (var col = 0; col < pieceSize; col++)
                        {
                            var sourceRow = rowOffset * pieceSize + row;
                            var sourceCol = colOffset * pieceSize + col;
                            pixels[row, col] = Pixels[sourceRow, sourceCol];
                        }
                    }

                    pieces.Add(new Grid(pixels));
                }
            }

            return pieces.ToArray();
        }

        public bool Equals(Grid other)
        {
            if (Pixels.Length != other.Pixels.Length) return false;
            if (Pixels.Rank != other.Pixels.Rank) return false;

            var size = Pixels.GetLength(0);
            for (var row = 0; row < size; row++)
            {
                for (var col = 0; col < size; col++)
                {
                    if (Pixels[row, col] != other.Pixels[row, col]) return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            for (var row = 0; row < Pixels.GetLength(0); row++)
            {
                for (var col = 0; col < Pixels.GetLength(1); col++)
                {
                    str.Append(Pixels[row, col]);
                }
                if (row < Pixels.GetLength(0) - 1)
                    str.Append('/');
            }
            return str.ToString();
        }

        public static Grid Join(Grid[] parts)
        {
            var partSize = parts[0].Pixels.GetLength(0);
            var size = parts.Length * partSize;
            
            var result = new char[size, size];
            for (var x = 0; x < size; x++)
            {
                for (var y = 0; y < size; y++)
                {
                    var part = (x / partSize) * (size / partSize) + y / partSize;
                    result[x, y] = parts[part].Pixels[x % partSize, y % partSize];
                }
            }
            return new Grid(result);
        }
    }
}

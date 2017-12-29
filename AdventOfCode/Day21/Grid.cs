using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day21
{
    public class Grid
    {
        private readonly char[,] _pixels;

        public Grid(char[,] pixels)
        {
            _pixels = pixels;
        }

        public bool DivisibleBy(int divider)
        {
            return _pixels.GetLength(0) % divider == 0;
        }

        public Grid[] Divide(int divider)
        {
            if (!DivisibleBy(divider))
                throw new ArgumentException($"Grid cannot be divided by {divider}", nameof(divider));

            var pieceCount = _pixels.GetLength(0) / divider;
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
                            pixels[row, col] = _pixels[sourceRow, sourceCol];
                        }
                    }

                    pieces.Add(new Grid(pixels));
                }
            }

            return pieces.ToArray();
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            for (var row = 0; row < _pixels.GetLength(0); row++)
            {
                for (var col = 0; col < _pixels.GetLength(1); col++)
                {
                    str.Append(_pixels[row, col]);
                }
                if (row < _pixels.GetLength(0) - 1)
                    str.Append('/');
            }
            return str.ToString();
        }
    }
}

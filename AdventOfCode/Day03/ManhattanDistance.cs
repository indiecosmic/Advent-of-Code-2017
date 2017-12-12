using System;

namespace AdventOfCode.Day03
{
    public class ManhattanDistance
    {
        public int CalculateSteps(int fromSquare)
        {
            var spiralSize = (int)Math.Ceiling(Math.Sqrt(fromSquare));
            if (spiralSize % 2 != 0) spiralSize++;

            var stepsToCenter = (spiralSize - 1) / 2;


            return stepsToCenter;
        }

        public int[,] GenerateSpiral(int size)
        {
            var array = new int[size,size];
            var startPosition = (size-1) / 2;
            var value = 1;
            array[startPosition, startPosition] = value;
            var column = startPosition;
            var row = startPosition;
            var iterationsBeforeTurn = 0;
            var iterationStep = 1;
            var direction = Direction.Right;
            while (value < Math.Pow(size, 2) - 1)
            {
                if (iterationsBeforeTurn == iterationStep)
                {
                    if (direction == Direction.Right) direction = Direction.Up;
                    else if (direction == Direction.Up) direction = Direction.Left;
                    else if (direction == Direction.Left) direction = Direction.Down;
                    else direction = Direction.Right;

                    iterationsBeforeTurn = 0;
                    iterationStep++;
                }

                column += GetDeltaCol(direction);
                row += GetDeltaRow(direction);
                array[column, row] = value;

                iterationsBeforeTurn++;
                value++;
            }

            return array;
        }

        private int GetDeltaCol(Direction direction)
        {
            switch (direction)
            {
                case Direction.Right:
                    return 1;
                case Direction.Left:
                    return -1;
            }
            return 0;
        }

        private int GetDeltaRow(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return -1;
                case Direction.Down:
                    return 1;
            }
            return 0;
        }

        private enum Direction
        {
            Right,
            Up,
            Left,
            Down
        }
    }
}

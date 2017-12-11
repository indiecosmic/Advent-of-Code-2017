using System;
using System.Collections.Generic;

namespace AdventOfCode.Day11
{
    public class AxialCoordinates
    {
        private const string North = "n";
        private const string South = "s";
        private const string NorthWest = "nw";
        private const string NorthEast = "ne";
        private const string SouthWest = "sw";
        private const string SouthEast = "se";

        private Coordinate ApplyStep(string direction, Coordinate location)
        {
            if (location.X % 2 == 0)
            {
                switch (direction)
                {
                    case North:
                        location.Y += 1;
                        break;
                    case South:
                        location.Y -= 1;
                        break;
                    case NorthWest:
                        location.X -= 1;
                        location.Y += 1;
                        break;
                    case NorthEast:
                        location.X += 1;
                        location.Y += 1;
                        break;
                    case SouthWest:
                        location.X -= 1;
                        break;
                    case SouthEast:
                        location.X += 1;
                        break;
                }
            }
            else
            {
                switch (direction)
                {
                    case North:
                        location.Y += 1;
                        break;
                    case South:
                        location.Y -= 1;
                        break;
                    case NorthWest:
                        location.X -= 1;
                        break;
                    case NorthEast:
                        location.X += 1;
                        break;
                    case SouthWest:
                        location.X -= 1;
                        location.Y -= 1;
                        break;
                    case SouthEast:
                        location.X += 1;
                        location.Y -= 1;
                        break;
                }
            }

            return location;
        }

        public int CalculateFewestNumberOfSteps(string stepsTaken)
        {
            return CalculateFewestNumberOfSteps(stepsTaken.Split(new[] { ',', ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries));
        }

        public int CalculateFewestNumberOfSteps(IEnumerable<string> stepsTaken)
        {
            var location = new Coordinate(0, 0);
            foreach (var step in stepsTaken)
            {
                location = ApplyStep(step, location);
            }

            var stepsNeeded = 0;
            while (location.X != 0 || location.Y != 0)
            {
                if (location.X > 0 && location.Y > 0)
                    location = ApplyStep(SouthWest, location);
                else if (location.X > 0 && location.Y < 0)
                    location = ApplyStep(NorthWest, location);
                else if (location.X < 0 && location.Y < 0)
                    location = ApplyStep(NorthEast, location);
                else if (location.X < 0 && location.Y > 0)
                    location = ApplyStep(SouthEast, location);
                else if (location.Y < 0)
                    location = ApplyStep(North, location);
                else if (location.Y > 0)
                    location = ApplyStep(South, location);
                else if (location.X > 0 && location.X % 2 == 0)
                    location = ApplyStep(SouthWest, location);
                else if (location.X > 0 && location.X % 2 != 0)
                    location = ApplyStep(NorthWest, location);
                else if (location.X < 0 && location.X % 2 == 0)
                    location = ApplyStep(SouthEast, location);
                else
                    location = ApplyStep(NorthEast, location);

                stepsNeeded++;
            }
            return stepsNeeded;
        }
        private struct Coordinate
        {
            public int X, Y;

            public Coordinate(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }
    }
}

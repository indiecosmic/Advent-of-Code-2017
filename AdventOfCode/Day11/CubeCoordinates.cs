using System;
using System.Collections.Generic;

namespace AdventOfCode.Day11
{
    public class CubeCoordinates
    {
        private const string North = "n";
        private const string South = "s";
        private const string NorthWest = "nw";
        private const string NorthEast = "ne";
        private const string SouthWest = "sw";
        private const string SouthEast = "se";

        public int CalculateFewestNumberOfSteps(string stepsTaken)
        {
            return CalculateFewestNumberOfSteps(stepsTaken.Split(new[] { ',', ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries));
        }

        public int CalculateFurthestDistance(string stepsTaken)
        {
            return CalculateFurthestDistance(stepsTaken.Split(new[] {',', ' ', '\n'}, StringSplitOptions.RemoveEmptyEntries));
        }

        private int CalculateFewestNumberOfSteps(IEnumerable<string> stepsTaken)
        {
            var location = new CubeCoordinate(0, 0, 0);
            foreach (var step in stepsTaken)
            {
                location = ApplyStep(step, location);
            }
            
            return CalculateDistanceFromZero(location);
        }

        private int CalculateFurthestDistance(IEnumerable<string> stepsTaken)
        {
            var location = new CubeCoordinate(0, 0, 0);
            var maxDistance = 0;
            foreach (var step in stepsTaken)
            {
                location = ApplyStep(step, location);
                var distance = CalculateDistanceFromZero(location);
                if (distance > maxDistance)
                    maxDistance = distance;
            }

            return maxDistance;
        }

        private CubeCoordinate ApplyStep(string direction, CubeCoordinate location)
        {
            switch (direction)
            {
                case North:
                    location.Y += 1;
                    location.Z -= 1;
                    break;
                case NorthEast:
                    location.X += 1;
                    location.Z -= 1;
                    break;
                case SouthEast:
                    location.X += 1;
                    location.Y -= 1;
                    break;
                case South:
                    location.Y -= 1;
                    location.Z += 1;
                    break;
                case SouthWest:
                    location.X -= 1;
                    location.Z += 1;
                    break;
                case NorthWest:
                    location.X -= 1;
                    location.Y += 1;
                    break;
            }

            return location;
        }

        private int CalculateDistanceFromZero(CubeCoordinate location)
        {
            return (Math.Abs(location.X) + Math.Abs(location.Y) + Math.Abs(location.Z)) / 2;
        }

        private struct CubeCoordinate
        {
            public int X, Y, Z;

            public CubeCoordinate(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }
        }
    }
}

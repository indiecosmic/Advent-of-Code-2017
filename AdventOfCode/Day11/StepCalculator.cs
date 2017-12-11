using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day11
{
    public class StepCalculator
    {
        public int CalculateFewestNumberOfSteps(string stepsTaken)
        {
            return CalculateFewestNumberOfSteps(stepsTaken.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries));
        }

        public int CalculateFewestNumberOfSteps(string[] stepsTaken)
        {
            var numberOfNorth = stepsTaken.Count(s => s.IndexOf("n", StringComparison.Ordinal) != -1);
            var numberOfSouth = stepsTaken.Count(s => s.IndexOf("s", StringComparison.Ordinal) != -1);
            var numberOfEast = stepsTaken.Count(s => s.IndexOf("e", StringComparison.Ordinal) != -1);
            var numberOfWest = stepsTaken.Count(s => s.IndexOf("w", StringComparison.Ordinal) != -1);

            var northSouthCount = Math.Abs(numberOfNorth - numberOfSouth);
            var eastWestCount = Math.Abs(numberOfEast - numberOfWest);

            return Math.Max(northSouthCount, eastWestCount);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day21
{
    public static class StringExtensions
    {
        public static string Transform(this string matrix, Dictionary<string, string> rules) =>
            matrix.BreakupMatrix()
                .Select(g => rules[g])
                .JoinMatrixes();

        public static IEnumerable<string> BreakupMatrix(this string matrix)
        {
            string[] rows = matrix.Split('/');
            int divisor = rows.Length % 2 == 0 ? 2 : 3;
            int numGroups = (int)Math.Pow(rows.Length / divisor, 2);
            int groupSize = rows.Length / divisor;
            for (int g = 0; g < numGroups; g++)
            {
                var sb = new StringBuilder();
                for (int y = 0; y < divisor; y++)
                {
                    for (int x = 0; x < divisor; x++)
                    {
                        sb.Append(rows[(g / groupSize) * divisor + y][(g % groupSize) * divisor + x]);
                    }
                    if (y != divisor - 1) sb.Append('/');
                }
                yield return sb.ToString();
            }
        }

        public static string JoinMatrixes(this IEnumerable<string> children)
        {
            string[][] groups = children.Select(s => s.Split('/')).ToArray();
            var divisor = groups[0][0].Length;
            var size = (int)Math.Sqrt(groups.Length * divisor * divisor);
            var sb = new StringBuilder();
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    sb.Append(groups[(y / divisor) * (size / divisor) + x / divisor][y % divisor][x % divisor]);
                }
                if (y != size - 1) sb.Append('/');
            }
            return sb.ToString();
        }
    }
}

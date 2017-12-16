using System;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day16
{
    public abstract class Move
    {
        public abstract void Apply(char[] line);
        private const string ExchangePattern = @"x(?<x>\d+)/(?<y>\d+)";
        private const string PartnerPattern = @"p(?<a>\w+)/(?<b>\w+)";

        public static Move Parse(string input)
        {
            if (input.StartsWith("s"))
            {
                var times = Convert.ToInt32(input.Substring(1));
                return new Spin(times);
            }
            if (input.StartsWith("x"))
            {
                var match = Regex.Match(input, ExchangePattern);
                var x = Convert.ToInt32(match.Groups["x"].Value);
                var y = Convert.ToInt32(match.Groups["y"].Value);
                return new Exchange(x, y);
            }
            if (input.StartsWith("p"))
            {
                var match = Regex.Match(input, PartnerPattern);
                var a = match.Groups["a"].Value[0];
                var b = match.Groups["b"].Value[0];
                return new Partner(a, b);
            }
            throw new ArgumentException("Unknown move");
        }
    }

    public class Spin : Move
    {
        private readonly int _count;

        public Spin(int count)
        {
            _count = count;
        }

        public override void Apply(char[] line)
        {
            for (var i = 0; i < _count; i++)
            {
                var last = line[line.Length - 1];
                for (var qi = line.Length - 1; qi > 0; qi--)
                {
                    line[qi] = line[qi - 1];
                }
                line[0] = last;
            }
        }
    }

    public class Exchange : Move
    {
        private readonly int _position1;
        private readonly int _position2;

        public Exchange(int position1, int position2)
        {
            _position1 = position1;
            _position2 = position2;
        }

        public override void Apply(char[] line)
        {
            var temp = line[_position1];
            line[_position1] = line[_position2];
            line[_position2] = temp;
        }
    }

    public class Partner : Move
    {
        private readonly char _program1;
        private readonly char _program2;

        public Partner(char program1, char program2)
        {
            _program1 = program1;
            _program2 = program2;
        }
        public override void Apply(char[] line)
        {
            var aix = -1;
            var bix = -1;
            for (var ix = 0; ix < line.Length; ix++)
            {
                if (line[ix] == _program1)
                    aix = ix;
                if (line[ix] == _program2)
                    bix = ix;
                if (aix != -1 && bix != -1)
                    break;
            }
            var temp = line[aix];
            line[aix] = line[bix];
            line[bix] = temp;
        }
    }
}

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day24
{
    public class Component
    {
        public int[] Ports { get; }
        public int Strength => Ports.Sum();

        public Component(int[] ports)
        {
            Ports = ports;
        }

        public static Component Parse(string input)
        {
            var match = Regex.Match(input, @"(?<one>\d+)\/(?<two>\d+)");
            return new Component(new[]
            {
                Convert.ToInt32(match.Groups["one"].Value),
                Convert.ToInt32(match.Groups["two"].Value)
            });
        }

        public override string ToString()
        {
            return string.Join("/", Ports);
        }
        
    }
}

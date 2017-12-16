using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day13
{
    public class Firewall
    {
        private readonly Layer[] _layers;

        public int Severity { get; private set; }
        public bool WasCaught { get; private set; }

        private Firewall(Layer[] layers)
        {
            _layers = layers;
            Severity = 0;
            WasCaught = false;
        }

        public void Run(int delay = 0, bool breakOnCaught = false)
        {
                foreach (var layer in _layers)
                {
                    if (layer.CollisionCheck(delay))
                    {
                        WasCaught = true;
                        Severity += layer.Severity;
                        if (breakOnCaught) return;
                    }
                }
        }

        public static Firewall Create(string input)
        {
            var rows = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var regex = new Regex(@"^(?<depth>\d+):\s(?<range>\d+)$");
            var layers = rows.Select(row => regex.Match(row)).Select(match => new Layer(
                Convert.ToInt32(match.Groups["depth"].Value),
                Convert.ToInt32(match.Groups["range"].Value))).ToArray();
            return new Firewall(layers);
        }

        public class Layer
        {
            public int Depth { get; }
            public int Range { get; }
            public int RangeMultiple { get; set; }


            public int Severity => Depth * Range;

            public Layer(int depth, int range)
            {
                Depth = depth;
                Range = range;
                RangeMultiple = (Range - 1) * 2;
            }

            public bool CollisionCheck(int t)
            {
                return (Depth + t) % RangeMultiple == 0;
            }
        }
    }
}

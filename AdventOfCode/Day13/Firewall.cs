using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day13
{
    public class Firewall
    {
        private readonly int _maxDepth;
        private readonly Layer[] _layers;
        private int _currentPosition;

        public int Severity { get; private set; }
        public bool WasCaught { get; private set; }

        private Firewall(Layer[] layers)
        {
            _currentPosition = -1;
            _layers = layers;
            _maxDepth = layers.Max(l => l.Depth);
            Severity = 0;
            WasCaught = false;
        }

        public void Run()
        {
            while (_currentPosition < _maxDepth)
            {
                _currentPosition++;

                foreach (var layer in _layers)
                {
                    if (layer.CollisionCheck(_currentPosition))
                    {
                        WasCaught = true;
                        Severity += layer.Severity;
                    }

                    layer.Update();
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
            private const int ScannerDirectionUp = -1;
            private const int ScannerDirectionDown = 1;

            private int _scannerDirection;
            private int _scannerPosition;

            public int Depth { get; }
            public int Range { get; }

            public int ScannerPosition => _scannerPosition;

            public int Severity => Depth * Range;

            public Layer(int depth, int range, int scannerPosition = 0, int scannerDirection = ScannerDirectionDown)
            {
                Depth = depth;
                Range = range;
                _scannerPosition = scannerPosition;
                _scannerDirection = scannerDirection;
            }

            public void Update()
            {
                if (_scannerPosition == Range - 1 && _scannerDirection == ScannerDirectionDown ||
                    _scannerPosition == 0 && _scannerDirection == ScannerDirectionUp)
                {
                    _scannerDirection = -_scannerDirection;
                }
                _scannerPosition += _scannerDirection;
            }

            public bool CollisionCheck(int position)
            {
                return position == Depth && _scannerPosition == 0;
            }
        }
    }
}

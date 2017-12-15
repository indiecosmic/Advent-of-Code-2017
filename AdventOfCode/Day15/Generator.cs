using System;

namespace AdventOfCode.Day15
{
    public class Generator
    {
        private readonly long _factor;
        private readonly bool _adjusted;
        private readonly int _divisor;
        private long _nextValue;

        public Generator(int factor, int startValue, bool adjusted = false, int divisor = 0)
        {
            _factor = factor;
            _nextValue = startValue;
            _adjusted = adjusted;
            _divisor = divisor;
        }

        public long GenerateNext()
        {
            do
            {
                _nextValue = (_nextValue * _factor) % int.MaxValue;
            } while (_adjusted && _nextValue % _divisor != 0);

            return _nextValue;
        }

        public long GenerateNextOptimized()
        {
            return GenerateNext() & 0xffff;
        }

        public string GenerateNextAsBinary()
        {
            return Convert.ToString(GenerateNext(), 2).PadLeft(32, '0');
        }
    }
}

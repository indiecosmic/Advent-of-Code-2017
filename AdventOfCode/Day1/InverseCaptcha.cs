using System;

namespace AdventOfCode.Day1
{
    public class InverseCaptcha
    {
        private readonly IDigitFinder _digitFinder;

        public InverseCaptcha(IDigitFinder digitFinder)
        {
            _digitFinder = digitFinder;
        }

        public int Calculate(string input)
        {
            var result = 0;
            for (var i = 0; i < input.Length; i++)
            {
                var currentDigit = Convert.ToInt32(input.Substring(i, 1));
                var nextDigit = _digitFinder.FindNextDigit(input, i);
                if (currentDigit == nextDigit) result += currentDigit;
            }

            return result;
        }

        public int Calculate(int input)
        {
            return Calculate(input.ToString());
        }
    }

    public interface IDigitFinder
    {
        int FindNextDigit(string input, int currentPosition);
    }

    public class NextDigit : IDigitFinder
    {
        public int FindNextDigit(string input, int currentPosition)
        {
            var nextIndex = currentPosition == (input.Length - 1) ? 0 : currentPosition + 1;
            return Convert.ToInt32(input.Substring(nextIndex, 1));
        }
    }

    public class HalfwayAroundDigit : IDigitFinder
    {
        public int FindNextDigit(string input, int currentPosition)
        {
            var steps = input.Length / 2;
            var nextIndex = 0;
            if (currentPosition + steps <= input.Length - 1)
                nextIndex = currentPosition + steps;
            else
                nextIndex = currentPosition + steps - (input.Length);

            return Convert.ToInt32(input.Substring(nextIndex, 1));
        }
    }
}

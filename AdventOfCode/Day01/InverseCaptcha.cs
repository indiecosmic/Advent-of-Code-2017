using System;
using System.Linq;

namespace AdventOfCode.Day01
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
            var digits = input.Select(i => (int)char.GetNumericValue(i)).ToArray();

            var result = 0;
            for (var i = 0; i < digits.Length; i++)
            {
                var currentDigit = digits[i];
                var nextDigit = _digitFinder.FindNextDigit(digits, i);
                if (currentDigit == nextDigit) result += currentDigit;
            }

            return result;
        }
    }

    public interface IDigitFinder
    {
        int FindNextDigit(int[] digits, int currentPosition);
    }

    public class NextDigit : IDigitFinder
    {
        public int FindNextDigit(int[] digits, int currentPosition)
        {
            var nextIndex = currentPosition == (digits.Length - 1) ? 0 : currentPosition + 1;
            return digits[nextIndex];
        }
    }

    public class HalfwayAroundDigit : IDigitFinder
    {
        public int FindNextDigit(int[] digits, int currentPosition)
        {
            var steps = digits.Length / 2;
            int nextIndex;
            if (currentPosition + steps <= digits.Length - 1)
                nextIndex = currentPosition + steps;
            else
                nextIndex = currentPosition + steps - (digits.Length);

            return digits[nextIndex];
        }
    }
}

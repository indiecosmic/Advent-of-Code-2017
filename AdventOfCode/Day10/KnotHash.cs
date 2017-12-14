using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day10
{
    public class KnotHash
    {
        private ListReverser _reverser;

        public KnotHash(ListReverser reverser)
        {
            _reverser = reverser;
        }

        public int Calculate(int[] numbers, int[] lengths)
        {
            var currentPosition = 0;
            var skipSize = 0;
            for (var i = 0; i < lengths.Length; i++)
            {
                _reverser.Reverse(numbers, currentPosition, lengths[i]);
                currentPosition += lengths[i] + skipSize;
                if (currentPosition > numbers.Length - 1) currentPosition -= numbers.Length;
                skipSize++;
            }

            return numbers[0] * numbers[1];
        }
    }
}

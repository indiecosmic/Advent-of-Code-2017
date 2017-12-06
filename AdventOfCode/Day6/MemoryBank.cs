using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day6
{
    public class MemoryBank
    {
        private readonly int[] _banks;
        public MemoryBank(int[] initialState)
        {
            _banks = initialState;
        }

        public int[] GetState()
        {
            return (int[])_banks.Clone();
        }

        public int[] Redistribute()
        {
            var redistributeFrom = FindBankWithMostBlocks();
            var value = _banks[redistributeFrom];
            _banks[redistributeFrom] = 0;
            var index = redistributeFrom + 1;
            if (index > _banks.Length - 1) index = 0;
            while (value > 0)
            {
                _banks[index] += 1;
                value -= 1;

                index += 1;
                if (index > _banks.Length - 1) index = 0;
            }

            return (int[]) _banks.Clone();
        }

        public int FindBankWithMostBlocks()
        {
            var maxValue = _banks.Max();
            for (var i = 0; i < _banks.Length; i++)
            {
                if (_banks[i] == maxValue)
                    return i;
            }

            return -1;
        }
    }
}

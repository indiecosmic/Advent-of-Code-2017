using System;
using System.Linq;

namespace AdventOfCode.Day16
{
    public class Dance
    {
        private readonly Move[] _moves;

        private Dance(Move[] moves)
        {
            _moves = moves;
        }

        public static Dance Parse(string input)
        {
            var instructions = input.Split(new[] { ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var moves = instructions.Select(Move.Parse);

            return new Dance(moves.ToArray());
        }

        public char[] Run(char[] input)
        {
            var line = (char[])input.Clone();
            foreach (var instruction in _moves)
            {
                instruction.Apply(line);
            }
            return line;
        }

        public char[] Run(char[] input, int times)
        {
            var timesUntilRepeat = RunCountUntilRepeat(input);
            times = (times < timesUntilRepeat) ? times : times % timesUntilRepeat;

            for (var i = 0; i < times; i++)
            {
                input = Run(input);
            }

            return input;
        }

        private int RunCountUntilRepeat(char[] input)
        {
            var original = (char[])input.Clone();
            var count = 0;
            do
            {
                input = Run(input);
                count++;
            } while (!input.SequenceEqual(original));

            return count;
        }
    }
}

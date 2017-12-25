using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day23;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day23 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 23");
            var input = GetInput();
            var rows = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var instructions = rows.Select(Instruction.Parse).ToArray();
            var state = new Register();
            var index = 0;
            while (index >= 0 && index < instructions.Length)
            {
                var instruction = instructions[index];
                index += instruction.Execute(state);
            }

            Part2();

            Console.WriteLine($"Result {state.MulCount}");
            Console.WriteLine("Part 2");
            state = new Register();
            state.Registers.Add("a", 1);
            index = 0;
            while (index >= 0 && index < instructions.Length)
            {
                var instruction = instructions[index];
                index += instruction.Execute(state);
            }

            Console.WriteLine($"Result {state.Registers["h"]}");
        }

        private void Part2()
        {
            Console.WriteLine("Part 2");
            const int c = 123500;
            var h = 0;
            for (var b = 106500; b < c + 1; b += 17)
            {
                if (!IsPrime(b))
                    h += 1;
            }

            Console.WriteLine($"Result: {h}");
        }

        private static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}

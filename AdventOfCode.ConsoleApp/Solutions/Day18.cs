using System;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Day18;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day18 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 18");
            var input = GetInput();

            var rows = input.Split(new[] { ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var instructions = rows.Select(Instruction.Parse).ToArray();
            Part1(instructions);
            Part2(instructions);
        }

        private void Part1(Instruction[] instructions)
        {
            var state = new Duet(0);
            foreach (var instruction in instructions)
            {
                if (!state.Registers.ContainsKey(instruction.RegisterName) && Regex.IsMatch(instruction.RegisterName, "^[a-z]*$"))
                    state.Registers[instruction.RegisterName] = 0;
            }

            Console.WriteLine("Part 1");
            var index = 0;
            while (index >= 0 && index < instructions.Length)
            {
                var instruction = instructions[index];
                index += instruction.Execute(state);

                if (instruction is Rcv)
                {
                    break;
                }
            }

            Console.WriteLine($"Result {state.Messages.Last()}");
        }

        private void Part2(Instruction[] instructions)
        {
            Console.WriteLine("Part 2");
            var state1 = new Duet(0);
            var state2 = new Duet(1);
            state1.Connect(state2);
            foreach (var instruction in instructions)
            {
                if (!state1.Registers.ContainsKey(instruction.RegisterName) && Regex.IsMatch(instruction.RegisterName, "^[a-z]*$"))
                    state1.Registers[instruction.RegisterName] = 0;
                if (!state2.Registers.ContainsKey(instruction.RegisterName) && Regex.IsMatch(instruction.RegisterName, "^[a-z]*$"))
                    state2.Registers[instruction.RegisterName] = 0;
            }

            var index1 = 0;
            var index2 = 0;
            while (index1 >= 0 && index1 < instructions.Length && index2 >= 0 && index2 < instructions.Length)
            {
                var instruction1 = instructions[index1];
                index1 += instruction1.Execute(state1);

                var instruction2 = instructions[index2];
                index2 += instruction2.Execute(state2);
                if (state1.Waiting && instruction1 is Rcv && state2.Waiting && instruction2 is Rcv)
                {
                    Console.WriteLine("Deadlock");
                    break;
                }
            }

            Console.WriteLine($"Messages sent: {state1.MessagesSent}");
        }
    }
}

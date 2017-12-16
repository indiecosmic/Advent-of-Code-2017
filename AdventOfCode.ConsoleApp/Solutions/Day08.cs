using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Day08;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day08 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 8");

            var input = GetInput();

            var instructions = ParseInstructions(input);
            var register = InitializeRegisters(instructions);
            int max = 0;
            foreach (var instruction in instructions)
            {
                var value = instruction.ApplyTo(register[instruction.TargetRegister], register[instruction.ConditionRegister]);
                if (value > max)
                    max = value;
                register[instruction.TargetRegister] = value;
            }
            var maxValue = register.Max(pair => pair.Value);
            Console.WriteLine($"Max value: {maxValue} ({max})");
        }

        private static IList<JumpInstruction> ParseInstructions(string input)
        {
            var instructions = input.Split(new[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            instructions = instructions.Select(i => i.Trim()).ToArray();
            return instructions.Select(JumpInstruction.Parse).ToList();
        }

        private static Dictionary<string, int> InitializeRegisters(IEnumerable<JumpInstruction> instructions)
        {
            var result = new Dictionary<string, int>();
            foreach (var instruction in instructions)
            {
                if (!result.ContainsKey(instruction.TargetRegister))
                    result.Add(instruction.TargetRegister, 0);
                if (!result.ContainsKey(instruction.ConditionRegister))
                    result.Add(instruction.ConditionRegister, 0);
            }

            return result;
        }
    }
}

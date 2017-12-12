using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Day08;

namespace AdventOfCode.ConsoleApp
{
    public class Day8Solution
    {
        public static void Run()
        {
            //var input = @"b inc 5 if a > 1
            //              a inc 1 if b < 5
            //              c dec -10 if a >= 1
            //              c inc -20 if c == 10";
            string input;
            using (var reader = new StreamReader("day8input.txt"))
            {
                input = reader.ReadToEnd();
            }

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

        public static IList<JumpInstruction> ParseInstructions(string input)
        {
            var instructions = input.Split(new[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            instructions = instructions.Select(i => i.Trim()).ToArray();
            return instructions.Select(JumpInstruction.Parse).ToList();
        }

        public static Dictionary<string, int> InitializeRegisters(IEnumerable<JumpInstruction> instructions)
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

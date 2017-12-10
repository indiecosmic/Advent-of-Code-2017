using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day8;

namespace AdventOfCode.ConsoleApp
{
    public class Day8Solution
    {
        public static void Run()
        {
            var input = @"b inc 5 if a > 1
                          a inc 1 if b < 5
                          c dec -10 if a >= 1
                          c inc -20 if c == 10";
            var instructions = ParseInstructions(input);
            var register = InitializeRegisters(instructions);
            foreach (var instruction in instructions)
            {
                register[instruction.TargetRegister] = instruction.ApplyTo(register[instruction.TargetRegister], register[instruction.ConditionRegister]);
            }
        }

        public static IList<JumpInstruction> ParseInstructions(string input)
        {
            var instructions = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
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

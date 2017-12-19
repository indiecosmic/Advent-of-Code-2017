using System;
using System.Linq;
using AdventOfCode.Day18;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day18 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 18");
            var input = GetInput();
            //var input = "set a 1\nadd a 2\nmul a a\nmod a 5\nsnd a\nset a 0\nrcv a\njgz a -1\nset a 1\njgz a -2";


            var rows = input.Split(new[] { ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var instructions = rows.Select(Instruction.Parse).ToArray();
            var state = new Duet();
            foreach (var instruction in instructions)
            {
                if (!state.Registers.ContainsKey(instruction.RegisterName))
                    state.Registers[instruction.RegisterName] = 0;
            }

            var index = 0;
            while (index >= 0 && index < instructions.Length)
            {
                var instruction = instructions[index];

                if (instruction is Rcv)
                {
                    
                }

                index += instruction.Execute(state);
            }



            Console.WriteLine("Part 1");
        }
    }
}

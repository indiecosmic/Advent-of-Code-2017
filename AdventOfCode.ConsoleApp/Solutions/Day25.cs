using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Day25;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day25 : SolutionBase
    {
        public override void Run()
        {
            //var input = @"Begin in state A.
            //            Perform a diagnostic checksum after 6 steps.

            //            In state A:
            //                If the current value is 0:
            //                - Write the value 1.
            //                - Move one slot to the right.
            //                - Continue with state B.
            //                If the current value is 1:
            //                - Write the value 0.
            //                - Move one slot to the left.
            //                - Continue with state B.

            //            In state B:
            //                If the current value is 0:
            //                - Write the value 1.
            //                - Move one slot to the left.
            //                - Continue with state A.
            //                If the current value is 1:
            //                - Write the value 1.
            //                - Move one slot to the right.
            //                - Continue with state A.";

            var input = GetInput();
            var parts = input.Split(new []{Environment.NewLine}, StringSplitOptions.None);

            var startState = parts[0].Substring(parts[0].Length - 2, 1);
            var repetitions = int.Parse(Regex.Match(parts[1], "\\d+").Value);
            var states = ParseStates(parts);
            var tape = new Tape();

            var nextState = states[startState];
            for (var i = 0; i < repetitions; i++)
            {
                var result = nextState.Run(tape);
                nextState = states[result];
            }
            var checksum = tape.Checksum;

            Console.WriteLine("Day 25");
            Console.WriteLine("Part 1");
            Console.WriteLine($"Checksum: {checksum}");
        }

        private Dictionary<string, State> ParseStates(string[] parts)
        {
            var states = new List<State>();
            State currentState = null;
            State.Branch currentBranch = null;
            for (var i = 2; i < parts.Length; i++)
            {
                var part = parts[i].Trim();
                if (string.IsNullOrEmpty(part))
                {
                    currentState = new State();
                    states.Add(currentState);
                }
                else if (part.StartsWith("In state"))
                {
                    currentState.Name = part.Substring(part.Length - 2, 1);
                }
                else if (part.StartsWith("If the"))
                {
                    currentBranch = new State.Branch(int.Parse(part.Substring(part.Length - 2, 1)));
                    currentState.Branches.Add(currentBranch);
                }
                else if (part.StartsWith("- Write"))
                {
                    currentBranch.WriteValue = int.Parse(part.Substring(part.Length - 2, 1));
                }
                else if (part.StartsWith("- Move"))
                {
                    currentBranch.MoveDirection = part.Contains("left") ? State.Direction.Left : State.Direction.Right;
                }
                else if (part.StartsWith("- Continue"))
                {
                    currentBranch.NextState = part.Substring(part.Length - 2, 1);
                }
            }

            return states.ToDictionary(s => s.Name, s => s);
        }
    }
}

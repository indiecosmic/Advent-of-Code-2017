using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Day21;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day21 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 21");

            var matrix = ".#./..#/###";
            var input = GetInput();
            var parts = input.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            var rules = GetRules(parts);
            rules = AddTransformationsToRules(rules);
            foreach (var i in Enumerable.Range(0, 18))
            {
                matrix = matrix.Transform(rules);
            }
            var result = matrix.Count(c => c == '#');

            Console.WriteLine($"{result}");
        }

        private static Dictionary<string, string> GetRules(string[] input) =>
            input.Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => s.Split(new[]{" => "}, StringSplitOptions.RemoveEmptyEntries))
                .ToDictionary(s => s[0], s => s[1]);

        private static Dictionary<string, string> AddTransformationsToRules(Dictionary<string, string> rules)
        {
            var copy = new Dictionary<string, string>(rules.Count * 5);
            foreach (var pair in rules)
            {
                string group = pair.Key;
                copy[group] = pair.Value;
                foreach (var i in Enumerable.Range(0, 4))
                {
                    group = Symmetric(group);
                    copy[group] = pair.Value;

                    group = Flip(group);
                    copy[group] = pair.Value;
                }
            }
            return copy;
        }

        private static string Symmetric(string m) =>
            m.Length == 11 ? $"{m[0]}{m[4]}{m[8]}/{m[1]}{m[5]}{m[9]}/{m[2]}{m[6]}{m[10]}" :
                             $"{m[0]}{m[3]}/{m[1]}{m[4]}";

        private static string Flip(string m) =>
            m.Length == 11 ? $"{m[8]}{m[9]}{m[10]}/{m[4]}{m[5]}{m[6]}/{m[0]}{m[1]}{m[2]}" :
                             $"{m[3]}{m[4]}/{m[0]}{m[1]}";

        

        
    }
}

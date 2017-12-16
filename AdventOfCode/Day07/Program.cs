using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day07
{
    public class Program
    {
        public string Name { get; }
        public int Weight { get; }
        public IEnumerable<string> ChildrenNames { get; }       
        public IList<Program> Children { get; }
        public Program Parent { get; set; }

        public int TotalWeight => Weight + Children.Sum(c => c.TotalWeight);
        public bool HasChildren => ChildrenNames != null && ChildrenNames.Any();

        public bool IsBalanced
        {
            get
            {
                if (Children.Count == 0)
                    return true;

                var firstValue = Children.First().TotalWeight;
                return Children.All(c => c.TotalWeight == firstValue);
            }
        }

        private Program(string name, int weight)
        {
            Name = name;
            Weight = weight;
            Children = new List<Program>();
        }

        private Program(string name, int weight, IEnumerable<string> childrenNames)
            : this(name, weight)
        {
            ChildrenNames = childrenNames;
        }

        public static Program Parse(string input)
        {
            var regex = new Regex(@"^(?<name>\w+)[\s]\((?<weight>\d+)\)(?<children>[\s]->[\s])?(?<names>[\w,\s]+)?$");
            var match = regex.Match(input);
            var name = match.Groups["name"].Value;
            var weight = Convert.ToInt32(match.Groups["weight"].Value);
            if (!match.Groups["children"].Success)
                return new Program(name, weight);
            var names = match.Groups["names"].Value.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            return new Program(name, weight, names);
        }
    }
}

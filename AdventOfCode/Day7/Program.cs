using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Day7
{
    public class Program
    {
        public string Name { get; }
        public int Weight { get; }
        public int TotalWeight => Weight + Children.Sum(c => c.TotalWeight);
        public IEnumerable<string> ChildrenNames { get; }
        public bool HasChildren => ChildrenNames != null && ChildrenNames.Any();
        public IList<Program> Children { get; }

        public Program(string name, int weight)
        {
            Name = name;
            Weight = weight;
            Children = new List<Program>();
        }

        public Program(string name, int weight, IEnumerable<string> childrenNames)
            : this(name, weight)
        {
            ChildrenNames = childrenNames;
        }

        public int GetWeight()
        {
            var childrenWeight = Children.Sum(c => c.GetWeight());
            return childrenWeight + Weight;
        }

        public bool IsBalanced()
        {
            if (Children.Count == 0)
                return true;
            return Children.All(c => c.GetWeight() == Children[0].GetWeight());
        }

        public Program Parent { get; set; }

        public static Program Parse(string input)
        {
            var regex = new Regex(@"^(?<name>\w+)[\s]\((?<weight>\d+)\)(?<children>[\s]->[\s])?(?<names>[\w,\s]+)?$");
            var match = regex.Match(input);
            var name = match.Groups["name"].Value;
            var weight = Convert.ToInt32(match.Groups["weight"].Value);
            if (!match.Groups["children"].Success)
                return new Program(name, weight);
            var names = match.Groups["names"].Value.Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
            return new Program(name, weight, names);
        }
    }
}

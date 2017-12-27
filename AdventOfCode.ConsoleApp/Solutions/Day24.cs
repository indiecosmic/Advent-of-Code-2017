using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day24;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day24 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 24");
            var input = GetInput();
            var rows = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var components = rows.Select(Component.Parse).ToList();

            Console.WriteLine("Part 1");

            var startComponents = components.Where(c => c.Ports.Any(p => p == 0)).ToArray();
            var max = 0;
            foreach (var start in startComponents)
            {
                var pinIndex = Array.IndexOf(start.Ports, 0) == 0 ? 1 : 0;
                var nextPin = start.Ports[pinIndex];
                var strength = BuildBridge(nextPin, start, components.Except(new []{start}).ToList());
                if (strength > max) max = strength;
            }

            Console.WriteLine($"Max strength: {max}");

            Console.WriteLine("Part 2");
            var maxLength = (0,0);
            foreach (var start in startComponents)
            {
                var pinIndex = Array.IndexOf(start.Ports, 0) == 0 ? 1 : 0;
                var nextPin = start.Ports[pinIndex];
                var strength = BuildLongBridge(nextPin, start, components.Except(new[] { start }).ToList());
                if (strength.Item1 > maxLength.Item1 || (strength.Item1 == maxLength.Item1 && strength.Item2 > maxLength.Item2)) maxLength = strength;
            }
            Console.WriteLine($"Longest: {maxLength.Item1}, strength: {maxLength.Item2}");
        }

        public int BuildBridge(int pin, Component current, List<Component> components)
        {
            var compatible = components.Where(c => c.Ports.Any(p => p == pin)).ToList();
            if (compatible.Count == 0) return current.Strength;

            var max = 0;
            foreach (var component in compatible)
            {
                var pinIndex = Array.IndexOf(component.Ports, pin) == 0 ? 1 : 0;
                var nextPin = component.Ports[pinIndex];
                var strength = current.Strength + BuildBridge(nextPin, component, components.Except(new []{ component}).ToList());
                if (strength > max) max = strength;
            }
            return max;
        }

        public (int,int) BuildLongBridge(int pin, Component current, List<Component> components)
        {
            var compatible = components.Where(c => c.Ports.Any(p => p == pin)).ToList();
            if (compatible.Count == 0) return (1,current.Strength);

            var max = (0,0);
            foreach (var component in compatible)
            {
                var pinIndex = Array.IndexOf(component.Ports, pin) == 0 ? 1 : 0;
                var nextPin = component.Ports[pinIndex];
                var res = BuildLongBridge(nextPin, component, components.Except(new[] { component }).ToList());
                var strength = (1 + res.Item1, current.Strength + res.Item2);
                if (strength.Item1 > max.Item1 || (strength.Item1 == max.Item1 && strength.Item2 > max.Item2)) max = strength;
            }
            return max;
        }
    }
}

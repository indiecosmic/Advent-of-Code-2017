using System;
using AdventOfCode.Day13;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day13 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 13");
            var input = GetInput();
            
            Console.WriteLine("Part 2");
            var firewall = Firewall.Create(input);
            firewall.Run();
            Console.WriteLine($"Severity: {firewall.Severity}");

            Console.WriteLine("Part 2");
            var delay = 0;
            while (true)
            {
                firewall = Firewall.Create(input);
                firewall.Run(delay, true);
                if (!firewall.WasCaught) break;
                delay++;
            }

            Console.WriteLine($"Delay: {delay}");
        }
    }
}

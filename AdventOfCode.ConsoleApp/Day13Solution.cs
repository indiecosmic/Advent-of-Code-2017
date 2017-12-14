using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day13;

namespace AdventOfCode.ConsoleApp
{
    class Day13Solution
    {
        public static void Run()
        {
            string input;
            using (var reader = new StreamReader("day13input.txt"))
            {
                input = reader.ReadToEnd();
            }
            
            var delay = 0;
            while (true)
            {
                var firewall = Firewall.Create(input);
                firewall.Run();
                if (!firewall.WasCaught) break;
                delay++;
            }

            Console.WriteLine($"Delay: {delay}");
            

        }
    }
}

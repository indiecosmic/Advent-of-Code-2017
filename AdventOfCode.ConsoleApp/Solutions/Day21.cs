using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day21;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day21 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 21");

            var grid = new Grid(new[,] { { '.', '#', '.' }, { '.', '.', '#' }, { '#', '#', '#' } });
            var by2 = grid.DivisibleBy(2);
            var by3 = grid.DivisibleBy(3);


        }
    }
}

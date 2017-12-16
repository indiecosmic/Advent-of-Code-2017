using System;
using AdventOfCode.Day01;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day01 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 1");
            var input = GetInput();

            Console.WriteLine("Part 1");
            var captcha = new InverseCaptcha(new NextDigit());
            var result = captcha.Calculate(input);

            Console.WriteLine($"Result: {result}");


            Console.WriteLine("Part 2");
            captcha = new InverseCaptcha(new HalfwayAroundDigit());
            result = captcha.Calculate(input);

            Console.WriteLine($"Result: {result}");
            Console.WriteLine();
        }
    }
}

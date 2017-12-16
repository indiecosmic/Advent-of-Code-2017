using System;
using System.IO;
using AdventOfCode.Day01;

namespace AdventOfCode.ConsoleApp
{
    class Day01Solution
    {
        public static void Run()
        {
            Console.WriteLine("Day 1");
            string input;
            using (var reader = new StreamReader("day01input.txt"))
            {
                input = reader.ReadToEnd().Trim();
            }

            Console.WriteLine("Part 1");
            var captcha = new InverseCaptcha(new NextDigit());
            var result = captcha.Calculate(input);

            Console.WriteLine($"Result: {result}");


            Console.WriteLine("Part 2");
            captcha = new InverseCaptcha(new HalfwayAroundDigit());
            result = captcha.Calculate(input);

            Console.WriteLine($"Result: {result}");
        }
    }
}

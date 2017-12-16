using System;
using AdventOfCode.Day04;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal class Day04 : SolutionBase
    {
        public override void Run()
        {
            Console.WriteLine("Day 4");
            var input = GetInput();

            var passphrases = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("Part 1");
            var validator = new PassphraseValidator(new IValidationRule[]{new NoDuplicateWords()});
            var count = 0;
            foreach (var passphrase in passphrases)
            {
                if (validator.IsValid(passphrase)) count++;
            }

            Console.WriteLine(count);

            Console.WriteLine("Part 2");
            validator = new PassphraseValidator(new IValidationRule[] { new NoAnagrams() });
            count = 0;
            foreach (var passphrase in passphrases)
            {
                if (validator.IsValid(passphrase)) count++;
            }

            Console.WriteLine(count);
        }
    }
}

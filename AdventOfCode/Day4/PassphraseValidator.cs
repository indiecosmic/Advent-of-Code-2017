using System;
using System.Linq;

namespace AdventOfCode.Day4
{
    public class PassphraseValidator
    {
        public bool IsValid(string passphrase)
        {
            var words = passphrase.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < words.Length; i++)
            {
                words[i] = string.Concat(words[i].OrderBy(w => w));
            }

            return words.Length == words.Distinct().Count();
        }
    }
}

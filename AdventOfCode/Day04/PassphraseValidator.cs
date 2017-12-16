using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day04
{
    public class PassphraseValidator
    {
        private readonly IEnumerable<IValidationRule> _validationRules;

        public PassphraseValidator(IEnumerable<IValidationRule> validationRules)
        {
            _validationRules = validationRules;
        }

        public bool IsValid(string passphrase)
        {
            foreach (var rule in _validationRules)
            {
                if (!rule.IsValid(passphrase))
                    return false;
            }

            return true;
        }
    }

    public interface IValidationRule
    {
        bool IsValid(string passphrase);
    }

    public class NoDuplicateWords : IValidationRule
    {
        public bool IsValid(string passphrase)
        {
            var words = passphrase.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return words.Length == words.Distinct().Count();
        }
    }

    public class NoAnagrams : IValidationRule
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

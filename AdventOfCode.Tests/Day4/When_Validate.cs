using NUnit.Framework;

namespace AdventOfCode.Tests.Day4
{
    [TestFixture]
    public class When_Validate : Arrange
    {
        [TestCase("aa bb cc dd ee", ExpectedResult = true)]
        [TestCase("aa bb cc dd aa", ExpectedResult = false)]
        [TestCase("aa bb cc dd aaa", ExpectedResult = true)]
        public bool Should_not_allow_duplicate_words(string phrase)
        {
            return Validator.IsValid(phrase);
        }

        [TestCase("abcde fghij", ExpectedResult = true)]
        [TestCase("abcde xyz ecdab", ExpectedResult = false)]
        [TestCase("a ab abc abd abf abj", ExpectedResult = true)]
        [TestCase("iiii oiii ooii oooi oooo", ExpectedResult = true)]
        [TestCase("oiii ioii iioi iiio", ExpectedResult = false)]
        public bool Should_not_allow_anagrams(string phrase)
        {
            return Validator.IsValid(phrase);
        }
    }
}

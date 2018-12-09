using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day21;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day21.Given_Rule
{
    [TestFixture]
    class When_Enhance
    {
        private EnhancementRule Subject { get; } = EnhancementRule.Parse("123/456/789 => 1234/5678/ABCD/EFGH");
        private readonly Grid _originalGrid = new Grid(new[,] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } });
        private readonly Grid _expected = new Grid(new[,] { { '1', '2', '3', '4' }, { '5', '6', '7', '8' }, { 'A', 'B', 'C', 'D' }, { 'E', 'F', 'G', 'H' } });
        private Grid _result;

        [SetUp]
        public void Because_of() => _result = Subject.Enhance(_originalGrid);

        [Test]
        public void Result_matches_expected() => Assert.That(_expected.Equals(_result), Is.True);
    }
}

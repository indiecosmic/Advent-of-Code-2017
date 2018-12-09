using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day21;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AdventOfCode.Tests.Day21.Given_Rule
{
    [TestFixture]
    class When_Parse
    {
        private EnhancementRule _result;

        [SetUp]
        public void Because_of() => _result = EnhancementRule.Parse(".#./..#/### => #..#/..../..../#..#");

        [Test]
        public void InputSize_should_be_3() => Assert.That(_result.InputSize, Is.EqualTo(3));

        [Test]
        public void OutputSize_should_be_4() => Assert.That(_result.OutputSize, Is.EqualTo(4));
    }
}

using System.Collections.Generic;
using AdventOfCode.Day15;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day15.Given_Generator
{
    [TestFixture]
    public class When_Generate
    {
        private readonly Generator _generatorA = new Generator(16807, 65);
        private readonly Generator _generatorB = new Generator(48271, 8921);
        private readonly IList<long> _aResults = new List<long>();
        private readonly IList<long> _bResults = new List<long>();

        [SetUp]
        public void Because_of()
        {
            for (var i = 0; i < 5; i++)
            {
                _aResults.Add(_generatorA.GenerateNext());
                _bResults.Add(_generatorB.GenerateNext());
            }
        }

        [Test]
        public void GeneratedValues_should_match_examples() =>
            Assert.Multiple(() =>
            {
                Assert.That(_aResults,
                    Has.One.EqualTo(1092455)
                        .And.One.EqualTo(1181022009)
                        .And.One.EqualTo(245556042)
                        .And.One.EqualTo(1744312007)
                        .And.One.EqualTo(1352636452));
                Assert.That(_bResults,
                    Has.One.EqualTo(430625591)
                        .And.One.EqualTo(1233683848)
                        .And.One.EqualTo(1431495498)
                        .And.One.EqualTo(137874439)
                        .And.One.EqualTo(285222916));
            });
    }
}

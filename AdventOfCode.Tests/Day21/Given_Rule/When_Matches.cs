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
    public class When_Matches
    {
        private EnhancementRule Subject { get; } = EnhancementRule.Parse("123/456/789 => 1234/5678/ABCD/EFGH");
        private readonly Grid _originalGrid = new Grid(new[,] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } });
        private readonly Grid _rotatedGrid = new Grid(new[,] { { '7', '4', '1' }, { '8', '5', '2' }, { '9', '6', '3' } });
        private readonly Grid _twiceRotatedGrid = new Grid(new[,] { { '9', '8', '7' }, { '6', '5', '4' }, { '3', '2', '1' } });
        private readonly Grid _thriceRotatedGrid = new Grid(new[,] { { '3', '6', '9' }, { '2', '5', '8' }, { '1', '4', '7' } });
        private readonly Grid _flippedVGrid = new Grid(new[,] { { '3', '2', '1' }, { '6', '5', '4' }, { '9', '8', '7' } });
        private readonly Grid _flippedHGrid = new Grid(new[,] { { '7', '8', '9' }, { '4', '5', '6' }, { '1', '2', '3' } });
        private readonly Grid _rotatedAndFlippedGrid = new Grid(new[,]{{'9','6','3'},{'8','5','2'}, {'7','4','1'}});

        [Test]
        public void Should_match_original_grid() => Assert.That(Subject.Matches(_originalGrid), Is.True);
        [Test]
        public void Should_match_rotated_grid() => Assert.That(Subject.Matches(_rotatedGrid), Is.True);
        [Test]
        public void Should_match_twice_rotated_grid() => Assert.That(Subject.Matches(_twiceRotatedGrid), Is.True);
        [Test]
        public void Should_match_thrice_rotated_grid() => Assert.That(Subject.Matches(_thriceRotatedGrid), Is.True);
        [Test]
        public void Should_match_flipped_vertical_grid() => Assert.That(Subject.Matches(_flippedVGrid), Is.True);
        [Test]
        public void Should_match_flipped_horizontal_grid() => Assert.That(Subject.Matches(_flippedHGrid), Is.True);
        [Test]
        public void Should_match_flipped_and_rotated_grid() => Assert.That(Subject.Matches(_rotatedAndFlippedGrid), Is.True);

    }
}

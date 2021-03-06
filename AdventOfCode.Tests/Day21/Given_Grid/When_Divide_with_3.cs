﻿using AdventOfCode.Day21;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day21.Given_Grid
{
    [TestFixture]
    public class When_Divide_with_3
    {
        private char[,] Pixels => new[,] { { '0', '1', '2', '3', '4', '5' }, { '6', '7', '8', '9', 'A', 'B' }, { 'C', 'D', 'E', 'F', 'G', 'H' }, { '0', '1', '2', '3', '4', '5' }, { '6', '7', '8', '9', 'A', 'B' }, { 'C', 'D', 'E', 'F', 'G', 'H' } };
        private Grid Subject => new Grid(Pixels);
        private Grid[] _result;

        [SetUp]
        public void Because_of() => _result = Subject.Divide(3);

        [Test]
        public void Result_should_be_4_grids() => Assert.That(_result.Length, Is.EqualTo(4));

        [Test]
        public void First_grid_should_be_upper_left_square() => Assert.That(_result[0].ToString(), Is.EqualTo("012/678/CDE"));
        [Test]
        public void Second_grid_should_be_upper_right_square() => Assert.That(_result[1].ToString(), Is.EqualTo("345/9AB/FGH"));
        [Test]
        public void Third_grid_should_be_lower_left_square() => Assert.That(_result[2].ToString(), Is.EqualTo("012/678/CDE"));
        [Test]
        public void Fourth_grid_should_be_lower_right_square() => Assert.That(_result[3].ToString(), Is.EqualTo("345/9AB/FGH"));
    }
}

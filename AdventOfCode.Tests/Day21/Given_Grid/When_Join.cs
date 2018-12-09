using AdventOfCode.Day21;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day21.Given_Grid
{
    [TestFixture]
    class When_Join
    {
        private readonly Grid[] _parts = {
            new Grid(new[,]{{'1', '2'},{'3','4'}}),     //12|56
            new Grid(new[,]{{'5', '6'},{'7','8'}}),     //34|78
            new Grid(new[,]{{'A', 'B'},{'C','D'}}),     //-----
            new Grid(new[,]{{'E', 'F'},{'G','H'}}),     //AB|EF
        };                                              //CD|GH
        private readonly Grid _expected = new Grid(new[,] { { '1', '2', '5', '6' }, { '3', '4', '7', '8', }, { 'A', 'B', 'E', 'F' }, { 'C', 'D', 'G', 'H' } });
        private Grid _result;

        [SetUp]
        public void Because_of() => _result = Grid.Join(_parts);

        [Test]
        public void Result_should_be_equal_to_expected() => Assert.That(_result.Equals(_expected));

    }
}

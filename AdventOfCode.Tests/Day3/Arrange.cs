using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day3;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day3
{
    public abstract class Arrange
    {
        protected ManhattanDistance Subject;

        [SetUp]
        public void SetupBase()
        {
            Subject = new ManhattanDistance();
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day13;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day13.Given_Layer
{
    public abstract class Arrange
    {
        protected Firewall.Layer Subject;
        protected virtual int ScannerPosition => 0;

        [SetUp]
        public void SetupBase()
        {
            Subject = new Firewall.Layer(0, 3, ScannerPosition);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day18
{
    public class Duet
    {
        public Queue<long> Messages { get; }
        public IDictionary<string, long> Registers { get; }

        public Duet()
        {
            Registers = new Dictionary<string, long>();
            Messages = new Queue<long>();
        }

    }
}

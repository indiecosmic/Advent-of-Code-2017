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
        public int Id { get; }
        public Queue<long> Messages { get; }
        public IDictionary<string, long> Registers { get; }
        public bool Waiting { get; set; }

        public Duet Partner { get; set; }
        public int MessagesSent { get; set; }

        public Duet(int id)
        {
            Id = id;
            Registers = new Dictionary<string, long>();
            Messages = new Queue<long>();
            Registers["p"] = id;
        }

        public void Connect(Duet partner)
        {
            Partner = partner;
            partner.Partner = this;
        }

    }
}

using System.Collections.Generic;

namespace AdventOfCode.Day23
{
    public class Register
    {
        public IDictionary<string, long> Registers { get; }
        public int MulCount = 0;

        public Register()
        {
            Registers  = new Dictionary<string, long>();
        }
        
    }
}

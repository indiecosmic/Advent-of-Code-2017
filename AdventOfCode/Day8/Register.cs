using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day8
{
    public class Register
    {
        private readonly Dictionary<string, int> _registers;

        private Register(Dictionary<string, int> register)
        {
            _registers = register;
        }

        public static Register Create(string input)
        {
            return null;
        }

        private static string[] ParseRegisterNames(string input)
        {
            return null;

            var registers = new Dictionary<string, int>();
            var instructions = input.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var instruction in instructions)
            {
                
            }
        }
    }
}

using System;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day18
{
    public abstract class Instruction
    {
        private readonly long _numericValue;

        public string RegisterName { get; }
        protected string Value { get; }
        protected bool IsNumeric { get; }
        
        protected long NumericValue => _numericValue;

        protected Instruction(string registerName)
        {
            RegisterName = registerName;
        }

        protected Instruction(string registerName, string value)
        {
            RegisterName = registerName;
            Value = value;
            if (long.TryParse(value, out _numericValue))
            {
                IsNumeric = true;
            }
        }

        public abstract int Execute(Duet state);

        private const string Pattern = @"^(?<instruction>\w+)\s(?<register>\w+)(?:\s(?<value>[-]?\d+|\w+))?$";
        private static readonly Regex Regex = new Regex(Pattern, RegexOptions.Multiline);
        

        public static Instruction Parse(string input)
        {
            var match = Regex.Match(input);
            switch (match.Groups["instruction"].Value)
            {
                case "snd":
                    return new Snd(match.Groups["register"].Value);
                case "set":
                    return new Set(match.Groups["register"].Value, match.Groups["value"].Value);
                case "add":
                    return new Add(match.Groups["register"].Value, match.Groups["value"].Value);
                case "mul":
                    return new Mul(match.Groups["register"].Value, match.Groups["value"].Value);
                case "mod":
                    return new Mod(match.Groups["register"].Value, match.Groups["value"].Value);
                case "rcv":
                    return new Rcv(match.Groups["register"].Value);
                case "jgz":
                    return new Jgz(match.Groups["register"].Value, match.Groups["value"].Value);
            }
            throw new ArgumentException("Unknown instruction");
        }
    }

    public class Snd : Instruction
    {
        public Snd(string registerName)
            : base(registerName)
        {
        }

        public override int Execute(Duet state)
        {
            state.Messages.Enqueue(state.Registers[RegisterName]);
            return 1;
        }
    }

    public class Set : Instruction
    {
        public Set(string registerName, string value)
            : base(registerName, value)
        {
        }

        public override int Execute(Duet state)
        {
            if (IsNumeric)
            {
                state.Registers[RegisterName] = NumericValue;
            }
            else
            {
                state.Registers[RegisterName] = state.Registers[Value];
            }
            return 1;
        }
    }

    public class Add : Instruction
    {
        public Add(string registerName, string value)
            : base(registerName, value)
        {
        }

        public override int Execute(Duet state)
        {
            if (IsNumeric)
            {
                state.Registers[RegisterName] += NumericValue;
            }
            else
            {
                state.Registers[RegisterName] += state.Registers[Value];
            }
            return 1;
        }
    }

    public class Mul : Instruction
    {
        public Mul(string registerName, string value)
            : base(registerName, value)
        {
        }

        public override int Execute(Duet state)
        {
            if (IsNumeric)
            {
                state.Registers[RegisterName] *= NumericValue;
            }
            else
            {
                state.Registers[RegisterName] *= state.Registers[Value];
            }
            return 1;
        }
    }

    public class Mod : Instruction
    {
        public Mod(string registerName, string value)
            : base(registerName, value)
        {
        }

        public override int Execute(Duet state)
        {
            if (IsNumeric)
            {
                state.Registers[RegisterName] %= NumericValue;
            }
            else
            {
                state.Registers[RegisterName] %= state.Registers[Value];
            }
            return 1;
        }
    }

    public class Rcv : Instruction
    {
        public Rcv(string registerName)
            : base(registerName)
        {
        }

        public override int Execute(Duet state)
        {
            if (state.Messages.Count == 0)
                return 0;

            state.Registers[RegisterName] = state.Messages.Dequeue();
            return 1;
        }
    }

    public class Jgz : Instruction
    {
        public Jgz(string registerName, string value)
            : base(registerName, value)
        {

        }

        public override int Execute(Duet state)
        {
            if (state.Registers[RegisterName] <= 0)
            {
                return 1;
            }

            return IsNumeric ? (int)NumericValue : (int)state.Registers[Value];
        }
    }
}

﻿using System;
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
        public override string ToString()
        {
            return $"{this.GetType().Name} {RegisterName} {Value}";
        }

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
            var value = Regex.IsMatch(RegisterName, "^[a-z]*$")
                ? state.Registers[RegisterName] :
                Convert.ToInt64(RegisterName);

            var target = state.Partner ?? state;
            target.Messages.Enqueue(value);
            state.MessagesSent++;

            Console.WriteLine($"{state.Id} sent {value} to {target.Id}");

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
                state.Registers[RegisterName] = state.Registers[RegisterName] % NumericValue;
            }
            else
            {
                state.Registers[RegisterName] = state.Registers[RegisterName] % state.Registers[Value];
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
            state.Waiting = state.Messages.Count == 0;
            if (state.Waiting) { 
                Console.WriteLine($"{state.Id} is waiting.");
                return 0;
            }

            var receivedValue = state.Messages.Dequeue();

            Console.WriteLine($"{state.Id} received {receivedValue}");

            state.Registers[RegisterName] = receivedValue;
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
            if (Regex.IsMatch(RegisterName, "^[a-z]*$"))
            {
                if (state.Registers[RegisterName] > 0)
                    return IsNumeric ? (int)NumericValue : (int)state.Registers[Value];
            }
            else
            {
                if (Convert.ToInt32(RegisterName) > 0)
                    return IsNumeric ? (int)NumericValue : (int)state.Registers[Value];
            }
            return 1;
        }
    }
}

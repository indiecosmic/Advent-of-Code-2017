using System;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day23
{
    public abstract class Instruction
    {
        private const string Pattern = @"^(?<instruction>\w+)\s(?<register>\w+)(?:\s(?<value>[-]?\d+|\w+))?$";
        protected const string NumericPattern = @"^[-]?\d+$";

        private static readonly Regex Regex = new Regex(Pattern, RegexOptions.Multiline);

        public static Instruction Parse(string input)
        {
            var match = Regex.Match(input);
            switch (match.Groups["instruction"].Value)
            {
                case "set":
                    return new Set(match.Groups["register"].Value, match.Groups["value"].Value);
                case "jnz":
                    return new Jnz(match.Groups["register"].Value, match.Groups["value"].Value);
                case "mul":
                    return new Mul(match.Groups["register"].Value, match.Groups["value"].Value);
                case "sub":
                    return new Sub(match.Groups["register"].Value, match.Groups["value"].Value);
            }
            throw new ArgumentException($"Unknown instruction: {match.Groups["instruction"].Value}");
        }

        public abstract int Execute(Register state);
    }
    
    public class Set : Instruction
    {
        private readonly string _registerName;
        private readonly string _value;
        private readonly bool _isNumeric;

        public Set(string registerName, string value)
        {
            _registerName = registerName;
            _value = value;
            _isNumeric = Regex.IsMatch(_value, NumericPattern);
        }

        public override int Execute(Register state)
        {
            if (!state.Registers.ContainsKey(_registerName))
                state.Registers[_registerName] = 0;

            if (_isNumeric)
            {
                var value = long.Parse(_value);
                state.Registers[_registerName] = value;
            }
            else
            {
                state.Registers[_registerName] = state.Registers[_value];
            }
            return 1;
        }
    }

    public class Jnz : Instruction
    {
        private readonly string _registerName;
        private readonly string _value;
        private readonly bool _isNumeric;

        public Jnz(string registerName, string value)
        {
            _registerName = registerName;
            _value = value;
            _isNumeric = Regex.IsMatch(_registerName, NumericPattern);
        }

        public override int Execute(Register state)
        {
            if (!state.Registers.ContainsKey(_registerName))
                state.Registers[_registerName] = 0;

            var condition = _isNumeric ? long.Parse(_registerName) : state.Registers[_registerName];
            return condition != 0 ? int.Parse(_value) : 1;
        }
    }

    public class Mul : Instruction
    {
        private readonly string _registerName;
        private readonly string _value;
        private readonly bool _isNumeric;

        public Mul(string registerName, string value)
        {
            _registerName = registerName;
            _value = value;
            _isNumeric = Regex.IsMatch(_value, NumericPattern);
        }

        public override int Execute(Register state)
        {
            if (!state.Registers.ContainsKey(_registerName))
                state.Registers[_registerName] = 0;

            var value = _isNumeric ? long.Parse(_value) : state.Registers[_value];
            state.Registers[_registerName] *= value;
            state.MulCount++;

            return 1;
        }
    }

    public class Sub : Instruction
    {
        private readonly string _registerName;
        private readonly string _value;
        private readonly bool _isNumeric;

        public Sub(string registerName, string value)
        {
            _registerName = registerName;
            _value = value;
            _isNumeric = Regex.IsMatch(_value, NumericPattern);
        }

        public override int Execute(Register state)
        {
            if (!state.Registers.ContainsKey(_registerName))
                state.Registers[_registerName] = 0;

            var value = _isNumeric ? long.Parse(_value) : state.Registers[_value];
            state.Registers[_registerName] -= value;

            return 1;
        }
    }
}

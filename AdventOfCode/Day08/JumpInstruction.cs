using System;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day08
{
    public class JumpInstruction
    {
        public string TargetRegister { get; }
        public string ConditionRegister { get; }
        public Operations Operation { get; }
        public int OperationValue { get; }
        public Conditions Condition { get; }
        public int ConditionValue { get; }

        public JumpInstruction(string targetRegister, string conditionRegister, Operations operation, int operationValue, Conditions condition, int conditionValue)
        {
            TargetRegister = targetRegister;
            ConditionRegister = conditionRegister;
            Operation = operation;
            OperationValue = operationValue;
            Condition = condition;
            ConditionValue = conditionValue;
        }

        public bool ShouldApplyTo(int compareTo)
        {
            switch (Condition)
            {
                case Conditions.Equals:
                    return compareTo == ConditionValue;
                case Conditions.Greater:
                    return compareTo > ConditionValue;
                case Conditions.GreaterOrEquals:
                    return compareTo >= ConditionValue;
                case Conditions.Less:
                    return compareTo < ConditionValue;
                case Conditions.LessOrEquals:
                    return compareTo <= ConditionValue;
                case Conditions.NotEquals:
                    return compareTo != ConditionValue;
                default: return false;
            }
        }

        public int ApplyTo(int target, int compareTo)
        {
            if (!ShouldApplyTo(compareTo))
                return target;

            if (Operation == Operations.Increase)
                return target + OperationValue;
            return target - OperationValue;
        }

        public static JumpInstruction Parse(string instruction)
        {
            var regex = new Regex(@"^(?<target>\w+)[\s](?<op>(inc)|(dec))[\s](?<oval>[-]?\d+)[\s]if[\s](?<src>\w+)[\s](?<cond>[<>=!]+)[\s](?<cval>[-]?\d+)");
            var match = regex.Match(instruction);
            var target = match.Groups["target"].Value;
            var source = match.Groups["src"].Value;
            var operation = ParseOperation(match.Groups["op"].Value);
            var operationValue = Convert.ToInt32(match.Groups["oval"].Value);
            var condition = ParseCondition(match.Groups["cond"].Value);
            var conditionValue = Convert.ToInt32(match.Groups["cval"].Value);

            return new JumpInstruction(target, source, operation, operationValue, condition, conditionValue);
        }

        private static Conditions ParseCondition(string condition)
        {
            switch (condition)
            {
                case ">":
                    return Conditions.Greater;
                case ">=":
                    return Conditions.GreaterOrEquals;
                case "<":
                    return Conditions.Less;
                case "<=":
                    return Conditions.LessOrEquals;
                case "==":
                    return Conditions.Equals;
                case "!=":
                    return Conditions.NotEquals;
                default: throw new ArgumentException($"unknown condition {condition}");
            }
        }

        private static Operations ParseOperation(string operation)
        {
            return operation == "inc" ? Operations.Increase : Operations.Decrease;
        }

        public enum Operations
        {
            Increase,
            Decrease
        }

        public enum Conditions
        {
            Greater,
            Less,
            GreaterOrEquals,
            LessOrEquals,
            Equals,
            NotEquals
        }
    }
}

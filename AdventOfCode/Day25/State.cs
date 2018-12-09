using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day25
{
    public class State
    {
        public string Name { get; set; }

        public List<Branch> Branches { get; } = new List<Branch>();

        public Branch PositiveBranch { get; set; }
        public Branch NegativeBranch { get; set; }


        private readonly int _writeValue;
        private readonly Direction _direction;

        public enum Direction
        {
            Left,
            Right
        }

        public class Branch
        {
            public int Condition { get; }
            public int WriteValue { get; set; }
            public Direction MoveDirection { get; set; }
            public string NextState { get; set; }

            public Branch(int condition)
            {
                Condition = condition;
            }
        }

        public State()
        {
            
        }

        public State(int writeValue, Direction direction)
        {
            _writeValue = writeValue;
            _direction = direction;
        }

        public State NextStateIfOne { get; set; }
        public State NextStateIfZero { get; set; }

        public static State Parse(string input)
        {
            return null;
        }

        public string Run(Tape tape)
        {
            var branch = Branches.First(b => b.Condition == tape.CurrentValue);
            tape.CurrentValue = branch.WriteValue;
            if (branch.MoveDirection == Direction.Left)
            {
                tape.MoveLeft();
            }
            else
            {
                tape.MoveRight();
            }
            return branch.NextState;
        }
    }
}

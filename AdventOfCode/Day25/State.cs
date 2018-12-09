using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day25
{
    public class State
    {
        public string Name { get; set; }

        public List<Branch> Branches { get; } = new List<Branch>();

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
    }
}

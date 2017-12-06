using System.Text;

namespace AdventOfCode.Day5
{
    public class Maze
    {
        private readonly int[] _state;
        private readonly IOffsetRule _offsetRule;
        private int _currentPosition;

        public bool CanJump => JumpAllowed(_state, _currentPosition);

        public Maze(int[] initialState, IOffsetRule offsetRule)
        {
            _state = initialState;
            _offsetRule = offsetRule;
            _currentPosition = 0;
        }

        public static bool JumpAllowed(int[] state, int position)
        {
            var offset = state[position];
            var newPosition = offset + position;
            return newPosition >= 0 && newPosition < state.Length;
        }

        public bool Jump()
        {
            if (!JumpAllowed(_state, _currentPosition)) return false;

            var offSet = _state[_currentPosition];
            var newPosition = _currentPosition + offSet;

            _offsetRule.Apply(_state, _currentPosition);
            _currentPosition = newPosition;
            return true;
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            for (var i = 0; i < _state.Length; i++)
            {
                str.Append(i == _currentPosition
                    ? ("(" + _state[i] + ")").PadLeft(5, ' ')
                    : _state[i].ToString().PadLeft(5, ' '));
            }

            return str.ToString();
        }
    }

    public interface IOffsetRule
    {
        void Apply(int[] state, int position);
    }

    public class SimpleOffsetRule : IOffsetRule
    {
        public void Apply(int[] state, int position)
        {
            state[position] += 1;
        }
    }

    public class ComplexOffsetRule : IOffsetRule
    {
        public void Apply(int[] state, int position)
        {
            if (state[position] >= 3) state[position] -= 1;
            else state[position] += 1;
        }
    }
}

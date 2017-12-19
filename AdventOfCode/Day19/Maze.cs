using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day19
{
    public class Maze
    {
        private static readonly (int, int) Left = (0, -1);
        private static readonly (int, int) Right = (0, 1);
        private static readonly (int, int) Up = (-1, 0);
        private static readonly (int, int) Down = (1, 0);

        private char Current => _state[_location.Item1, _location.Item2];

        private readonly char[,] _state;
        private (int, int) _location;
        private (int, int) _direction;

        public string Letters { get; private set; }
        public int Count { get; private set; }

        public Maze(char[,] state, (int, int) location)
        {
            _state = state;
            _location = location;
            _direction = Down;
            Letters = "";
            Count = 1;
        }

        public bool CanMove()
        {
            var row = _location.Item1 + _direction.Item1;
            var col = _location.Item2 + _direction.Item2;

            if (row < 0 || row > _state.GetLength(0) - 1)
                return false;
            if (col < 0 || col > _state.GetLength(1) - 1)
                return false;

            return _state[row, col] != ' ';
        }

        public void Move()
        {
            _location = (_location.Item1 + _direction.Item1, _location.Item2 + _direction.Item2);
            Count++;
            if (Regex.IsMatch(Current.ToString(), @"\w", RegexOptions.IgnoreCase))
            {
                Letters += Current;
            }
        }

        public void Turn()
        {
            if (_direction.Equals(Down) || _direction.Equals(Up))
            {
                _direction = Left;
                if (CanMove())
                    return;
                _direction = Right;
            }
            else
            {
                _direction = Down;
                if (CanMove())
                    return;
                _direction = Up;
            }
        }

        public bool AtFinish()
        {
            if (!CanMove())
            {
                return Regex.IsMatch(Current.ToString(), @"\w", RegexOptions.IgnoreCase);
            }
            return false;
        }
        
        public static Maze Parse(string input)
        {
            var rows = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var state = new char[rows.Length, rows[0].Length];
            for (var row = 0; row < rows.Length; row++)
            {
                for (var col = 0; col < rows[row].Length; col++)
                {
                    state[row, col] = rows[row][col];
                }
            }

            var start = (0, 0);
            for (var x = 0; x < state.GetLength(1); x++)
                if (state[0, x] == '|')
                    start = (0, x);

            return new Maze(state, start);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day22
{
    public class Virus
    {
        public (int, int) Position { get; private set; }
        private (int, int) _direction;
        public int InfectionCount { get; private set; }

        public Virus((int, int) position, (int, int) direction)
        {
            Position = position;
            _direction = direction;
        }

        public Map Work(Map map)
        {
            var state = new Map(map);

            if (state.IsInfected(Position))
            {
                _direction = TurnRight(_direction);
                state.Clean(Position);
            }
            else
            {
                _direction = TurnLeft(_direction);
                state.Infect(Position);
                InfectionCount++;
            }

            Position = (Position.Item1 + _direction.Item1, Position.Item2 + _direction.Item2);
            return state;
        }
        

        public IDictionary<(int,int), char> Work(IDictionary<(int,int), char> map)
        {
            var state = map.ToDictionary(entry => entry.Key, entry => entry.Value);
            if (!state.ContainsKey(Position))
                state.Add(Position, '.');

            if (state[Position] == '#')
            {
                _direction = TurnRight(_direction);
                state[Position] = '.';
            }
            else
            {
                _direction = TurnLeft(_direction);
                state[Position] = '#';
                InfectionCount++;
            }

            Position = (Position.Item1 + _direction.Item1, Position.Item2 + _direction.Item2);
            return state;
        }

        public static (int, int) TurnRight((int, int) direction)
        {
            if (Math.Abs(direction.Item1) > 0)
            {
                direction.Item2 = -direction.Item1;
                direction.Item1 = 0;
            }
            else if (Math.Abs(direction.Item2) > 0)
            {
                direction.Item1 = direction.Item2;
                direction.Item2 = 0;
            }
            return direction;
        }

        public static (int, int) TurnLeft((int, int) direction)
        {
            if (Math.Abs(direction.Item1) > 0)
            {
                direction.Item2 = direction.Item1;
                direction.Item1 = 0;
            }
            else if (Math.Abs(direction.Item2) > 0)
            {
                direction.Item1 = -direction.Item2;
                direction.Item2 = 0;
            }
            return direction;
        }

    }
}

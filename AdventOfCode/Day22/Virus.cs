namespace AdventOfCode.Day22
{
    public class Virus
    {
        public (int, int) Position { get; protected set; }
        protected (int, int) Direction;
        public int InfectionCount { get; protected set; }

        public Virus((int, int) position, (int, int) direction)
        {
            Position = position;
            Direction = direction;
        }

        public virtual Map Work(Map map)
        {
            var state = new Map(map);

            if (state.GetState(Position) == Map.NodeState.Infected)
            {
                Direction = TurnRight(Direction);
                state.Clean(Position);
            }
            else
            {
                Direction = TurnLeft(Direction);
                state.Infect(Position);
                InfectionCount++;
            }

            Position = MoveForward(Position, Direction);
            return state;
        }

        protected static (int, int) MoveForward((int, int) position, (int, int) direction)
        {
            return (position.Item1 + direction.Item1, position.Item2 + direction.Item2);
        }

        protected static (int, int) Reverse((int, int) direction)
        {
            return (-direction.Item1, -direction.Item2);
        }

        public static (int, int) TurnRight((int, int) direction)
        {
            if (direction.Equals(Day22.Direction.Up))
                return Day22.Direction.Right;
            if (direction.Equals(Day22.Direction.Right))
                return Day22.Direction.Down;
            return direction.Equals(Day22.Direction.Down) ? Day22.Direction.Left : Day22.Direction.Up;
        }

        public static (int, int) TurnLeft((int, int) direction)
        {
            if (direction.Equals(Day22.Direction.Up))
                return Day22.Direction.Left;
            if (direction.Equals(Day22.Direction.Left))
                return Day22.Direction.Down;
            return direction.Equals(Day22.Direction.Down) ? Day22.Direction.Right : Day22.Direction.Up;
        }

    }
}

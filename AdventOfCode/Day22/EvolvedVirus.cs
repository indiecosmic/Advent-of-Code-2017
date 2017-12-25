namespace AdventOfCode.Day22
{
    public class EvolvedVirus : Virus
    {
        public EvolvedVirus((int, int) position, (int, int) direction) : base(position, direction)
        {
        }

        public override Map Work(Map state)
        {
            var nodeState = state.GetState(Position);

            switch (nodeState)
            {
                case Map.NodeState.Clean:
                    Direction = TurnLeft(Direction);
                    state.Weaken(Position);
                    break;
                case Map.NodeState.Infected:
                    Direction = TurnRight(Direction);
                    state.Flag(Position);
                    break;
                case Map.NodeState.Flagged:
                    Direction = Reverse(Direction);
                    state.Clean(Position);
                    break;
                default:
                    state.Infect(Position);
                    InfectionCount++;
                    break;
            }

            Position = MoveForward(Position, Direction);

            return state;
        }
    }
}

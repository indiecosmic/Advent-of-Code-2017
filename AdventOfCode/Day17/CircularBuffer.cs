using System.Collections.Generic;

namespace AdventOfCode.Day17
{
    public class CircularBuffer
    {
        private readonly IList<int> _state;

        public int CurrentPosition { get; private set; }

        public CircularBuffer(int[] initialState, int currentPosition)
        {
            CurrentPosition = currentPosition;
            _state = new List<int>(initialState);
        }

        public int StepForward(int times)
        {
            var newIndex = CurrentPosition;
            for (var i = 0; i < times; i++)
            {
                newIndex++;
                if (newIndex > _state.Count - 1)
                    newIndex = 0;
            }
            CurrentPosition = newIndex;
            return newIndex;
        }

        public int ValueAt(int index)
        {
            return _state[index];
        }

        public int IndexOf(int value)
        {
            return _state.IndexOf(value);
        }

        public void Insert(int value)
        {
            _state.Insert(CurrentPosition + 1, value);
            CurrentPosition++;
        }
    }
}

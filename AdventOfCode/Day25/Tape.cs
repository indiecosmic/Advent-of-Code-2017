using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day25
{
    public class Tape
    {
        private readonly LinkedList<int> _tape; 
        private LinkedListNode<int> _current;
        public Tape()
        {
            _tape = new LinkedList<int>(new[] { 0 });
            _current = _tape.First;
        }

        public int CurrentValue
        {
            get => _current.Value;
            set => _current.Value = value;
        }

        public int Checksum => _tape.Sum();

        public void MoveLeft()
        {
            var moveTo = _current.Previous;
            if (moveTo == null)
            {
                moveTo = new LinkedListNode<int>(0);
                _tape.AddBefore(_current, moveTo);
            }
            _current = moveTo;
        }

        public void MoveRight()
        {
            var moveTo = _current.Next;
            if (moveTo == null)
            {
                moveTo = new LinkedListNode<int>(0);
                _tape.AddAfter(_current, moveTo);
            }
            _current = moveTo;
        }
    }
}

namespace AdventOfCode.Day17
{
    public class Spinlock
    {
        private readonly CircularBuffer _buffer;

        public Spinlock()
        {
            _buffer = new CircularBuffer(new[] { 0 }, 0);
        }

        public int Repeat(int times, int step)
        {
            for (var i = 1; i <= times; i++)
            {
                _buffer.StepForward(step);
                _buffer.Insert(i);
            }
            return _buffer.ValueAt(_buffer.CurrentPosition + 1);
        }
        
        public int RepeatAndReturnValueAt1(int times, int step)
        {
            var size = 411;
            var currentPosition = 1;
            var currentResult = 0;
            for (var i = 410; i <= times; i++)
            {
                var nextPosition = currentPosition + step;
                currentPosition = nextPosition > size - 1 ? nextPosition - size : nextPosition;
                size++;
                currentPosition++;
                
                if (currentPosition == 1)
                    currentResult = i+1;
            }

            return currentResult;
        }
    }
}

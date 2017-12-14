using System.Linq;

namespace AdventOfCode.Day10
{
    public class ListReverser
    {
        public void Reverse(int[] numbers, int position, int length)
        {
            var subArray = new int[length];
            for (var i = 0; i < length; i++)
            {
                var currentPos = position + i < numbers.Length ? position + i : position + i - numbers.Length;
                subArray[i] = numbers[currentPos];
            }
            subArray = subArray.Reverse().ToArray();
            for (var i = 0; i < length; i++)
            {
                var currentPos = position + i < numbers.Length ? position + i : position + i - numbers.Length;
                numbers[currentPos] = subArray[i];
            }
        }
    }
}

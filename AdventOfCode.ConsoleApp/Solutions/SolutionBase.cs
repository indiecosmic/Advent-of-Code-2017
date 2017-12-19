using System.IO;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal abstract class SolutionBase
    {
        protected string GetInput(bool trim = true)
        {
            var filename = $"inputs/{GetType().Name.ToLower()}.txt";
            using (var reader = new StreamReader(filename))
            {
                var input = reader.ReadToEnd();
                return trim ? input.Trim() : input;
            }
        }

        public abstract void Run();
    }
}

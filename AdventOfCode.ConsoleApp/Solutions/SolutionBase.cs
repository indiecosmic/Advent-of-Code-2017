using System.IO;

namespace AdventOfCode.ConsoleApp.Solutions
{
    internal abstract class SolutionBase
    {
        protected string GetInput()
        {
            var filename = $"inputs/{GetType().Name.ToLower()}.txt";
            using (var reader = new StreamReader(filename))
            {
                return reader.ReadToEnd().Trim();
            }
        }

        public abstract void Run();
    }
}

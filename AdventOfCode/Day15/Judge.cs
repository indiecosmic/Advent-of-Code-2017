namespace AdventOfCode.Day15
{
    public abstract class Judge
    {
        public static int JudgePairs(Generator generatorA, Generator generatorB, int iterations)
        {
            var total = 0;
            for (var i = 0; i < iterations; i++)
            {
                var valueA = generatorA.GenerateNextOptimized();
                var valueB = generatorB.GenerateNextOptimized();
                if (valueA == valueB)
                    total++;
            }

            return total;
        }
    }
}

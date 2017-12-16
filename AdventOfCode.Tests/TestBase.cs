using NUnit.Framework;

namespace AdventOfCode.Tests
{
    public abstract class TestBase<T> where T : class
    {
        protected DependencyMocker DependencyMocker { get; private set; }
        protected T Subject { get; private set; }

        [SetUp]
        public void TestBaseSetup()
        {
            DependencyMocker = new DependencyMocker();
            Subject = DependencyMocker.New<T>();
        }
    }
}

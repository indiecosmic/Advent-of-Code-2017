using System.Reflection.Emit;
using AdventOfCode.Day8;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day8.Given_JumpInstruction
{
    [TestFixture]
    public class When_ParseInstruction : Arrange
    {
        [TestCase("a inc 1 if b < 5", "a", "b", JumpInstruction.Operations.Increase, JumpInstruction.Conditions.Less, 1, 5)]
        [TestCase("c dec -10 if a >= 1", "c", "a", JumpInstruction.Operations.Decrease, JumpInstruction.Conditions.GreaterOrEquals, -10, 1)]
        [TestCase("c inc -20 if c == 10", "c", "c", JumpInstruction.Operations.Increase, JumpInstruction.Conditions.Equals, -20, 10)]
        [TestCase("aw dec 633 if zsx <= -5", "aw", "zsx", JumpInstruction.Operations.Decrease, JumpInstruction.Conditions.LessOrEquals, 633, -5)]
        [TestCase("db inc 661 if kcr != -9", "db", "kcr", JumpInstruction.Operations.Increase, JumpInstruction.Conditions.NotEquals, 661, -9)]
        public void ResultShouldBe(string input, string target, string source, JumpInstruction.Operations operation, JumpInstruction.Conditions condition, int operationValue, int conditionValue)
        {
            var result = JumpInstruction.Parse(input);
            Assert.AreEqual(target, result.TargetRegister);
            Assert.AreEqual(source, result.ConditionRegister);
            Assert.AreEqual(operation, result.Operation);
            Assert.AreEqual(condition, result.Condition);
            Assert.AreEqual(operationValue, result.OperationValue);
            Assert.AreEqual(conditionValue, result.ConditionValue);
        }

        [Test]
        public void TargetRegister_should_be_b() => Assert.AreEqual("b", Result.TargetRegister);

        [Test]
        public void ConditionRegister_should_be_a() => Assert.AreEqual("a", Result.ConditionRegister);

        [Test]
        public void Operation_should_be_Increase() => Assert.AreEqual(JumpInstruction.Operations.Increase, Result.Operation);

        [Test]
        public void OperationValue_should_be_5() => Assert.AreEqual(5, Result.OperationValue);

        [Test]
        public void Condition_should_be_Greater() => Assert.AreEqual(JumpInstruction.Conditions.Greater, Result.Condition);

        [Test]
        public void ConditionValue_should_be_1() => Assert.AreEqual(1, Result.ConditionValue);
    }
}

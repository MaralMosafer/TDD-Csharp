using FluentAssertions;
using Xunit;

namespace EvenOrOdd.Tests
{
    public class EvaluationTests
    {
        [Fact]
        public void Should_ReturnEven()
        {
            //Arrange => setup
            const int input = 2;

            //Act => exercise
            var actual = Evaluation.Evaluator(input);

            //Assert => verify
            actual.Should().Be("Even");
        }

        [Fact]
        public void Should_ReturnOdd()
        {
            //Arrange => setup
            const int input = 3;

            //Act => exercise
            var actual = Evaluation.Evaluator(input);

            //Assert => verify
            actual.Should().Be("Odd");
        }
    }
}
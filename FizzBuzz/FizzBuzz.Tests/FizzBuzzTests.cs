using FluentAssertions;
using Xunit;

namespace FizzBuzz.Tests
{
    public class FizzBuzzTests
    {
        [Fact]
        public void Should_ReturnAListWithGivenRoundsLenght()
        {
            //arrange => setup
            const int rounds = 100; //1-100

            //act => exercise
            var actual = FizzBuzz.Start(rounds);

            //assert => verify
            actual.Count.Should().Be(rounds);
        }
        [Theory]
        [InlineData("Fizz", 2)]
        [InlineData("Buzz", 4)]
        [InlineData("FizzBuzz", 14)]
        public void Should_ReturnAListWithProperValuesWithGivenElements(string expected, int element)
        {
            //arrange => setup
            const int rounds = 100;

            //act => exercise
            var actual = FizzBuzz.Start(rounds);

            //assert => verify
            actual[element].Should().Be(expected);
        }
    }
}
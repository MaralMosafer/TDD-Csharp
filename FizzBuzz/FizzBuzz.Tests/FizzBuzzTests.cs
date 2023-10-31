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
            var fizzBuzz = new FizzBuzz();

            //act => exercise
            var actual = fizzBuzz.Start(rounds);

            //assert => verify
            actual.Count.Should().Be(rounds);
        }
    }
}
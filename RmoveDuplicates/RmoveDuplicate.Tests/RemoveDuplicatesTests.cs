using Xunit;
namespace RmoveDuplicate.Tests
{
    public class RemoveDuplicatesTests
    {
        [Fact]
        public void Should_ReturnsCorrectResultWithRemoveDuplicates()
        {
            //Arrange
            List<int> input = new List<int> { 1, 2, 2, 3, 4, 4, 5 };
            List<int> expected = new List<int> { 1, 2, 3, 4, 5 };

            //Act
            var removeDuplicates = new RemoveDuplicates.RemoveDuplicates();
            var actual = removeDuplicates.RemoveDuplicatesFromList(input);

            //Assert
            Assert.Equal(expected, actual);
            //actual.Should().BeEquivalentTo(expected);
        }
    }
}
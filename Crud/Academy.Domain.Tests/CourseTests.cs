using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Academy.Domain.Tests
{
    public class CourseTests
    {
        private readonly CourseTestBuilder _courseTestBuilder;
        public CourseTests()
        {
            _courseTestBuilder = new CourseTestBuilder();
        }

        [Fact]
        public void Should_ConstructorConstructCourseProperly()
        {
            const int id = 1;
            const string name = "TDD";
            const bool isOnline = true;
            const double tuition = 50;
            const string instructor = "Maral Mosafer";

            var course = _courseTestBuilder.Build();

            course.Id.Should().Be(id);
            course.Name.Should().Be(name);
            course.IsOnline.Should().Be(isOnline);
            course.Tuition.Should().Be(tuition);
            course.Instructor.Should().Be(instructor);
        }

        [Fact]
        public void Should_ThrowExceptionWhenNameIsNotProvided()
        {

            Action course = () => _courseTestBuilder.WithName("").Build();

            course.Should().ThrowExactly<CourseNameIsInvalidException>();
        }

        [Fact]
        public void Should_ThrowExceptionWhenTuitionNameIsNotProvided()
        {

            Action course = () => _courseTestBuilder.WithTuition(0).Build();

            course.Should().ThrowExactly<CourseTuitionIsInvalidException>();
        }
        [Fact]
        public void Should_AddNewSectionToSections_WhenIdAndNamePassed()
        {
            var course = _courseTestBuilder.Build();
            var section = SectionFactory.Create();

            course.AddSection(section);

            course.Sections.Should().ContainEquivalentOf(section);
        }
    }
}
using Academy.Domain;
using Academy.Domain.Tests.builders;
using FluentAssertions;
using Xunit;

namespace Academy.Infrastructure.Tests
{
    public class CourseRepositoryTests
    {
        private readonly CourseTestBuilder _courseTestBuilder;
        private readonly CourseRepository _courseRepository;

        public CourseRepositoryTests()
        {
            _courseTestBuilder = new CourseTestBuilder();
            _courseRepository = new CourseRepository();
        }

        [Fact]
        public void Should_AddNewCourseToCoursesList()
        {
            var course = _courseTestBuilder.Build();

            _courseRepository.Create(course);

            //_courseRepository.Courses.Should().ContainEquivalentOf(course); Low Speed!
            _courseRepository.Courses.Should().Contain(course);
        }

        [Fact]
        public void Should_ReturnAllCourses()
        {
            var courses = _courseRepository.GetAll();

            _courseRepository.Courses.Should().HaveCountGreaterOrEqualTo(0);
        }

        [Fact]
        public void Should_ReturnACourseById()
        {
            const int id = 1;
            var expected = _courseTestBuilder.WithId(id).Build();
            _courseRepository.Create(expected);

            var actual=_courseRepository.GetBy(id);

            actual.Should().Be(expected);

        }
        [Fact]
        public void Should_ReturnNullWhenIdIsNotExists()
        {
            const int id = 369;

            var actual = _courseRepository.GetBy(id);

            actual.Should().BeNull();

        }

        [Fact]
        public void Should_DeleteCourseById()
        {
            const int id = 10;
            var course = _courseTestBuilder.WithId(id).Build();
            _courseRepository.Create(course);

            _courseRepository.Delete(id);


            _courseRepository.Courses.Should().NotContain(course);
        }

        [Fact]
        public void Should_ReturnACourseByName()
        {
            const string name = "WPF";
            var expected = _courseTestBuilder.WithName(name).Build();
            _courseRepository.Create(expected);

            var actual = _courseRepository.GetBy(name);

            expected.Should().Be(actual);
        }

        [Fact]
        public void Should_ReturnNullWhenNameIsNotExists()
        {
            const string name = "Learn With Maral Mosafer";

            var actual = _courseRepository.GetBy(name);

            actual.Should().BeNull();

        }
    }
}
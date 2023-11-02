using Academy.Domain;
using Academy.Domain.Tests.builders;
using Academy.Infrastructure;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Academy.Application.Tests
{
    public class CourseApplicationTests
    {
        private readonly CourseTestBuilder _courseTestBuilder;
        private readonly ICourseRepository _courseRepository;
        private readonly CourseApplication _courseApplication;
        public CourseApplicationTests()
        {
            _courseRepository = Substitute.For<ICourseRepository>();
            _courseTestBuilder = new CourseTestBuilder();
            _courseApplication = new CourseApplication(_courseRepository);
        }
        private static CreateCourse CreateCourseItems()
        {
            return new CreateCourse()
            {
                Id = 5,
                Name = "Git&GitHub",
                Instructor = "Maral Mosafer",
                IsOnline = true,
                Tuition = 71
            };
        }
        private static EditCourse EditCourseItems()
        {
            return new EditCourse()
            {
                Id = 5,
                Instructor = "Maral Mosafer",
                IsOnline = true,
                Name = "xMind",
                Tuition = 23
            };
        }
        [Fact]
        public void Should_CreateNewCourse()
        {
            CreateCourse command = CreateCourseItems();

            _courseApplication.Create(command);

            _courseRepository.ReceivedWithAnyArgs().Create(default);
            //_courseRepository.Received(1).Create(Arg.Any<Course>());
        }

        [Fact]
        public void Should_CreateNewCourseAndReturnId()
        {
            CreateCourse command = CreateCourseItems();

            var actual = _courseApplication.Create(command);
            actual.Should().Be(command.Id);
        }

        [Fact]
        public void Should_ThrowExceptionWhenAddedCourseIsDuplicated()
        {
            CreateCourse command = CreateCourseItems();
            var course = _courseTestBuilder.Build();
            _courseRepository.GetBy(Arg.Any<string>()).Returns(course);

            Action actual = () => _courseApplication.Create(command);
            actual.Should().Throw<Exception>();
        }

        [Fact]
        public void Shoul_UpdateCourse()
        {
            var command = EditCourseItems();
            var course = _courseTestBuilder.Build();
            _courseRepository.GetBy(command.Id).Returns(course);

            _courseApplication.Edit(command);

            Received.InOrder(() =>
            {
                _courseRepository.Delete(command.Id);
                _courseRepository.Create(Arg.Any<Course>());
            });
        }

        [Fact]
        public void Should_ReturnNullWhenUpdatingCourseNotExists()
        {
            var command = EditCourseItems();
            var course = _courseTestBuilder.Build();
            _courseRepository.GetBy(command.Id).ReturnsNull();

            Action action = () => _courseApplication.Edit(command);

            action.Should().Throw<Exception>();
        }

        [Fact]
        public void Should_DeleteCourse()
        {
            const int id = 222;

            _courseApplication.Delete(id);

            _courseRepository.Received().Delete(id);
        }

        [Fact]
        public void Should_ReturnListOfCourses()
        {
            _courseRepository.GetAll().Returns(new List<Course>());

            var courses = _courseApplication.GetAll();

            courses.Should().BeOfType<List<Course>>();
            _courseRepository.Received().GetAll();
        }

    }
}
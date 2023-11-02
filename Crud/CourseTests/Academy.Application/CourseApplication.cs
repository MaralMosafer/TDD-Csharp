using Academy.Domain;

namespace Academy.Application
{
    public class CourseApplication
    {
        private readonly ICourseRepository _courseRepository;
        public CourseApplication(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public int Create(CreateCourse command)
        {
            if (_courseRepository.GetBy(command.Name) != null)
                throw new Exception();
            var course = new Course(command.Id, command.Name, command.Instructor, command.Tuition, command.IsOnline);
            _courseRepository.Create(course);
            return course.Id;
        }

        public void Delete(int id)
        {
            _courseRepository.Delete(id);
        }

        public void Edit(EditCourse command)
        {
            if (_courseRepository.GetBy(command.Id) == null)
                throw new Exception();
            _courseRepository.Delete(command.Id);
            var course = new Course(command.Id, command.Name, command.Instructor, command.Tuition, command.IsOnline);
            _courseRepository.Create(course);

        }

        public List<Course> GetAll()
        {
            return _courseRepository.GetAll();
        }
    }
}
using Academy.Domain;

namespace Academy.Infrastructure
{
    public class CourseRepository : ICourseRepository
    {
        public List<Course> Courses { get; set; } = new List<Course>()
        {
            new Course(1,"ASP.NET Core 8","Maral Mosafer",20,true)
        };

        public void Create(Course command)
        {
            Courses.Add(command);
        }

        public void Delete(int id)
        {
            var course = GetBy(id);
            Courses.Remove(course);
        }

        public List<Course> GetAll()
        {
            return Courses;
        }

        public Course GetBy(int id)
        {
            return Courses.FirstOrDefault(c => c.Id == id);
        }
        public Course GetBy(string name)
        {
            return Courses.FirstOrDefault(c => c.Name == name);
        }
    }
}
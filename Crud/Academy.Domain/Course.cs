using Academy.Domain.Tests;

namespace Academy.Domain
{
    public class Course
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Instructor { get; private set; } = string.Empty;
        public double Tuition { get; private set; }
        public bool IsOnline { get; private set; }
        public List<Section> Sections { get; private set; }

        public Course(int id, string name, string instructor, double tuition, bool isOnline)
        {
            GuardAgainstInvalidName(name);
            GuardAgainstInvalidTuition(tuition);

            Id = id;
            Name = name;
            Instructor = instructor;
            Tuition = tuition;
            IsOnline = isOnline;
            Sections = new List<Section>();
        }

        private static void GuardAgainstInvalidTuition(double tuition)
        {
            if (tuition <= 0)
                throw new CourseTuitionIsInvalidException();
        }

        private static void GuardAgainstInvalidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new CourseNameIsInvalidException();
        }

        public void AddSection(Section section)
        {
            Sections.Add(section);
        }
    }
}
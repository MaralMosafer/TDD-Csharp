namespace Academy.Domain.Tests
{
    public class CourseTestBuilder
    {
        private int _id = 1;
        private string _name = "TDD";
        private bool _isOnline = true;
        private double _tuition = 50;
        private string _instructor = "Maral Mosafer";

        public CourseTestBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public Course Build()
        {
            return new Course(_id, _name, _instructor, _tuition, _isOnline);
        }

        public CourseTestBuilder WithTuition(double tuition)
        {
            _tuition = tuition;
            return this;

        }
    }
}
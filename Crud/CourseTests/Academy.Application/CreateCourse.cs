namespace Academy.Application
{
    public class CreateCourse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Instructor { get; set; } = string.Empty;
        public bool IsOnline { get; set; }
        public double Tuition { get; set; }
    }
}
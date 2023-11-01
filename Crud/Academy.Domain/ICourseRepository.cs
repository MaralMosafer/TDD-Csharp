namespace Academy.Domain
{
    public interface ICourseRepository
    {
        void Create(Course command);
        void Delete(int id);
        List<Course> GetAll();
        Course GetBy(int id);
        Course GetBy(string name);

    }
}

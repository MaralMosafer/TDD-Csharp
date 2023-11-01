namespace Academy.Domain
{
    public class Section
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public Section(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

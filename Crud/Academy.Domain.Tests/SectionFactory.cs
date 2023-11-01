namespace Academy.Domain.Tests
{

    public class SectionFactory
    {
        public static Section Create()
        {
            return new Section(1, "Why We Write Tests");
        }
    }

}
namespace RemoveDuplicates
{
    public class RemoveDuplicates
    {
        public List<int> RemoveDuplicatesFromList(List<int> input)
        {
            HashSet<int> uniqueNumbers = new HashSet<int>(input);
            return uniqueNumbers.ToList();
        }
    }
}
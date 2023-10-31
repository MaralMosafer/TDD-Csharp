namespace FizzBuzz
{
    public class FizzBuzz
    {
        public List<string> Start(int rounds)
        {
            var result= new List<string>();
            for (int i = 1; i <= rounds; i++)
            {
                result.Add(i.ToString());
            }
            return result;
        }
    }
}
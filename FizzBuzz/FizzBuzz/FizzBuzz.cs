namespace FizzBuzz
{
    public class FizzBuzz
    {
        public List<string> Start(int rounds)
        {
            var result = new List<string>();
            for (int i = 1; i <= rounds; i++)
            {
                if (i % 15 == 0)
                {
                    result.Add("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    result.Add("Fizz");
                }
                else if (i % 5 == 0)
                {
                    result.Add("Buzz");
                }
                else
                {
                    result.Add(i.ToString());
                }
            }
            return result;
        }
    }
}
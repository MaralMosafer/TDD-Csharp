namespace FizzBuzz
{
    public class FizzBuzz
    {
        public static List<string> Start(int rounds)
        {
            var result = new List<string>();
            for (int i = 1; i <= rounds; i++)
            {
                var output = i % 3 == 0 ? "Fizz" : string.Empty;
                output += i % 5 == 0 ? "Buzz" : string.Empty;
                output += output == string.Empty ? i.ToString() : string.Empty;

                result.Add(output);
            }
            return result;
        }
    }
}
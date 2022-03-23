namespace Operators
{
    public class Addition : IOperator
    {
        public string Code => "+";
        public int Process(int a, int b)
        {
            return a + b;
        }
    }
}

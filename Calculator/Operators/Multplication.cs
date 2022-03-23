namespace Operators
{
    public class Multplication : IOperator
    {
        public string Code => "*";
        public int Process(int a, int b)
        {
            return a * b;
        }
    }
}

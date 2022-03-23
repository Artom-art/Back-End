namespace Operators
{
    public class Division : IOperator
    {
        public string Code => "/";
        public int Process(int a, int b)
        {
            return a / b;
        }
    }
}

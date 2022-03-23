namespace Operators
{
    public class Subtraction : IOperator
    {
        public string Code => "-";
        public int Process(int a, int b)
        {
            return a - b;
        }
    }
}

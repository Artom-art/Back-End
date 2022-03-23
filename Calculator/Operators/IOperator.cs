namespace Operators
{
    public interface IOperator
    {
        string Code { get; }
        int Process(int firstOperand, int secondOperand);
    }
}

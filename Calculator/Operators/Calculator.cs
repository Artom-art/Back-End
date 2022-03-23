using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Operators
{
    public class Calc : ICalculator
    {
        private List<IOperator> _operations;
        public Calc(List<IOperator> operations)
        {
            _operations = operations;
        }

        public int Calculate(string inputStr)
        {
            string[] numbersAndOperations = Regex
               .Replace(inputStr, @"([\d]+)", "'$1'")
               .Split(new[] { '\'' }, StringSplitOptions.RemoveEmptyEntries);

            int result = int.Parse(numbersAndOperations[0]);
            for (int i = 1; i < numbersAndOperations.Length; i += 2)
            {
                string operationCode = numbersAndOperations[i].Trim();
                IOperator operation = _operations.Find(x => x.Code == operationCode);
                int number = int.Parse(numbersAndOperations[i + 1]);
                result = operation.Process(result, number);
            }
            return result;
        }
    }
}

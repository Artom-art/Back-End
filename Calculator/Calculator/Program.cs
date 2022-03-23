using System;
using System.Collections.Generic;
using Operators;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Incorrect number of parameters!");
                return;
            }

            List<IOperator> operations = new List<IOperator>
            {
                new Addition(),
                new Subtraction(),
                new Multplication(),
                new Division()
            };

            ICalculator calculator = new Calc(operations);
            int result = calculator.Calculate(args[0]);

            Console.WriteLine($"Result: {result}");
        }
    }
}

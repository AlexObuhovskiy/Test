using System;
using Test.Domain.Models.Calculator;

namespace Test.Domain.Strategies
{
    public class MultiplyStrategy : ICalculatable
    {
        public int ArgumentCount { get; }

        public MultiplyStrategy()
        {
            ArgumentCount = 2;
        }

        public decimal Calculate(CalculatorModel model)
        {
            if (model.CalculationArguments.Count != 2)
            {
                throw new ArgumentException(
                    $"There should be {ArgumentCount} arguments for multiply operation.",
                    nameof(model.CalculationArguments));
            }

            decimal result = model.CalculationArguments[0] * model.CalculationArguments[1];

            return result;
        }
    }
}
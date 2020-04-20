using System;
using Test.Domain.Models.Calculator;

namespace Test.Domain.Strategies
{
    public class DivideStrategy : ICalculatable
    {
        public int ArgumentCount { get; }

        public DivideStrategy()
        {
            ArgumentCount = 2;
        }

        public decimal Calculate(CalculatorModel model)
        {
            if (model.CalculationArguments.Count != 2)
            {
                throw new ArgumentException(
                    $"There should be {ArgumentCount} arguments for divide operation.",
                    nameof(model.CalculationArguments));
            }

            decimal result = model.CalculationArguments[0] / model.CalculationArguments[1];

            return result;
        }
    }
}

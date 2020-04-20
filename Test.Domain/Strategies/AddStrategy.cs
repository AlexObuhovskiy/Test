using System;
using Test.Domain.Models.Calculator;

namespace Test.Domain.Strategies
{
    public class AddStrategy : ICalculatable
    {
        public int ArgumentCount { get; }

        public AddStrategy()
        {
            ArgumentCount = 2;
        }

        public decimal Calculate(CalculatorModel model)
        {
            if (model.CalculationArguments.Count != ArgumentCount)
            {
                throw new ArgumentException(
                    $"There should be {ArgumentCount} arguments for add operation.",
                    nameof(model.CalculationArguments));
            }

            decimal result = model.CalculationArguments[0] + model.CalculationArguments[1];

            return result;
        }
    }
}
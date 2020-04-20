using Test.Domain.Models.Calculator;

namespace Test.Domain.Strategies
{
    public class MultiplyStrategy : ICalculatable
    {
        public CalculatorResponseDto Calculate(CalculatorModel model)
        {
            decimal result = model.FirstArgument * model.SecondArgument;

            return new CalculatorResponseDto {Result = result};
        }
    }
}
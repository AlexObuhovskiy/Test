using Test.Domain.Models.Calculator;

namespace Test.Domain.Strategies
{
    public interface ICalculatable
    {
        CalculatorResponseDto Calculate(CalculatorModel model);
    }
}
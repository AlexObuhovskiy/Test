using Test.Domain.Models.Calculator;

namespace Test.Domain.Strategies
{
    public interface ICalculatable
    {
        decimal Calculate(CalculatorModel model);
    }
}
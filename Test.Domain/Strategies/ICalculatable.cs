using Test.Domain.Models.Calculator;

namespace Test.Domain.Strategies
{
    public interface ICalculatable
    {
        int ArgumentCount { get; }
        decimal Calculate(CalculatorModel model);
    }
}
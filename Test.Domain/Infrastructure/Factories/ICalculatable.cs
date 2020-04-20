using Test.Domain.Infrastructure.Enumerations;
using Test.Domain.Strategies;

namespace Test.Domain.Infrastructure.Factories
{
    public interface ICalculatorStrategyFactory
    {
        ICalculatable CreateCalculatorStrategy(OperationType operationType);
    }
}

using System;
using Test.Domain.Infrastructure.Enumerations;
using Test.Domain.Strategies;

namespace Test.Domain.Infrastructure.Factories
{
    public class CalculatorStrategyFactory : ICalculatorStrategyFactory
    {
        public ICalculatable CreateCalculatorStrategy(OperationType operationType)
        {
            switch (operationType)
            {
                case OperationType.Multiply:
                    return new MultiplyStrategy();
                case OperationType.Divide:
                    return new DivideStrategy();
                case OperationType.Add:
                    return new AddStrategy();
                case OperationType.Subtract:
                    return new SubtractStrategy();
                default:
                    throw new ArgumentOutOfRangeException(nameof(operationType), operationType, null);
            }
        }
    }
}
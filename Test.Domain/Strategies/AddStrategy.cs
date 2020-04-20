﻿using Test.Domain.Models.Calculator;

namespace Test.Domain.Strategies
{
    public class AddStrategy : ICalculatable
    {
        public decimal Calculate(CalculatorModel model)
        {
            decimal result = model.FirstArgument + model.SecondArgument;

            return result;
        }
    }
}
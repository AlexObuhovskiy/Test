using AutoMapper.Configuration;
using Test.Domain.Models.Calculator;

namespace Test.Domain.Infrastructure.Mapper
{
    public class CalculatorMapper : MapperConfigurationExpression
    {
        public CalculatorMapper()
        {
            CreateMap<CalculatorRequestDto, CalculatorModel>();
        }
    }
}
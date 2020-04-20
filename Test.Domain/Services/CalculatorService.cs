using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Test.Domain.Infrastructure.Enumerations;
using Test.Domain.Infrastructure.Factories;
using Test.Domain.Models.Calculator;

namespace Test.Domain.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ICalculatorStrategyFactory _calculatorStrategyFactory;
        private readonly IMapper _mapper;

        public CalculatorService(
            ICalculatorStrategyFactory calculatorStrategyFactory,
            IMapper mapper)
        {
            _calculatorStrategyFactory = calculatorStrategyFactory;
            _mapper = mapper;
        }

        public CalculatorResponseDto Calculate(CalculatorRequestDto requestDto)
        {
            var calculatorStrategy = _calculatorStrategyFactory.CreateCalculatorStrategy(requestDto.OperationType);
            var calculatorModel = _mapper.Map<CalculatorModel>(requestDto);

            var result = calculatorStrategy.Calculate(calculatorModel);

            return result;
        }

        public List<OperationResponseModel> GetOperationList()
        {
            var operationList = new List<OperationResponseModel>();

            foreach (OperationType operationType in Enum.GetValues(typeof(OperationType)))
            {
                var operationResponseModel = new OperationResponseModel
                {
                    OperationValue = (int) operationType,
                    OperationText = GetDescription(operationType)
                };

                operationList.Add(operationResponseModel);
            }

            return operationList;
        }

        private static string GetDescription(Enum value)
        {
            return
                value
                    .GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description
                ?? value.ToString();
        }
    }
}
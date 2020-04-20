using System;
using System.Collections.Generic;
using AutoMapper;
using Test.Domain.Infrastructure.Enumerations;
using Test.Domain.Infrastructure.Extensions;
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

        public decimal Calculate(CalculatorRequestDto requestDto)
        {
            var calculatorStrategy = _calculatorStrategyFactory.CreateCalculatorStrategy(requestDto.OperationType);
            var calculatorModel = _mapper.Map<CalculatorModel>(requestDto);

            var result = calculatorStrategy.Calculate(calculatorModel);

            return result;
        }

        public CalculatorWithColorResponseDto CalculateWithColor(CalculatorRequestDto requestDto)
        {
            var calculationResult = Calculate(requestDto);
            var responseDto = new CalculatorWithColorResponseDto
            {
                Result = calculationResult,
                Color = GetFieldColorByValue(calculationResult)
            };

            return responseDto;
        }

        public List<OperationResponseModel> GetOperationList()
        {
            var operationList = new List<OperationResponseModel>();

            foreach (OperationType operationType in Enum.GetValues(typeof(OperationType)))
            {
                var calculatorStrategy = _calculatorStrategyFactory.CreateCalculatorStrategy(operationType);

                var operationResponseModel = new OperationResponseModel
                {
                    Type = (int) operationType,
                    Description = operationType.GetDescription(),
                    ArgumentCount = calculatorStrategy.ArgumentCount
                };

                operationList.Add(operationResponseModel);
            }

            return operationList;
        }

        private string GetFieldColorByValue(decimal value)
        {
            string color = null;

            if (value % 2 == 0)
            {
                color = "green";
            }

            if (value % 2 == 1)
            {
                color = "red";
            }

            return color;
        }

        
    }
}
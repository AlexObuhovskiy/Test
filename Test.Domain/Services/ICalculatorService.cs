using System.Collections.Generic;
using Test.Domain.Models.Calculator;

namespace Test.Domain.Services
{
    public interface ICalculatorService
    {
        decimal Calculate(CalculatorRequestDto requestDto);

        CalculatorWithColorResponseDto CalculateWithColor(CalculatorRequestDto requestDto);

        List<OperationResponseModel> GetOperationList();
    }
}

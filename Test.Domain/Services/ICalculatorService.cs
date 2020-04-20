using System.Collections.Generic;
using Test.Domain.Models.Calculator;

namespace Test.Domain.Services
{
    public interface ICalculatorService
    {
        CalculatorResponseDto Calculate(CalculatorRequestDto requestDto);
        List<OperationResponseModel> GetOperationList();
    }
}

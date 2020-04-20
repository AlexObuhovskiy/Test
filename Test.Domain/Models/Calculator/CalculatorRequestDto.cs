using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Test.Domain.Infrastructure.Enumerations;

namespace Test.Domain.Models.Calculator
{
    public class CalculatorRequestDto
    {
        [Required]
        public List<decimal?> CalculationArguments { get; set; }

        public OperationType OperationType { get; set; }
    }
}

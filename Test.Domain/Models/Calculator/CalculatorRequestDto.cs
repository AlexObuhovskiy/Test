using System.ComponentModel.DataAnnotations;
using Test.Domain.Infrastructure.Enumerations;

namespace Test.Domain.Models.Calculator
{
    public class CalculatorRequestDto
    {
        [Required]
        public decimal? FirstArgument { get; set; }

        [Required]
        public decimal? SecondArgument { get; set; }

        public OperationType OperationType { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using Test.Domain.Models.Calculator;
using Test.Domain.Services;

namespace Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        private readonly ICalculatorService _calculatorService;
        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpPost]
        public IActionResult Post(CalculatorRequestDto calculatorRequestDto)
        {
            if (ModelState.IsValid)
            {
                var result = _calculatorService.Calculate(calculatorRequestDto);

                return Ok(result);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("operations")]
        public IActionResult GetOperationList()
        {
            var result = _calculatorService.GetOperationList();

            return Ok(result);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                decimal sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input!");    
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                decimal sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid Input!");
        }

        [HttpGet("multi/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                decimal multi = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(multi.ToString());
            }
            return BadRequest("Invalid Input!");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                decimal div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(div.ToString());
            }
            return BadRequest("Invalid Input!");
        }

        [HttpGet("sqrt/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (IsNumeric(number))
            {
                double sqrt = Math.Sqrt(ConvertToDouble(number));
                return Ok(sqrt.ToString());
            }
            return BadRequest("Invalid Input!");
        }
        
        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                decimal meanValue = Math.Floor(
                    (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2);
                return Ok(meanValue.ToString());
            }
            return BadRequest("Any Invalid Input!");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber, System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private double ConvertToDouble(string strNumber)
        {
            double doubleValue;

            if (double.TryParse(strNumber, out doubleValue))
            {
                return doubleValue;
            }
            return 0;
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace CalculatorAPI.Controllers;

[ApiController]
[Route("calculator")]
public class CalculatorController : ControllerBase
{
    [HttpGet("add")]
    public int Add(int a, int b)
    {
        return a + b;
    }

    [HttpGet("subtract")]
    public int Subtract(int a, int b)
    {
        return a - b;
    }

    [HttpGet("multiply")]
    public int Multiply(int a, int b)
    {
        return a * b;
    }

    [HttpGet("divide")]
    public IActionResult Divide(int a, int b)
    {
        if (b == 0)
        {
            return BadRequest("Cannot divide by zero.");
        }

        return Ok((double)a / b);
    }

    [HttpGet("modulus")]
    public IActionResult Modulus(int a, int b)
    {
        if (b == 0)
        {
            return BadRequest("Cannot calculate modulus by zero.");
        }

        return Ok(a % b);
    }

    [HttpGet("power")]
    public double Power(double a, double b)
    {
        return Math.Pow(a, b);
    }

    [HttpGet("square")]
    public double Square(double a)
    {
        return a * a;
    }

    [HttpGet("sqrt")]
    public double SquareRoot(double a)
    {
        return Math.Sqrt(a);
    }

    [HttpGet("max")]
    public double Maximum(double a, double b)
    {
        return Math.Max(a, b);
    }

    [HttpGet("min")]
    public double Minimum(double a, double b)
    {
        return Math.Min(a, b);
    }

    [HttpGet("abs")]
    public double Absolute(double a)
    {
        return Math.Abs(a);
    }
}
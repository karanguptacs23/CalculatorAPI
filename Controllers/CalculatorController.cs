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
    public double Divide(int a, int b)
    {
        return (double)a / b;
    }
}
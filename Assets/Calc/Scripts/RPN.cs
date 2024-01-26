using System;
using System.Collections.Generic;

public class RPN
{
    private readonly StackConsoleLogged<double> stack = new();
    private readonly Dictionary<string, Func<double, double, double>> operators = new()
    {
        { "+", (a, b) => a + b },
        { "-", (a, b) => a - b },
        { "*", (a, b) => a * b },
        { "/", (a, b) => a / b },
        { "^", Math.Pow }
    };
    
    public void Push(string input)
    {
        if (double.TryParse(input, out var operand))
        {
            stack.Push(operand);
            return;
        }
        
        // input is an operator
        double a = Pop();
        double b = Pop();
        double result = operators[input](b, a);
        
        if (double.IsNaN(result))
            return;
        
        stack.Push(result);
    }

    public double Pop()
    {
        if (stack.Count == 0)
            return 0.0;
        
        return stack.Pop();
    }
}
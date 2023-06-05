using System;

public abstract class Node
{
    public abstract double Evaluate();
}

public class OperandNode : Node
{
    private readonly double value;

    public OperandNode(double value)
    {
        this.value = value;
    }

    public override double Evaluate()
    {
        return value;
    }
}

public class OperatorNode : Node
{
    private readonly char op;
    private readonly Node left;
    private readonly Node right;

    public OperatorNode(char op, Node left, Node right)
    {
        this.op = op;
        this.left = left;
        this.right = right;
    }

    public override double Evaluate()
    {
        return op switch
        {
            '+' => left.Evaluate() + right.Evaluate(),
            '-' => left.Evaluate() - right.Evaluate(),
            '*' => left.Evaluate() * right.Evaluate(),
            '/' => left.Evaluate() / right.Evaluate(),
            '^' => Math.Pow(left.Evaluate(), right.Evaluate()),
            _ => throw new Exception($"Unknown operator '{op}'"),
        };
    }
}
using System;
using System.Collections.Generic;

public class Parser
{
    private readonly List<string> tokens;
    private int pos = 0;

    public Parser(List<string> tokens)
    {
        this.tokens = tokens;
    }

    public Node Parse()
    {
        Node left = ParseSubAdd();
        return left;
    }

    private Node ParseSubAdd()
    {
        Node left = ParseDivMul();
        while (pos < tokens.Count)
        {
            char op = tokens[pos++][0];
            if (op == '+' || op == '-')
            {
                Node right = ParseDivMul();
                left = new OperatorNode(op, left, right);
            }
            else
            {
                pos--;
                break;
            }
        }
        return left;
    }

    private Node ParseDivMul()
    {
        Node left = ParseExp();
        while (pos < tokens.Count)
        {
            char op = tokens[pos++][0];
            if (op == '*' || op == '/')
            {
                Node right = ParseExp();
                left = new OperatorNode(op, left, right);
            }
            else
            {
                pos--;
                break;
            }
        }
        return left;
    }

    private Node ParseExp()
    {
        Node left = ParseLeaf();
        while (pos < tokens.Count)
        {
            char op = tokens[pos++][0];
            if (op == '^')
            {
                Node right = ParseLeaf();
                left = new OperatorNode(op, left, right);
            }
            else
            {
                pos--;
                break;
            }
        }
        return left;
    }

    private Node ParseLeaf()
    {
        string token = tokens[pos++];
        if (token == "-")
        {
            Node node = ParseLeaf();
            return new OperatorNode(token[0], new OperandNode(0), node);
        }
        else if (token == "(")
        {
            Node node = Parse();
            if (pos >= tokens.Count || tokens[pos++] != ")")
            {
                throw new Exception();
            }
            return node;
        }
        else
        {
            double value = double.Parse(token);
            return new OperandNode(value);
        }
    }
}

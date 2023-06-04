using System.Collections.Generic;
using System.Text;

public static class Tokenizer
{
    public static List<string> Tokenize(string expr)
    {
        List<string> tokens = new();
        StringBuilder buffer = new();

        foreach (char c in expr)
        {
            if (c == '+' || c == '/' || c == '*' || c == '-' || c == '(' || c == ')' || c == '^')
            {
                if (buffer.Length > 0)
                {
                    tokens.Add(buffer.ToString());
                    buffer.Clear();
                }
                tokens.Add(c.ToString());
            }
            else
            {
                buffer.Append(c);
            }
        }

        if (buffer.Length > 0)
        {
            tokens.Add(buffer.ToString());
        }

        return tokens;
    }
}

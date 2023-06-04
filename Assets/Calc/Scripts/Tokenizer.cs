using System.Collections.Generic;
using System.Text;

public static class Tokenizer
{
    public static List<string> Tokenize(string expr)
    {
        List<string> tokens = new();
        StringBuilder token = new();

        foreach (char c in expr)
        {
            if (c == '+' || c == '/' || c == '*' || c == '-' || c == '(' || c == ')' || c == '^')
            {
                if (token.Length > 0)
                {
                    tokens.Add(token.ToString());
                    token.Clear();
                }
                tokens.Add(c.ToString());
            }
            else
            {
                token.Append(c);
            }
        }

        if (token.Length > 0)
        {
            tokens.Add(token.ToString());
        }

        return tokens;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class StackConsoleLogged<T> : Stack<T>
{
    public new T Pop()
    {
        T result = base.Pop();
        Debug.Log($"{result} POPPED from stack");
        LogStack();
        return result;
    }

    public new void Push(T item)
    {
        base.Push(item);
        Debug.Log($"{item} PUSHED to stack");
        LogStack();
    }
    
    private void LogStack()
    {
        T[] stack = ToArray();
        if (stack.Length > 0)
        {
            Debug.Log($"Stack: " + string.Join(", ", stack));
        }
        else
        {
            Debug.Log("Stack is EMPTY");
        }
    }
}

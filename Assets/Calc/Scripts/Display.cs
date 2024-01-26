using System;
using TMPro;
using UnityEngine;

public class Display : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private bool typeOver;
    private bool pushOnType;
    private RPN rpn;

    private void Awake()
    {
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
        rpn = new RPN();
    }

    public void Type(char c)
    {
        if (typeOver)
        {
            if (pushOnType)
            {
                rpn.Push(textMesh.text);
            }
            
            Clear();
            typeOver = false;
        }

        if (textMesh.text == "0")
        {
            textMesh.text = string.Empty;
        }

        textMesh.text += c;
    }

    public void EraseOne()
    {
        if (typeOver || textMesh.text.Length == 1)
        {
            Clear();
            return;
        }

        textMesh.text = textMesh.text.Remove(textMesh.text.Length - 1);
    }

    private void Clear()
    {
        textMesh.text = "0";
    }

    public void Operate(char c)
    {
        try
        {
            rpn.Push(textMesh.text);
            rpn.Push(c.ToString());
            textMesh.text = rpn.Pop().ToString();
            pushOnType = true;

        }
        catch (Exception)
        {
            // ignore
        }
        finally
        {
            typeOver = true;
        }
    }

    public void Enter()
    {
        rpn.Push(textMesh.text);
        typeOver = true;
        pushOnType = false;
    }
}
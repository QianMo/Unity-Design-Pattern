//-------------------------------------------------------------------------------------
//	InterpreterStructrue.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class InterpreterStructrue : MonoBehaviour
{
	void Start ( )
    {
        Context context = new Context();

        // Usually a tree 
        ArrayList list = new ArrayList();

        // Populate 'abstract syntax tree' 
        list.Add(new TerminalExpression());
        list.Add(new NonterminalExpression());
        list.Add(new TerminalExpression());
        list.Add(new TerminalExpression());

        // Interpret
        foreach (AbstractExpression exp in list)
        {
            exp.Interpret(context);
        }

    }
}

/// <summary>
/// The 'Context' class
/// </summary>
class Context
{
}

/// <summary>
/// The 'AbstractExpression' abstract class
/// </summary>
abstract class AbstractExpression
{
    public abstract void Interpret(Context context);
}

/// <summary>
/// The 'TerminalExpression' class
/// </summary>
class TerminalExpression : AbstractExpression
{
    public override void Interpret(Context context)
    {
        Debug.Log("Called Terminal.Interpret()");
    }
}

/// <summary>
/// The 'NonterminalExpression' class
/// </summary>
class NonterminalExpression : AbstractExpression
{
    public override void Interpret(Context context)
    {
        Debug.Log("Called Nonterminal.Interpret()");
    }
}
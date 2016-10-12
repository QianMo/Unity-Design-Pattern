//-------------------------------------------------------------------------------------
//	BridgeStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class BridgeStructure : MonoBehaviour
{
	void Start ( )
    {
        Abstraction ab = new RefinedAbstraction();

        // Set implementation and call
        ab.Implementor = new ConcreteImplementorA();
        ab.Operation();

        // Change implemention and call
        ab.Implementor = new ConcreteImplementorB();
        ab.Operation();
    }
}

/// <summary>
/// The 'Abstraction' class
/// </summary>
class Abstraction
{
    protected Implementor implementor;

    // Property
    public Implementor Implementor
    {
        set { implementor = value; }
    }

    public virtual void Operation()
    {
        implementor.Operation();
    }
}

/// <summary>
/// The 'Implementor' abstract class
/// </summary>
abstract class Implementor
{
    public abstract void Operation();
}

/// <summary>
/// The 'RefinedAbstraction' class
/// </summary>
class RefinedAbstraction : Abstraction
{
    public override void Operation()
    {
        implementor.Operation();
    }
}

/// <summary>
/// The 'ConcreteImplementorA' class
/// </summary>
class ConcreteImplementorA : Implementor
{
    public override void Operation()
    {
        Debug.Log("ConcreteImplementorA Operation");
    }
}

/// <summary>
/// The 'ConcreteImplementorB' class
/// </summary>
class ConcreteImplementorB : Implementor
{
    public override void Operation()
    {
        Debug.Log("ConcreteImplementorB Operation");
    }
}

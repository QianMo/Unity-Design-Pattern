//-------------------------------------------------------------------------------------
//	TemplateMethodStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class TemplateMethodStructure : MonoBehaviour
{
	void Start ( )
	{
        AbstractClass aA = new ConcreteClassA();
        aA.TemplateMethod();

        AbstractClass aB = new ConcreteClassB();
        aB.TemplateMethod();

    }
}

/// <summary>
/// The 'AbstractClass' abstract class
/// </summary>
abstract class AbstractClass
{
    public abstract void PrimitiveOperation1();
    public abstract void PrimitiveOperation2();

    // The "Template method"
    public void TemplateMethod()
    {
        PrimitiveOperation1();
        PrimitiveOperation2();
        Debug.Log("");
    }
}

/// <summary>
/// A 'ConcreteClass' class
/// </summary>
class ConcreteClassA : AbstractClass
{
    public override void PrimitiveOperation1()
    {
        Debug.Log("ConcreteClassA.PrimitiveOperation1()");
    }
    public override void PrimitiveOperation2()
    {
        Debug.Log("ConcreteClassA.PrimitiveOperation2()");
    }
}

/// <summary>
/// A 'ConcreteClass' class
/// </summary>
class ConcreteClassB : AbstractClass
{
    public override void PrimitiveOperation1()
    {
        Debug.Log("ConcreteClassB.PrimitiveOperation1()");
    }
    public override void PrimitiveOperation2()
    {
        Debug.Log("ConcreteClassB.PrimitiveOperation2()");
    }
}

//-------------------------------------------------------------------------------------
//	FacadeStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class FacadeStructure : MonoBehaviour
{
	void Start ( )
    {
        Facade facade = new Facade();

        facade.MethodA();
        facade.MethodB();
    }
}

/// <summary>
/// The 'Subsystem ClassA' class
/// </summary>
class SubSystemOne
{
    public void MethodOne()
    {
        Debug.Log(" SubSystemOne Method");
    }
}

/// <summary>
/// The 'Subsystem ClassB' class
/// </summary>
class SubSystemTwo
{
    public void MethodTwo()
    {
        Debug.Log(" SubSystemTwo Method");
    }
}

/// <summary>
/// The 'Subsystem ClassC' class
/// </summary>
class SubSystemThree
{
    public void MethodThree()
    {
        Debug.Log(" SubSystemThree Method");
    }
}

/// <summary>
/// The 'Subsystem ClassD' class
/// </summary>
class SubSystemFour
{
    public void MethodFour()
    {
        Debug.Log(" SubSystemFour Method");
    }
}

/// <summary>
/// The 'Facade' class
/// </summary>
class Facade
{
    private SubSystemOne _one;
    private SubSystemTwo _two;
    private SubSystemThree _three;
    private SubSystemFour _four;

    public Facade()
    {
        _one = new SubSystemOne();
        _two = new SubSystemTwo();
        _three = new SubSystemThree();
        _four = new SubSystemFour();
    }

    public void MethodA()
    {
        Debug.Log("\nMethodA() ---- ");
        _one.MethodOne();
        _two.MethodTwo();
        _four.MethodFour();
    }

    public void MethodB()
    {
        Debug.Log("\nMethodB() ---- ");
        _two.MethodTwo();
        _three.MethodThree();
    }
}
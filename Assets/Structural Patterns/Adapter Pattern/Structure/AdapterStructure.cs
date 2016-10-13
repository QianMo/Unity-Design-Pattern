//-------------------------------------------------------------------------------------
//	AdapterStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class AdapterStructure : MonoBehaviour
{
	void Start( )
    {
        // Create adapter and place a request
        Target target = new Adapter();
        target.Request();
    }
}

/// <summary>
/// The 'Target' class
/// </summary>
class Target
{
    public virtual void Request()
    {
        Debug.Log("Called Target Request()");
    }
}

/// <summary>
/// The 'Adapter' class
/// </summary>
class Adapter : Target
{
    private Adaptee _adaptee = new Adaptee();

    public override void Request()
    {
        // Possibly do some other work
        //  and then call SpecificRequest
        _adaptee.SpecificRequest();
    }
}

/// <summary>
/// The 'Adaptee' class
/// </summary>
class Adaptee
{
    public void SpecificRequest()
    {
        Debug.Log("Called SpecificRequest()");
    }
}
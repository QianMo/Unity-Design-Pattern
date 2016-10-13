//-------------------------------------------------------------------------------------
//	FlyweightStructure.cs
//-------------------------------------------------------------------------------------

// [Definition]
//----------------------------------------------------------------------
// Use sharing to support large numbers of fine-grained objects efficiently.

// [Participants]
//----------------------------------------------------------------------
//     The classes and objects participating in this pattern are:
// 
// Flyweight
//      declares an interface through which flyweights can receive and act on extrinsic state.
// ConcreteFlyweight
//      implements the Flyweight interface and adds storage for intrinsic state, if any.A ConcreteFlyweight object must be sharable.Any state it stores must be intrinsic, that is, it must be independent of the ConcreteFlyweight object's context.
// UnsharedConcreteFlyweight
//      not all Flyweight subclasses need to be shared.The Flyweight interface enables sharing, but it doesn't enforce it. It is common for UnsharedConcreteFlyweight objects to have ConcreteFlyweight objects as children at some level in the flyweight object structure (as the Row and Column classes have).
// FlyweightFactory
//      creates and manages flyweight objects
//      ensures that flyweight are shared properly.When a client requests a flyweight, the FlyweightFactory objects assets an existing instance or creates one, if none exists.
// Client
//      maintains a reference to flyweight(s).
//      computes or stores the extrinsic state of flyweight(s).



using UnityEngine;
using System.Collections;

public class FlyweightStructure : MonoBehaviour
{
    void Start()
    {
        // Arbitrary extrinsic state(外部状态)
        int externalState = 22;

        FlyweightFactory factory = new FlyweightFactory();

        // Work with different flyweight instances
        Flyweight fx = factory.GetFlyweight("X");
        fx.Operation(--externalState);

        Flyweight fy = factory.GetFlyweight("Y");
        fy.Operation(--externalState);

        Flyweight fz = factory.GetFlyweight("Z");
        fz.Operation(--externalState);

        UnsharedConcreteFlyweight fu = new
          UnsharedConcreteFlyweight();

        fu.Operation(--externalState);

    }
}

/// <summary>
/// The 'FlyweightFactory' class
/// </summary>
class FlyweightFactory
{
    private Hashtable flyweights = new Hashtable();

    // Constructor
    public FlyweightFactory()
    {
        flyweights.Add("X", new ConcreteFlyweight());
        flyweights.Add("Y", new ConcreteFlyweight());
        flyweights.Add("Z", new ConcreteFlyweight());
    }

    public Flyweight GetFlyweight(string key)
    {
        return ((Flyweight)flyweights[key]);
    }
}

/// <summary>
/// The 'Flyweight' abstract class
/// </summary>
abstract class Flyweight
{
    public abstract void Operation(int externalState);
}

/// <summary>
/// The 'ConcreteFlyweight' class
/// </summary>
class ConcreteFlyweight : Flyweight
{
    public override void Operation(int externalState)
    {
        Debug.Log("ConcreteFlyweight: " + externalState);
    }
}

/// <summary>
/// The 'UnsharedConcreteFlyweight' class
/// </summary>
class UnsharedConcreteFlyweight : Flyweight
{
    public override void Operation(int externalState)
    {
        Debug.Log("UnsharedConcreteFlyweight: " + externalState);
    }
}

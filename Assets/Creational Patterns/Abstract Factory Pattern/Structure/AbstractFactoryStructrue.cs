//-------------------------------------------------------------------------------------
//	AbstractFactoryStructrue.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class AbstractFactoryStructrue : MonoBehaviour
{
    void Start()
    {
        // Abstract factory #1
        AbstractFactory factory1 = new ConcreteFactory1();
        Client client1 = new Client(factory1);
        client1.Run();

        // Abstract factory #2
        AbstractFactory factory2 = new ConcreteFactory2();
        Client client2 = new Client(factory2);
        client2.Run();
    }
}

/// <summary>
/// The 'AbstractFactory' abstract class
/// </summary>
abstract class AbstractFactory
{
    public abstract AbstractProductA CreateProductA();
    public abstract AbstractProductB CreateProductB();
}


/// <summary>
/// The 'ConcreteFactory1' class
/// </summary>
class ConcreteFactory1 : AbstractFactory
{
    public override AbstractProductA CreateProductA()
    {
        return new ProductA1();
    }
    public override AbstractProductB CreateProductB()
    {
        return new ProductB1();
    }
}

/// <summary>
/// The 'ConcreteFactory2' class
/// </summary>
class ConcreteFactory2 : AbstractFactory
{
    public override AbstractProductA CreateProductA()
    {
        return new ProductA2();
    }
    public override AbstractProductB CreateProductB()
    {
        return new ProductB2();
    }
}

/// <summary>
/// The 'AbstractProductA' abstract class
/// </summary>
abstract class AbstractProductA
{
}

/// <summary>
/// The 'AbstractProductB' abstract class
/// </summary>
abstract class AbstractProductB
{
    public abstract void Interact(AbstractProductA a);
}


/// <summary>
/// The 'ProductA1' class
/// </summary>
class ProductA1 : AbstractProductA
{
}

/// <summary>
/// The 'ProductB1' class
/// </summary>
class ProductB1 : AbstractProductB
{
    public override void Interact(AbstractProductA a)
    {
        Debug.Log(this.GetType().Name + " interacts with " + a.GetType().Name);
    }
}

/// <summary>
/// The 'ProductA2' class
/// </summary>
class ProductA2 : AbstractProductA
{
}

/// <summary>
/// The 'ProductB2' class
/// </summary>
class ProductB2 : AbstractProductB
{
    public override void Interact(AbstractProductA a)
    {
        Debug.Log(this.GetType().Name + " interacts with " + a.GetType().Name);
    }
}

/// <summary>
/// The 'Client' class. Interaction environment for the products.
/// </summary>
class Client
{
    private AbstractProductA _abstractProductA;
    private AbstractProductB _abstractProductB;

    // Constructor
    public Client(AbstractFactory factory)
    {
        _abstractProductB = factory.CreateProductB();
        _abstractProductA = factory.CreateProductA();
    }

    public void Run()
    {
        _abstractProductB.Interact(_abstractProductA);
    }
}

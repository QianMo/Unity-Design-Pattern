//-------------------------------------------------------------------------------------
//	MediatorStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class MediatorStructure : MonoBehaviour
{
    void Start()
    {
        ConcreteMediator m = new ConcreteMediator();

        ConcreteColleague1 c1 = new ConcreteColleague1(m);
        ConcreteColleague2 c2 = new ConcreteColleague2(m);

        m.Colleague1 = c1;
        m.Colleague2 = c2;

        c1.Send("How are you?");
        c2.Send("Fine, thanks");

    }
}

/// <summary>
/// The 'Mediator' abstract class
/// </summary>
abstract class Mediator
{
    public abstract void Send(string message,Colleague colleague);
}

/// <summary>
/// The 'ConcreteMediator' class
/// </summary>
class ConcreteMediator : Mediator
{
    private ConcreteColleague1 _colleague1;
    private ConcreteColleague2 _colleague2;

    public ConcreteColleague1 Colleague1
    {
        set { _colleague1 = value; }
    }

    public ConcreteColleague2 Colleague2
    {
        set { _colleague2 = value; }
    }

    public override void Send(string message,Colleague colleague)
    {
        if (colleague == _colleague1)
        {
            _colleague2.Notify(message);
        }
        else
        {
            _colleague1.Notify(message);
        }
    }
}

/// <summary>
/// The 'Colleague' abstract class
/// </summary>
abstract class Colleague
{
    protected Mediator mediator;

    // Constructor
    public Colleague(Mediator mediator)
    {
        this.mediator = mediator;
    }
}

/// <summary>
/// A 'ConcreteColleague' class
/// </summary>
class ConcreteColleague1 : Colleague
{
    // Constructor
    public ConcreteColleague1(Mediator mediator)
        : base(mediator)
    {
    }

    public void Send(string message)
    {
        mediator.Send(message, this);
    }

    public void Notify(string message)
    {
        Debug.Log("Colleague1 gets message: "+ message);
    }
}

/// <summary>
/// A 'ConcreteColleague' class
/// </summary>
class ConcreteColleague2 : Colleague
{
    // Constructor
    public ConcreteColleague2(Mediator mediator)
        : base(mediator)
    {
    }

    public void Send(string message)
    {
        mediator.Send(message, this);
    }

    public void Notify(string message)
    {
        Debug.Log("Colleague2 gets message: "+ message);
    }
}

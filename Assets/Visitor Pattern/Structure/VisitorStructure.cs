//-------------------------------------------------------------------------------------
//	VisitorStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VisitorStructure : MonoBehaviour
{
	void Start ( )
    {
        // Setup structure
        ObjectStructure o = new ObjectStructure();
        o.Attach(new ConcreteElementA());
        o.Attach(new ConcreteElementB());

        // Create visitor objects
        ConcreteVisitor1 v1 = new ConcreteVisitor1();
        ConcreteVisitor2 v2 = new ConcreteVisitor2();

        // Structure accepting visitors
        o.Accept(v1);
        o.Accept(v2);
    }
}

/// <summary>
/// The 'Visitor' abstract class
/// </summary>
abstract class Visitor
{
    public abstract void VisitConcreteElementA(ConcreteElementA concreteElementA);
    public abstract void VisitConcreteElementB(ConcreteElementB concreteElementB);
}

/// <summary>
/// A 'ConcreteVisitor' class
/// </summary>
class ConcreteVisitor1 : Visitor
{
    public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
    {
        Debug.Log(concreteElementA.GetType().Name+" visited by "+this.GetType().Name);
    }

    public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
    {
        Debug.Log(concreteElementB.GetType().Name + " visited by " + this.GetType().Name);
    }
}

/// <summary>
/// A 'ConcreteVisitor' class
/// </summary>
class ConcreteVisitor2 : Visitor
{
    public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
    {
        Debug.Log(concreteElementA.GetType().Name + " visited by " + this.GetType().Name);
    }

    public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
    {
        Debug.Log(concreteElementB.GetType().Name + " visited by " + this.GetType().Name);
    }
}

/// <summary>
/// The 'Element' abstract class
/// </summary>
abstract class Element
{
    public abstract void Accept(Visitor visitor);
}

/// <summary>
/// A 'ConcreteElement' class
/// </summary>
class ConcreteElementA : Element
{
    public override void Accept(Visitor visitor)
    {
        visitor.VisitConcreteElementA(this);
    }

    public void OperationA()
    {
    }
}

/// <summary>
/// A 'ConcreteElement' class
/// </summary>
class ConcreteElementB : Element
{
    public override void Accept(Visitor visitor)
    {
        visitor.VisitConcreteElementB(this);
    }

    public void OperationB()
    {
    }
}

/// <summary>
/// The 'ObjectStructure' class
/// </summary>
class ObjectStructure
{
    private List<Element> _elements = new List<Element>();

    public void Attach(Element element)
    {
        _elements.Add(element);
    }

    public void Detach(Element element)
    {
        _elements.Remove(element);
    }

    public void Accept(Visitor visitor)
    {
        foreach (Element element in _elements)
        {
            element.Accept(visitor);
        }
    }
}
 
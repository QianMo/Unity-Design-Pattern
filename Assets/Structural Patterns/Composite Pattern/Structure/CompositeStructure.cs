//-------------------------------------------------------------------------------------
//	CompositeStructure.cs
//-------------------------------------------------------------------------------------

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CompositeStructure : MonoBehaviour
{
	void Start ( )
    {
        // Create a tree structure
        Composite root = new Composite("root");
        root.Add(new Leaf("Leaf A"));
        root.Add(new Leaf("Leaf B"));

        Composite comp = new Composite("Composite X");
        comp.Add(new Leaf("Leaf XA"));
        comp.Add(new Leaf("Leaf XB"));

        root.Add(comp);
        root.Add(new Leaf("Leaf C"));

        // Add and remove a leaf
        Leaf leaf = new Leaf("Leaf D");
        root.Add(leaf);
        root.Remove(leaf);

        // Recursively display tree
        root.Display(1);

    }
}

/// <summary>
/// The 'Component' abstract class
/// </summary>
abstract class Component
{
    protected string name;

    // Constructor
    public Component(string name)
    {
        this.name = name;
    }

    public abstract void Add(Component c);
    public abstract void Remove(Component c);
    public abstract void Display(int depth);
}

/// <summary>
/// The 'Composite' class
/// </summary>
class Composite : Component
{
    private List<Component> _children = new List<Component>();

    // Constructor
    public Composite(string name)
      : base(name)
    {
    }

    public override void Add(Component component)
    {
        _children.Add(component);
    }

    public override void Remove(Component component)
    {
        _children.Remove(component);
    }

    public override void Display(int depth)
    {
        Debug.Log(new String('-', depth) + name);

        // Recursively display child nodes
        foreach (Component component in _children)
        {
            component.Display(depth + 2);
        }
    }
}

/// <summary>
/// The 'Leaf' class
/// </summary>
class Leaf : Component
{
    // Constructor
    public Leaf(string name)
      : base(name)
    {
    }

    public override void Add(Component c)
    {
        Debug.Log("Cannot add to a leaf");
    }

    public override void Remove(Component c)
    {
        Debug.Log("Cannot remove from a leaf");
    }

    public override void Display(int depth)
    {
        Debug.Log(new String('-', depth) + name);
    }
}

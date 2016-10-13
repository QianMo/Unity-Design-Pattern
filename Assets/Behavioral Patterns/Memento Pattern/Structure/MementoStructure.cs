//-------------------------------------------------------------------------------------
//	MementoStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class MementoStructure : MonoBehaviour
{
	void Start ( )
    {
        Originator o = new Originator();
        o.State = "On";

        // Store internal state
        Caretaker c = new Caretaker();
        c.Memento = o.CreateMemento();

        // Continue changing originator
        o.State = "Off";

        // Restore saved state
        o.SetMemento(c.Memento);

    }
}

/// <summary>
/// The 'Originator' class
/// </summary>
class Originator
{
    private string _state;

    // Property
    public string State
    {
        get { return _state; }
        set
        {
            _state = value;
            Debug.Log("State = " + _state);
        }
    }

    // Creates memento 
    public Memento CreateMemento()
    {
        return (new Memento(_state));
    }

    // Restores original state
    public void SetMemento(Memento memento)
    {
        Debug.Log("Restoring state...");
        State = memento.State;
    }
}

/// <summary>
/// The 'Memento' class
/// </summary>
class Memento
{
    private string _state;

    // Constructor
    public Memento(string state)
    {
        this._state = state;
    }

    // Gets or sets state
    public string State
    {
        get { return _state; }
    }
}

/// <summary>
/// The 'Caretaker' class
/// </summary>
class Caretaker
{
    private Memento _memento;

    // Gets or sets memento
    public Memento Memento
    {
        set { _memento = value; }
        get { return _memento; }
    }
}

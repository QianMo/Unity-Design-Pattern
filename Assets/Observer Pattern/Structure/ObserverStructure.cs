//-------------------------------------------------------------------------------------
//	ObserverStructure.cs
//-------------------------------------------------------------------------------------


//[Definition]
//--------------------------------
// Define a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.
// 
// [Participants]
//--------------------------------
//  The classes and objects participating in this pattern are:
// 
// Subject
//      knows its observers.Any number of Observer objects may observe a subject
//      provides an interface for attaching and detaching Observer objects.
// ConcreteSubject
//      stores state of interest to ConcreteObserver
//      sends a notification to its observers when its state changes
// Observer
//      defines an updating interface for objects that should be notified of changes in a subject.
// ConcreteObserver
//      maintains a reference to a ConcreteSubject object
//      stores state that should stay consistent with the subject's
//      implements the Observer updating interface to keep its state consistent with the subject's


using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ObserverStructure : MonoBehaviour
{
    void Start()
    {
        // Configure Observer pattern
        ConcreteSubject s = new ConcreteSubject();

        s.Attach(new ConcreteObserver(s, "X"));
        s.Attach(new ConcreteObserver(s, "Y"));
        s.Attach(new ConcreteObserver(s, "Z"));

        // Change subject and notify observers
        s.SubjectState = "ABC";
        s.Notify();
        // Change subject and notify observers again
        s.SubjectState = "666";
        s.Notify();
    }
}

/// <summary>
/// The 'Subject' abstract class
/// </summary>
abstract class Subject
    {
        private List<Observer> _observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer o in _observers)
            {
                o.Update();
            }
        }
    }

    /// <summary>
    /// The 'ConcreteSubject' class
    /// </summary>
    class ConcreteSubject : Subject
    {
        private string _subjectState;

        // Gets or sets subject state
        public string SubjectState
        {
            get { return _subjectState; }
            set { _subjectState = value; }
        }
    }

    /// <summary>
    /// The 'Observer' abstract class
    /// </summary>
    abstract class Observer
    {
        public abstract void Update();
    }

    /// <summary>
    /// The 'ConcreteObserver' class
    /// </summary>
    class ConcreteObserver : Observer
    {
        private string _name;
        private string _observerState;
        private ConcreteSubject _subject;

        // Constructor
        public ConcreteObserver(
          ConcreteSubject subject, string name)
        {
            this._subject = subject;
            this._name = name;
        }

        public override void Update()
        {
            _observerState = _subject.SubjectState;
            Debug.Log("Observer "+ _name+"'s new state is "+_observerState);
    }

        // Gets or sets subject
        public ConcreteSubject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
    }


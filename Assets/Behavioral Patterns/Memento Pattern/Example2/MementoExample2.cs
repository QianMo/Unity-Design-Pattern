//-------------------------------------------------------------------------------------
//	MementoExample2.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections.Generic;

/* 
 * provides a way to store previous states of an object easily
 * 
 * memento: the basic object that is stored in different states
 * 
 * originator: sets and gets values from the currently targeted memento. Creates new memenots and assigns current values to them
 * 
 * caretaker: holds an list that contains all previous versions of the memento. it can store and retrieve stored mementos
 * 
 * 
 * */

namespace MementoExample2
{


    public class MementoExample2 : MonoBehaviour
    {

        Caretaker caretaker = new Caretaker();

        Originator originator = new Originator();

        int savedFiles = 0, currentArticle = 0;

        void Start()
        {
            // here we do some virtual typing and saving texts:
            Save("Tex1: Hello World, this is text example 1");
            Save("Text2: Ok here comes example number 2.");
            Save("Text3: And example number 3. Just testing.");
            Save("Text4: ....");

            // Here we do some virtual button pressing
            Debug.Log("Pressing Undo");
            Undo();
            Debug.Log("Pressing Undo");
            Undo();
            Debug.Log("Pressing Undo");
            Undo();
            Debug.Log("Pressing Redo");
            Redo();
        }


        // these methods below might get called when someone is pressing a button
        // you could easily implement it with unitys new ui system :)
        public void Save(string text)
        {
            originator.Set(text);
            caretaker.Add(originator.StoreInMemento());
            savedFiles = caretaker.GetCountOfSavedArticles();
            currentArticle = savedFiles;
        }

        public string Undo()
        {
            if (currentArticle > 0)
                currentArticle -= 1;

            Memento prev = caretaker.Get(currentArticle);
            string prevArticle = originator.RestoreFromMemento(prev);
            return prevArticle;
        }

        public string Redo()
        {
            if (currentArticle < savedFiles)
                currentArticle += 1;

            Memento next = caretaker.Get(currentArticle);
            string nextArticle = originator.RestoreFromMemento(next);
            return nextArticle;
        }

    }




    /// <summary>
    /// the basic object that is stored in different states
    /// </summary>
    public class Memento
    {
        public string article { get; protected set; }

        // Base Memento class that in this case just stores article strings!:)
        public Memento(string article)
        {
            this.article = article;
        }
    }


    /// <summary>
    /// sets and gets values from the currently targeted memento. Creates new memenots and assigns current values to them.
    /// </summary>
    public class Originator
    {
        public string article { get; protected set; }

        public void Set(string article)
        {
            Debug.Log("From Originator: Current Version of article is: [\"" + article + "\"]");
            this.article = article;
        }

        public Memento StoreInMemento()
        {
            Debug.Log("From Originator: Saving in Memento: [\"" + this.article + "\"]");
            return new Memento(this.article);
        }

        public string RestoreFromMemento(Memento memento)
        {
            article = memento.article;
            Debug.Log("From Originator: Previous Article saved in Memento: [\"" + article + "\"]");
            return article;
        }
    }


    /// <summary>
    /// holds an list that contains all previous versions of the memento. it can store and retrieve stored mementos
    /// </summary>
    public class Caretaker
    {
        List<Memento> savedArticles = new List<Memento>();

        public void Add(Memento m)
        {
            savedArticles.Add(m);
        }

        public Memento Get(int i)
        {
            return savedArticles[i];
        }

        public int GetCountOfSavedArticles()
        {
            return savedArticles.Count;
        }
    }


}
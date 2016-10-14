//-------------------------------------------------------------------------------------
//	StrategyPatternExample1.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This real-world code demonstrates the Strategy pattern which encapsulates sorting algorithms in the form of sorting objects. 
//This allows clients to dynamically change sorting strategies including Quicksort, Shellsort, and Mergesort.

namespace StrategyPatternExample1
{
    public class StrategyPatternExample1 : MonoBehaviour
    {
        void Start()
        {
            // Two contexts following different strategies
            SortedList studentRecords = new SortedList();

            studentRecords.Add("Samual");
            studentRecords.Add("Jimmy");
            studentRecords.Add("Sandra");
            studentRecords.Add("Vivek");
            studentRecords.Add("Anna");

            studentRecords.SetSortStrategy(new QuickSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new ShellSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new MergeSort());
            studentRecords.Sort();

        }
    }

    /// <summary>
    /// The 'Strategy' abstract class
    /// </summary>
    abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort(); // Default is Quicksort
            Debug.Log("-------QuickSorted list------- ");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class ShellSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.ShellSort(); not-implemented
            Debug.Log("-------ShellSorted list------- ");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.MergeSort(); not-implemented
            Debug.Log("-------MergeSorted list------- ");
        }
    }

    /// <summary>
    /// The 'Context' class
    /// </summary>
    class SortedList
    {
        private List<string> _list = new List<string>();
        private SortStrategy _sortstrategy;

        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this._sortstrategy = sortstrategy;
        }

        public void Add(string name)
        {
            _list.Add(name);
        }

        public void Sort()
        {
            _sortstrategy.Sort(_list);
            // Iterate over list and display results
            foreach (string name in _list)
            {
                Debug.Log(" " + name);
            }
        }
    }
}
//-------------------------------------------------------------------------------------
//	StrategyStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace StrategyStructure
{
    public class StrategyStructure : MonoBehaviour
    {
	    void Start ( )
        {
            Context context;

            // Three contexts following different strategies
            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyC());
            context.ContextInterface();
        }
    }

    /// <summary>
    /// The 'Strategy' abstract class
    /// </summary>
    abstract class Strategy
    {
        public abstract void AlgorithmInterface();
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class ConcreteStrategyA : Strategy
    {
        public override void AlgorithmInterface()
        {
            Debug.Log("Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class ConcreteStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Debug.Log("Called ConcreteStrategyB.AlgorithmInterface()");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class ConcreteStrategyC : Strategy
    {
        public override void AlgorithmInterface()
        {
            Debug.Log("Called ConcreteStrategyC.AlgorithmInterface()");
        }
    }

    /// <summary>
    /// The 'Context' class
    /// </summary>
    class Context
    {
        private Strategy _strategy;

        // Constructor
        public Context(Strategy strategy)
        {
            this._strategy = strategy;
        }

        public void ContextInterface()
        {
            _strategy.AlgorithmInterface();
        }
    }
}
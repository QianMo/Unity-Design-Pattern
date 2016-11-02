//-------------------------------------------------------------------------------------
//	ChainOfResponsibilityExample2.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class ChainOfResponsibilityExample2 : MonoBehaviour
{


	void Start ( )
	{
		// create calculation objects that get chained to each other in a sec
		Chain calc1 = new AddNumbers();
		Chain calc2 = new SubstractNumbers();
		Chain calc3 = new DivideNumbers();
		Chain calc4 = new MultiplyNumbers();

		// now chain them to each other
		calc1.SetNextChain(calc2);
		calc2.SetNextChain(calc3);
		calc3.SetNextChain(calc4);

		// this is the request that will be passed to a chain object to let them figure out which calculation objects it the right for the request
		// the request is here the CalculationType enum we add. so we want this pair of numbers to be added
		Numbers myNumbers = new Numbers(3, 5, CalculationType.Add);
		calc1.Calculate(myNumbers);

		// another example:
		Numbers myOtherNumbers = new Numbers(6, 2, CalculationType.Multiply);
		calc1.Calculate(myOtherNumbers);

		// or pass it to some chain object inbetween which will not work in this case:
		Numbers myLastNumbers = new Numbers(12, 3, CalculationType.Substract);
		calc3.Calculate(myLastNumbers);		
	}


	// just defining some types of calculation we want to implement
	// it is better than passing string values as requests because you don't risk any typos that way :)
	public enum CalculationType
	{
		Add,
		Substract,
		Divide,
		Multiply
	};




	// We use this object as an example object to be passed to the calculation chain ;-)
	// to figure out what we want to do with it (which is stored in CalculationType/calculationWanted)
	public class Numbers
	{
		// some numbers:
		public int number1 { get; protected set; }
		public int number2 { get; protected set; }

		// here we store in this object what we want to do with it to let the chain figure out who is responsible for it ;-)
		public CalculationType calculationWanted { get; protected set; }

		// constructor:
		public Numbers(int num1, int num2, CalculationType calcWanted)
		{
			this.number1 = num1;
			this.number2 = num2;
			this.calculationWanted = calcWanted;
		}
	}

	
	// doesn't need to be called chain of course ;-)
	public interface Chain
	{
		void SetNextChain(Chain nextChain); // to be called when calulcation fails
		void Calculate(Numbers numbers); // try to calculate
	}


	public class AddNumbers : Chain
	{
		// each chain object stored a private nextInChain object, that gets called when the method calculate fails
		protected Chain nextInChain;

		public void SetNextChain(Chain nextChain)
		{
			this.nextInChain = nextChain;
		}

		public void Calculate(Numbers request)
		{
			if(request.calculationWanted == CalculationType.Add)
			{
				Debug.Log("Adding: " + request.number1 + " + " + request.number2 + " = " + (request.number1 + request.number2).ToString());
			}
			else if(nextInChain != null)
				nextInChain.Calculate(request);
			else
				Debug.Log ("Handling of request failed: " + request.calculationWanted);
		}
	}

	public class SubstractNumbers : Chain
	{
		protected Chain nextInChain;

		public void SetNextChain(Chain nextChain)
		{
			this.nextInChain = nextChain;
		}

		public void Calculate(Numbers request)
		{
			if(request.calculationWanted == CalculationType.Substract)
			{
				Debug.Log("Substracting: " + request.number1 + " - " + request.number2 + " = " + (request.number1 - request.number2).ToString());
			}
			else if(nextInChain != null)
				nextInChain.Calculate(request);
			else
				Debug.Log ("Handling of request failed: " + request.calculationWanted);
		}
	}
	
	public class DivideNumbers : Chain
	{
		protected Chain nextInChain;
		
		public void SetNextChain(Chain nextChain)
		{
			this.nextInChain = nextChain;
		}
		
		public void Calculate(Numbers request)
		{
			if(request.calculationWanted == CalculationType.Divide)
			{
				Debug.Log("Dividing: " + request.number1 + " / " + request.number2 + " = " + (request.number1 / request.number2).ToString());
			}
			else if(nextInChain != null)
				nextInChain.Calculate(request);
			else
				Debug.Log ("Handling of request failed: " + request.calculationWanted);
		}
	}
	
	public class MultiplyNumbers : Chain
	{
		protected Chain nextInChain;
		
		public void SetNextChain(Chain nextChain)
		{
			this.nextInChain = nextChain;
		}
		
		public void Calculate(Numbers request)
		{
			if(request.calculationWanted == CalculationType.Multiply)
			{
				Debug.Log("Multiplying: " + request.number1 + " * " + request.number2 + " = " + (request.number1 * request.number2).ToString());
			}
			else if(nextInChain != null)
				nextInChain.Calculate(request);
			else
				Debug.Log ("Handling of request failed: " + request.calculationWanted);
		}
	}

}

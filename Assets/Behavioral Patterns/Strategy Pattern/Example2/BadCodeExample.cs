using UnityEngine;
using System.Collections;

public class Animal_BadExample
{
	// bad code:
	public virtual void Fly()
	{
		Debug.Log ("Can Fly");
	}
}

public class Dog_BadExample : Animal_BadExample
{
	// bad code:
	public override void Fly()
	{
		// override
	}
}

public class Cat_BadExample : Animal_BadExample
{
	// bad code:
	public override void Fly()
	{
		// override
	}
}

public class Bird_BadExample : Animal_BadExample
{
	public override void Fly()
	{
	}
}

// Rembember:
// ALWAYS
// eliminate duplicate code
// eliminate technices that allow one class to affect others
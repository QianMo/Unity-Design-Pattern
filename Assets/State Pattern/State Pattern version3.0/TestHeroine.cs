//-------------------------------------------------------------------------------------
//	TestHeroine.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class TestHeroine : MonoBehaviour
{
    private Heroine _heroine = new Heroine();

    void Start ( )
	{

    }

	void Update ( )
	{
	   _heroine.Update();
	}
}

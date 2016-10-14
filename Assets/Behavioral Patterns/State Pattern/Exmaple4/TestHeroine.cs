//-------------------------------------------------------------------------------------
//	TestHeroine.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class TestHeroine : MonoBehaviour
{
    private Heroine _heroine;

    void Start ( )
	{
        _heroine = new Heroine();
    }

	void Update ( )
	{
	   _heroine.Update();
	}
}

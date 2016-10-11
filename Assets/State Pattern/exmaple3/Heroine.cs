//-------------------------------------------------------------------------------------
//	Heroine.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class Heroine
{
    HeroineBaseState _state;

    public Heroine()
    {
        _state = new StandingState(this);

    }

    public void SetHeroineState(HeroineBaseState newState)
    {
        _state = newState;
    }

    public void HandleInput()
    {

    }



    public void Update()
    {
        _state.HandleInput();
    }

}

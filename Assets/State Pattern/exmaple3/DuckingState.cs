//-------------------------------------------------------------------------------------
//	DuckingState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DuckingState : HeroineBaseState
{
    private Heroine _heroine;
    public DuckingState(Heroine heroine)
    {
        _heroine = heroine;
        Debug.Log("------------------------Heroine in DuckingState~!（进入下蹲躲避状态！）");
    }


    public void Update()
    {

    }

    public void HandleInput()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Debug.Log("get GetKeyUp.DownArrow!");
            _heroine.SetHeroineState(new StandingState(_heroine));
        }
    }
}

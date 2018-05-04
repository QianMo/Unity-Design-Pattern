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
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("已经在下蹲躲避状态中！");
            return;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Debug.Log("get GetKeyUp.UpArrow!");
            _heroine.SetHeroineState(new StandingState(_heroine));
        }
    }
}

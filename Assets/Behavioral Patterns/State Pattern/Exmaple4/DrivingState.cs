//-------------------------------------------------------------------------------------
//	DrivingState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DrivingState : HeroineBaseState
{
    private Heroine _heroine;
    public DrivingState(Heroine heroine)
    {
        _heroine = heroine;
        Debug.Log("------------------------Heroine in DrivingState~!（进入下斩状态！）");
    }

    public void Update()
    {
    }

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("get KeyCode.UpArrow!");
            _heroine.SetHeroineState(new StandingState(_heroine));
        }
    }
}

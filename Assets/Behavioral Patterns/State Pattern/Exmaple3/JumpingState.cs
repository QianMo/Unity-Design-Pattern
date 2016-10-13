//-------------------------------------------------------------------------------------
//	JumpState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class JumpingState : HeroineBaseState
{

    private Heroine _heroine;
    public JumpingState(Heroine heroine)
    {
        _heroine = heroine;
        Debug.Log("------------------------Heroine in JumpingState~!(进入跳跃状态！)");
    }

    public void Update()
    {

    }

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("get GetKeyDown.UpArrow! but already in Jumping! return!(已经在跳跃状态中！)");
            return;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("get KeyCode.DownArrow!");
            _heroine.SetHeroineState(new DrivingState(_heroine));
        }
    }
}

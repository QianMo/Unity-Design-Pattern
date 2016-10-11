//-------------------------------------------------------------------------------------
//	StandingState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class StandingState : HeroineBaseState
{
    private Heroine _heroine;
    public StandingState(Heroine heroine)
    {
        _heroine = heroine;
        Debug.Log("------------------------Heroine in StandingState~!（进入站立状态！）");
    }

    public void Update()
    {
//         Debug.Log("Handle StandingState Input~");
//         if (KeyCode.UpArrow == input)
//         {
//             Debug.Log("Handle StandingState Input~ get KeyCode.UpArrow!");
//             _heroine.SetHeroineState(new JumpingState(_heroine));
//         }
//         
    }

    public void HandleInputEx()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("get KeyCode.UpArrow!");
            _heroine.SetHeroineState(new JumpingState(_heroine));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("get KeyCode.DownArrow!");
            _heroine.SetHeroineState(new DuckingState(_heroine));
        }
    }
}

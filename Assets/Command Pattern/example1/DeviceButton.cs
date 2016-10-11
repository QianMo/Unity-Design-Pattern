//-------------------------------------------------------------------------------------
//	DeviceButton.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DeviceButton
{
    ICommand cmd;

    public DeviceButton(ICommand cmd)
    {
        this.cmd = cmd;
    }

    public void Press()
    {
        this.cmd.Execute(); // actually the invoker (device button) has no idea what it does
    }

    public void PressUndo()
    {
        this.cmd.Undo();
    }
}


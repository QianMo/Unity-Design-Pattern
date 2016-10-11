//-------------------------------------------------------------------------------------
//	TurnVolumeDown.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class TurnVolumeDown : ICommand
{
    IElectronicDevice device;

    public TurnVolumeDown(IElectronicDevice device)
    {
        this.device = device;
    }

    public void Execute()
    {
        this.device.VolumeDown();
    }

    public void Undo()
    {
        this.device.VolumeUp();
    }
}

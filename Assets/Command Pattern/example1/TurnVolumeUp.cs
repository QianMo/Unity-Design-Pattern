//-------------------------------------------------------------------------------------
//	TurnVolumeUp.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class TurnVolumeUp : ICommand
{
    IElectronicDevice device;

    public TurnVolumeUp(IElectronicDevice device)
    {
        this.device = device;
    }

    public void Execute()
    {
        this.device.VolumeUp();
    }

    public void Undo()
    {
        this.device.VolumeDown();
    }
}

//-------------------------------------------------------------------------------------
//	TurnTVOff.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class TurnTVOff : ICommand
{
    IElectronicDevice device;

    public TurnTVOff(IElectronicDevice device)
    {
        this.device = device;
    }

    public void Execute()
    {
        this.device.Off();
    }

    public void Undo()
    {
        this.device.On();
    }
}


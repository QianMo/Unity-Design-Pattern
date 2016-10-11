//-------------------------------------------------------------------------------------
//	TurnItAllOff.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnItAllOff : ICommand
{
    List<IElectronicDevice> devices;

    public TurnItAllOff(List<IElectronicDevice> devices)
    {
        this.devices = devices;
    }

    public void Execute()
    {
        foreach (IElectronicDevice device in devices)
        {
            device.Off();
        }
    }

    public void Undo()
    {
        foreach (IElectronicDevice device in devices)
        {
            device.On();
        }
    }
}
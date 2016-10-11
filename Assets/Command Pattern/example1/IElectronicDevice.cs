//-------------------------------------------------------------------------------------
//	IElectronicDevice.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

// interface for electronic devices (or receivers)
public interface IElectronicDevice
{
    void On();
    void Off();
    void VolumeUp();
    void VolumeDown();
}

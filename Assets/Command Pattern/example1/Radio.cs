//-------------------------------------------------------------------------------------
//	Radio.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class Radio : IElectronicDevice
{
    protected int volume = 0;

    public void On()
    {
        Debug.Log("Radio is On");
    }

    public void Off()
    {
        Debug.Log("Radio is Off");
    }

    public void VolumeUp()
    {
        ++volume;
        Debug.Log("Radio Turned Volume Up to " + volume);
    }

    public void VolumeDown()
    {
        if (volume > 0)
            --volume;
        Debug.Log("Radio Turned Volume Down to " + volume);
    }
}
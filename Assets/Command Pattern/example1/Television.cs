//-------------------------------------------------------------------------------------
//	Television.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class Television : IElectronicDevice
{
    protected int volume = 0;

    public void On()
    {
        Debug.Log("TV is On");
    }

    public void Off()
    {
        Debug.Log("TV is Off");
    }

    public void VolumeUp()
    {
        ++volume;
        Debug.Log("TV Turned Volume Up to " + volume);
    }

    public void VolumeDown()
    {
        if (volume > 0)
            --volume;
        Debug.Log("TV Turned Volume Down to " + volume);
    }
}

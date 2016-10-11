//-------------------------------------------------------------------------------------
//	TestCommandPattern.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestCommandPattern : MonoBehaviour
{
    void Start()
    {
        Debug.Log("------------------Command Pattern--------------");
        IElectronicDevice device = TVRemove.GetDevice();

        TurnTVOn onCommand = new TurnTVOn(device);
        DeviceButton onPressed = new DeviceButton(onCommand);
        onPressed.Press();

        // -----------------------

        TurnTVOff offCommand = new TurnTVOff(device);
        onPressed = new DeviceButton(offCommand);
        onPressed.Press();

        TurnVolumeUp volUpCommand = new TurnVolumeUp(device);
        onPressed = new DeviceButton(volUpCommand);
        onPressed.Press();
        onPressed.Press();
        onPressed.Press();

        TurnVolumeDown volDownCommand = new TurnVolumeDown(device);
        onPressed = new DeviceButton(volDownCommand);
        onPressed.Press();

        // -----------------------
        Television tv = new Television();
        Radio radio = new Radio();

        List<IElectronicDevice> allDevices = new List<IElectronicDevice>();
        allDevices.Add(tv);
        allDevices.Add(radio);

        TurnItAllOff turnOffDevices = new TurnItAllOff(allDevices);
        DeviceButton turnThemOff = new DeviceButton(turnOffDevices);
        turnThemOff.Press();

        // -----------------------
        turnThemOff.PressUndo();

    }
}

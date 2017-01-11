//-------------------------------------------------------------------------------------
//	BridgePatternExample2.cs
//-------------------------------------------------------------------------------------

/* Decouple an abstraction from its implementation so that the two can vary independently
 * 
 * Progressingly adding functionality while separating out major differences using abstract classes
 * (think of remote controls with the same buttons but difference functionality among the buttons for different tvs)
 * 
 * Use when you want to be able rto change both the abstractions (abstract classes) and concrete classes independently
 * 
 * When you want the first abstract class to define rules (Abstract TV)
 * 
 * The concrete class adds additional rules (Concrete TV)
 * 
 * An abstract class has a reference to the device and it defines abstract methods that will be defined (Abstract Remote)
 * 
 * The concrete Remote defines the abstract methods required
 * 
 * */


using UnityEngine;
using System.Collections;

namespace BridgePatternExample2
{
    public class BridgePatternExample2 : MonoBehaviour
    {
        void Start()
        {
            RemoteButton tv = new TVRemoteMute(new TVDevice(1, 200));
            RemoteButton tv2 = new TVRemotePause(new TVDevice(1, 200));

            Debug.Log("Test TV with Mute");
            tv.ButtonFivePressed();
            tv.ButtonSixPressed();
            tv.ButtonNinePressed(); // < this one differs on each tv

            Debug.Log("Test TV with Pause");
            tv2.ButtonFivePressed();
            tv2.ButtonSixPressed();
            tv2.ButtonNinePressed(); // < this one differs on each tv
        }
    }

    public abstract class EntertainmentDevice
    {
        public int deviceState;
        public int maxSetting;
        public int volumeLevel = 0;

        public abstract void ButtonFivePressed();

        public abstract void ButtonSixPressed();

        public void DeviceFeedback()
        {
            if (deviceState > maxSetting || deviceState < 0)
                deviceState = 0;

            Debug.Log("On " + deviceState);
        }

        public void ButtonSevenPressed()
        {
            volumeLevel++;
            Debug.Log("Volume at: " + volumeLevel);
        }

        public void ButtonEightPressed()
        {
            volumeLevel--;
            Debug.Log("Volume at: " + volumeLevel);
        }
    }

    public class TVDevice : EntertainmentDevice
    {
        public TVDevice(int newDeviceState, int newMaxSetting)
        {
            this.deviceState = newDeviceState;
            this.maxSetting = newMaxSetting;
        }

        public override void ButtonFivePressed()
        {
            Debug.Log("Channel up");
            deviceState++;
        }

        public override void ButtonSixPressed()
        {
            Debug.Log("Channel down");
            deviceState--;
        }
    }

    // abstraction layer
    public abstract class RemoteButton
    {
        private EntertainmentDevice device;

        public RemoteButton(EntertainmentDevice device)
        {
            this.device = device;
        }

        public void ButtonFivePressed()
        {
            device.ButtonFivePressed();
        }

        public void ButtonSixPressed()
        {
            device.ButtonSixPressed();
        }

        public void DeviceFeedback()
        {
            device.DeviceFeedback();
        }

        public abstract void ButtonNinePressed();
    }


    // refined abstraction:
    public class TVRemoteMute : RemoteButton
    {
        public TVRemoteMute(EntertainmentDevice device) : base(device)
        {
        }

        public override void ButtonNinePressed()
        {
            Debug.Log("TV was muted.");
        }
    }

    public class TVRemotePause : RemoteButton
    {
        public TVRemotePause(EntertainmentDevice device) : base(device)
        {
        }

        public override void ButtonNinePressed()
        {
            Debug.Log("TV was paused.");
        }
    }


}
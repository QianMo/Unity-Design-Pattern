//-------------------------------------------------------------------------------------
//	EventQueuePatternExample3.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace EventQueuePatternExample3
{


    public class EventQueuePatternExample3 : MonoBehaviour
    {
        Receiver1 receiver1 = new Receiver1();
        Receiver2 receiver2 = new Receiver2();

        void Start()
        {

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //EventManger.Instance.SendEvent(EventType.UI_Event1, 1);

                EventManger.Instance.SendEvent(EventType.UI_Event1, "666");

                EventManger.Instance.SendEvent(EventType.UI_Event1, new GameObject());
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                EventManger.Instance.SendEvent(EventType.UI_Event2, new GameObject(), new GameObject());
            }


            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                EventManger.Instance.RegisterEvent(EventType.UI_Event3, receiver1.OnEventProcess3);
                EventManger.Instance.RegisterEvent(EventType.UI_Event3, receiver1.OnEventProcess4);
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                EventManger.Instance.SendEvent(EventType.UI_Event3, 666);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                EventManger.Instance.UnRegisterEvent(EventType.UI_Event3, receiver1.OnEventProcess3);
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                EventManger.Instance.UnRegisterEvent(EventType.UI_Event3);
            }

            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                EventManger.Instance.RegisterEvent(EventType.UI_Event4, receiver2.OnEventProcess4);
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                GameObject msgObj = new GameObject();
                //多个消息参数
                EventManger.Instance.SendEvent(EventType.UI_Event4, 666, "hello", msgObj);
            }

        }

        void OnEnable()
        {
            receiver1.RegisterDelegates();
            receiver2.RegisterDelegates();
        }

        void OnDisable()
        {
            receiver1.UnRegisterDelegates();
            receiver2.RegisterDelegates();
        }
    }

    public class Receiver1
    {
        public void RegisterDelegates()
        {
            EventManger.Instance.RegisterEvent(EventType.UI_Event1, OnEventProcess1);
            EventManger.Instance.RegisterEvent(EventType.UI_Event2, OnEventProcess1);
        }


        public void UnRegisterDelegates()
        {
            EventManger.Instance.UnRegisterEvent(EventType.UI_Event1);
            EventManger.Instance.UnRegisterEvent(EventType.UI_Event2);
        }

        private void OnEventProcess1(BaseEventMsg msg)
        {
            Debug.Log("Receiver1! OnEventProcess1");


            if (msg != null && msg.Params.Length > 0)
            {
                //                 int data = Convert.ToInt32(msg.Params[0]);
                //                 Debug.Log("Receiver1! data= int:" + data);

                var data0 = msg.Params[0] as string;
                if (data0 != null)
                {
                    Debug.Log("Receiver1! data= string:" + data0);
                }

                var data1 = msg.Params[0] as GameObject;
                if (data1 != null)
                {
                    Debug.Log("Receiver1! data= GameObject:" + data1);
                }



                //Debug.Log("Receiver1!");
                //int data = (int)msg.Params[0];
                //Debug.Log("Receiver1! data=" + data.ToString());
            }
        }

        private void OnEventProcess2(BaseEventMsg msg)
        {
            Debug.Log("Receiver1! OnEventProcess2");
        }

        public void OnEventProcess3(BaseEventMsg msg)
        {
            int data = Convert.ToInt32(msg.Params[0]);
            Debug.Log("Receiver1! data= int:" + data);

            Debug.Log("Receiver1! OnEventProcess3 int = " + data.ToString());
        }
        public void OnEventProcess4(BaseEventMsg msg)
        {
            Debug.Log("Receiver1! OnEventProcess4");
        }

    }


    public class Receiver2
    {
        public void RegisterDelegates()
        {
            EventManger.Instance.RegisterEvent(EventType.UI_Event1, OnEventProcess1);
            EventManger.Instance.RegisterEvent(EventType.UI_Event2, OnEventProcess2);
        }


        public void UnRegisterDelegates()
        {
            EventManger.Instance.UnRegisterEvent(EventType.UI_Event1);
        }

        private void OnEventProcess1(BaseEventMsg msg)
        {
            Debug.Log("Receiver2! OnEventProcess1");
            if (msg != null && msg.Params.Length > 0)
            {
            }
        }

        private void OnEventProcess2(BaseEventMsg msg)
        {
            Debug.Log("Receiver2! OnEventProcess2");
        }

        public void OnEventProcess3(BaseEventMsg msg)
        {
            Debug.Log("Receiver2! OnEventProcess3");
        }

        public void OnEventProcess4(BaseEventMsg msg)
        {
            Debug.Log("Receiver2! OnEventProcess4");

            if (msg != null && msg.Params.Length > 2)
            {

                int data1 = (int)msg.Params[0];

                string data2 = msg.Params[1] as string;

                GameObject data3 = msg.Params[2] as GameObject;

                if (data2 != null && data3 != null)
                {
                    Debug.Log("Receiver2! OnEventProcess4 DATA:" +
                        "Data1= String" + data1.ToString() +
                        ", Data2= string :" + data2 +
                        ", Data3 GameObject :" + data3.name);
                }


            }


        }

    }

}

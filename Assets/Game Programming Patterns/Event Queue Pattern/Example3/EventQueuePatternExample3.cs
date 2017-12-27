//-------------------------------------------------------------------------------------
//	EventQueuePatternExample3.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;

namespace EventQueuePatternExample3
{


    public class EventQueuePatternExample3 : MonoBehaviour
    {
        Receiver receiver = new Receiver();
        void Start()
        {
            receiver.RegisterDelegates();

            EventManger.Instance.SendEvent(EventType.UIEvent, (int)UIEventEnum.Start_Game, 1);
        }

        void Update()
        {

        }

    }

    public class Receiver
    {
        public void RegisterDelegates()
        {
            EventManger.Instance.RegisterEventHandler(EventHandlerType.UI, ProcessEvent);
        }


        private void ProcessEvent(BaseEventMsg msg)
        {
            if (msg != null && msg.Params.Length > 0)
            {
                int data = (int)msg.Params[0];
                Debug.Log("recieve! data=" + data.ToString());
            }
           
        }
    }

    public enum EventHandlerType
    {
        //传递UI消息
        UI = 0,
        Render,
    }

    public enum EventType
    {
        None = -1,
        UIEvent = 1,
        RnederEvent = 2,
    }


    public enum UIEventEnum
    {
        None = -1,
        Start_Game = 1,
    }


    public class BaseEventMsg
    {
        public uint CommandID;
        public EventType MsgType;
        public int Sequence;
        public object[] Params = null;

        public BaseEventMsg()
        {

        }

        public BaseEventMsg(uint inCommandID, EventType inMsgType, params object[] InParams)
        {
            CommandID = inCommandID;
            MsgType = inMsgType;
            //SimpleParam = para1;
            Params = InParams;
        }

        public void SetEventMsg(uint inCommandID, EventType inMsgType, params object[] InParams)
        {
            CommandID = inCommandID;
            MsgType = inMsgType;
            //SimpleParam = SimpleGenericParam.NullParam;
            Params = InParams;
        }

        public BaseEventMsg(uint inCommandID, EventType inMsgType)
        {
            CommandID = inCommandID;
            MsgType = inMsgType;
        }
    }


    public class EventManger
    {
        private static EventManger _Instance;
        public static EventManger Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new EventManger();
                }
                return _Instance;
            }
        }

        public delegate void EventHandler(BaseEventMsg Msg);


        /// <summary>
        /// 注册事件的处理Handler
        /// </summary>
        /// <param name="InType"></param>
        /// <param name="eventHandler"></param>
        public void RegisterEventHandler(EventHandlerType InType, EventHandler eventHandler)
        {
            if (InType == EventHandlerType.UI)
            {
                m_UIEventHandler = eventHandler;
            }
            else if (InType == EventHandlerType.Render)
            {
                m_NetWorkEventHandler = eventHandler;
            }

        }

        /// <summary>
        /// 反注册事件的处理Handler
        /// </summary>
        public void UnRegisterEventHandler(EventHandlerType InType)
        {
            // EventHandlers[(int)InType] = null;

            if (InType == EventHandlerType.UI)
            {
                m_UIEventHandler = null;
            }
            else if (InType == EventHandlerType.Render)
            {
                m_NetWorkEventHandler = null;
            }

        }
        private EventHandler m_UIEventHandler = null;
        private EventHandler m_NetWorkEventHandler = null;


        /// <summary>
        /// 发送事件
        /// </summary>
        public void SendEvent(EventType Handles, BaseEventMsg Msg, bool IsProtocolEvent = false)
        {
            if (Handles == EventType.UIEvent)
            {
                if (m_UIEventHandler != null)
                {
                    m_UIEventHandler(Msg);
                }
            }
            else if (Handles == EventType.RnederEvent)
            {
                if (m_NetWorkEventHandler != null)
                {
                    m_NetWorkEventHandler(Msg);
                }
            }
        }

        public void SendEvent(EventType HandleType, uint CommandID, params object[] inParams)
        {
            BaseEventMsg Msg = new BaseEventMsg();
            if (Msg != null)
            {
                Msg.SetEventMsg(CommandID, HandleType, inParams);
                SendEvent(HandleType, Msg);
            }
        }
    }

}

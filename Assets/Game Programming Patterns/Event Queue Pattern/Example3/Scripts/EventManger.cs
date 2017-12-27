//-------------------------------------------------------------------------------------
//	EventManger.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EventQueuePatternExample3
{
    /// <summary>
    /// 消息管理类-单例
    /// </summary>
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

        // 消息ID,代理存储字典Map - <(int)EventType,EventHandler代理>
        private Dictionary<int, EventHandler> m_EventHandlerMap = new Dictionary<int, EventHandler>();

        /// <summary>
        /// 注册事件
        /// </summary>
        public void RegisterEvent(EventType eventType, EventHandler eventHandler)
        {

            if (m_EventHandlerMap == null)
            {
                m_EventHandlerMap = new Dictionary<int, EventHandler>();
            }
            int eventTypeID = (int)eventType;
            if (m_EventHandlerMap.ContainsKey(eventTypeID))
            {
                m_EventHandlerMap[eventTypeID] += eventHandler;
            }
            else
            {
                m_EventHandlerMap.Add(eventTypeID, eventHandler);
            }

        }

        /// <summary>
        /// 反注册事件-反注册该EventType下所有的注册消息
        /// </summary>
        public void UnRegisterEvent(EventType eventType)
        {
            int eventTypeID = (int)eventType;

            if (m_EventHandlerMap == null)
            {
                return;
            }

            if (m_EventHandlerMap.ContainsKey(eventTypeID))
            {
                m_EventHandlerMap.Remove(eventTypeID);
            }
        }

        /// <summary>
        /// 反注册事件-反注册该EventType下指定的EventHandler
        /// </summary>
        public void UnRegisterEvent(EventType eventType, EventHandler eventHandler)
        {
            int eventTypeID = (int)eventType;

            if (m_EventHandlerMap == null)
            {
                return;
            }
            //删除eventHandler指定的消息响应
            if (m_EventHandlerMap.ContainsKey(eventTypeID))
            {
                m_EventHandlerMap[eventTypeID] -= eventHandler;
            }
        }



        /// <summary>
        /// 从消息ID,代理存储字典Map中找到对应的消息ID绑定的事件消息
        /// </summary>
        public void SendEvent(EventType eventType, BaseEventMsg Msg)
        {
            int eventTypeID = (int)eventType;

            if (m_EventHandlerMap == null)
            {
                return;
            }

            if (m_EventHandlerMap.ContainsKey(eventTypeID))
            {
                if (m_EventHandlerMap[eventTypeID] != null)
                {
                    m_EventHandlerMap[eventTypeID](Msg);
                }
            }
        }

        /// <summary>
        /// 发送事件
        /// </summary>
        public void SendEvent(EventType eventType, params object[] inParams)
        {
            BaseEventMsg Msg = new BaseEventMsg();
            if (Msg != null)
            {
                Msg.SetEventMsg(eventType, inParams);
                SendEvent(eventType, Msg);
            }
        }
    }



    /// <summary>
    /// 消息内容
    /// </summary>
    public class BaseEventMsg
    {
        public EventType MsgType;
        public object[] Params = null;

        public BaseEventMsg()
        {

        }

        public BaseEventMsg(EventType inMsgType, params object[] InParams)
        {
            MsgType = inMsgType;
            Params = InParams;
        }

        public void SetEventMsg(EventType inMsgType, params object[] InParams)
        {
            MsgType = inMsgType;
            Params = InParams;
        }

    }

}

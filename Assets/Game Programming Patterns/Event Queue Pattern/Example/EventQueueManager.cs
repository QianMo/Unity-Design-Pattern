//-------------------------------------------------------------------------------------
//	EventQueueManager.cs
// Reference :https://github.com/GandhiGames/message_queue
// http://gandhigames.co.uk/message-queue/
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace EventQueuePatternExample
{

    /// <summary>
    /// 事件Manager
    /// </summary>
    public class EventQueueManager
    {
        private static EventQueueManager _instance;
        public static EventQueueManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventQueueManager();
                }
                return _instance;
            }
        }

        //泛型代理
        public delegate void EventDelegateX<T>(T e) where T : GameEvent;
        //普通代理
        private delegate void EventDelegateX(GameEvent e);

        private Dictionary<System.Type, EventDelegateX> DelegatesMap = new Dictionary<System.Type, EventDelegateX>();
        private Dictionary<System.Delegate, EventDelegateX> DelegateLookupMap = new Dictionary<System.Delegate, EventDelegateX>();

        /// <summary>
        /// 添加Listener
        /// </summary>
        public void AddListener<T>(EventDelegateX<T> del) where T : GameEvent
        {

            EventDelegateX internalDelegate = (e) => { del((T)e); };

            //已存在,返回
            if (DelegateLookupMap.ContainsKey(del) && DelegateLookupMap[del] == internalDelegate)
            {
                return;
            }

            //加入delegateLookup中
            DelegateLookupMap[del] = internalDelegate;

            //加入delegates中
            EventDelegateX tempDel;
            if (DelegatesMap.TryGetValue(typeof(T), out tempDel))
            {
                DelegatesMap[typeof(T)] = tempDel += internalDelegate;
            }
            else {
                DelegatesMap[typeof(T)] = internalDelegate;
            }
        }

        /// <summary>
        /// 删除Listener
        /// </summary>
        public void RemoveListener<T>(EventDelegateX<T> del) where T : GameEvent
        {
            EventDelegateX internalDelegate;
            if (DelegateLookupMap.TryGetValue(del, out internalDelegate))
            {
                EventDelegateX tempDel;
                if (DelegatesMap.TryGetValue(typeof(T), out tempDel))
                {
                    tempDel -= internalDelegate;
                    if (tempDel == null)
                    {
                        DelegatesMap.Remove(typeof(T));
                    }
                    else {
                        DelegatesMap[typeof(T)] = tempDel;
                    }
                }

                DelegateLookupMap.Remove(del);
            }
        }
        /// <summary>
        /// 在队列中加入事件
        /// </summary>
        public void AddEventToQueue(GameEvent e)
        {
            EventDelegateX del;
            if (DelegatesMap.TryGetValue(e.GetType(), out del))
            {
                del.Invoke(e);
            }
        }

    }

    /// <summary>
    /// 事件优先级枚举
    /// </summary>
    public enum MessagePriority
    {
        Low,
        Medium,
        High
    }

    /// <summary>
    /// 事件接口
    /// </summary>
    public interface IMessageEvent
    {
        DateTime timeRaised { get; }
        float displayTime { get; }
        MessagePriority priority { get; }
        object message { get; }
    }

    /// <summary>
    /// 事件实体类
    /// </summary>
    public class MessageEvent : GameEvent, IMessageEvent
    {
        public DateTime timeRaised { private set; get; }
        public MessagePriority priority { private set; get; }
        public float displayTime { private set; get; }
        public object message { private set; get; }

        public MessageEvent(object message, float displayTime, MessagePriority priority)
        {
            this.message = message;
            this.displayTime = displayTime;
            this.priority = priority;
            timeRaised = DateTime.Now;
        }
    }


    /// <summary>
    /// 事件抽象类
    /// </summary>
    public abstract class GameEvent
    {

    }

}

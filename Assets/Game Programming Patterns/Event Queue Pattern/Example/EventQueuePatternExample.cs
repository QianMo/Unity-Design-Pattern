//-------------------------------------------------------------------------------------
//	EventQueuePatternExample.cs
// Reference :https://github.com/GandhiGames/message_queue
// http://gandhigames.co.uk/message-queue/
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace EventQueuePatternExample
{
    public class EventQueuePatternExample : MonoBehaviour
    {
        private Dictionary<MessagePriority, string> priorityLookup = new Dictionary<MessagePriority, string>();

        void Start()
        {
            //添加优先级
            priorityLookup.Add(MessagePriority.Low, "Low");
            priorityLookup.Add(MessagePriority.Medium, "Medium");
            priorityLookup.Add(MessagePriority.High, "High");
        }

        void Update()
        {
            //按钮响应
            if (Input.GetMouseButtonDown(0))
            {
                //随机选取优先级
                MessagePriority priority = MessagePriority.High;
                float random = UnityEngine.Random.value;
                if (random < 0.333f)
                {
                    priority = MessagePriority.Low;
                }
                else if (random < 0.666f)
                {
                    priority = MessagePriority.Medium;
                }

                //随机选取显示时间
                float showTime = UnityEngine.Random.Range(1f, 5f);

                //加入事件到队列
                EventQueueManager.Instance.AddEventToQueue(new MessageEvent(priorityLookup[priority] + " priority message shown at "
                    + System.DateTime.Now + " for " + showTime + " seconds", Time.time + showTime, priority));
            }
        }
    }
}
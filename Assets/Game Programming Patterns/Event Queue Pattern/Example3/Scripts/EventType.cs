//-------------------------------------------------------------------------------------
//	EventType.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace EventQueuePatternExample3
{
    /// <summary>
    ///  消息类型枚举
    /// </summary>
    public enum EventType
    {
        None,

        //UI事件消息
        UI_Event1 = 1,
        UI_Event2 = 2,
        UI_Event3 = 3,
        UI_Event4 = 4,
        UI_Event5 = 5,

        //渲染事件消息
        Render_Event1 = 100,
        Render_Event2,
    }
}
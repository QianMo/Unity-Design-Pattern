//-------------------------------------------------------------------------------------
//	PoolObject.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace ObjectPoolPatternExample
{

    /// <summary>
    /// 对象池中对象的组件
    /// </summary>
    public class PoolObject : MonoBehaviour
    {
        //名称
        public string PoolName;
        //是否已在池中（还未使用，待使用）
        public bool IsPooled;
    }
}

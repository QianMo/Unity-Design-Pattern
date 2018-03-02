//-------------------------------------------------------------------------------------
//	SingletonPatternExample3.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace SingletonPatternExample3
{

    public class SingletonPatternExample3 : MonoBehaviour
    {
        void Start()
        {
            //单例A
            SingletonA.Instance.DoSomething();

            //单例B
            SingletonB.Instance.DoSomething();
        }

    }

    /// <summary>
    /// 单例类基类（抽象类、泛型，其他类只需继承此类即可成为单例类）
    /// 继承该类的，即成为一个单例类
    /// </summary>
    public abstract class Singleton<T>
        where T : class, new()
    {
        private static T _instance = null;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                    return _instance;
                }
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            _instance = this as T;
        }
    }


    /// <summary>
    /// 继承自Singleton<T>的单例
    /// </summary>
    public class SingletonA : Singleton<SingletonA>
    {
        public void DoSomething()
        {
            Debug.Log("SingletonA:DoSomething!");
        }
    }

    /// <summary>
    /// 继承自Singleton<T>的单例
    /// </summary>
    public class SingletonB : Singleton<SingletonB>
    {
        public void DoSomething()
        {
            Debug.Log("SingletonB:DoSomething!");
        }
    }


}
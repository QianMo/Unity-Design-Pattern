//-------------------------------------------------------------------------------------
//	ProxyStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace ProxyStructure
{

    public class ProxyStructure : MonoBehaviour
    {
	    void Start ( )
        {
            // Create proxy and request a service
            Proxy proxy = new Proxy();
            proxy.Request();
        }
    }

    /// <summary>
    /// The 'Subject' abstract class
    /// </summary>
    abstract class Subject
    {
        public abstract void Request();
    }

    /// <summary>
    /// The 'RealSubject' class
    /// </summary>
    class RealSubject : Subject
    {
        public override void Request()
        {
            Debug.Log("Called RealSubject.Request()");
        }
    }

    /// <summary>
    /// The 'Proxy' class
    /// </summary>
    class Proxy : Subject
    {
        private RealSubject _realSubject;

        public override void Request()
        {
            // Use 'lazy initialization'
            if (_realSubject == null)
            {
                _realSubject = new RealSubject();
            }

            _realSubject.Request();
        }
    }
}
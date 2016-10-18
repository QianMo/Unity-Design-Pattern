//-------------------------------------------------------------------------------------
//	ProxyPatternExample1.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

//This real-world code demonstrates the Proxy pattern for a Math object represented by a MathProxy object.
namespace ProxyPatternExample1
{
    public class ProxyPatternExample1 : MonoBehaviour
    {
        void Start()
        {
            // Create math proxy
            MathProxy proxy = new MathProxy();

            // Do the math
            Debug.Log("4 + 2 = " + proxy.Add(4, 2));
            Debug.Log("4 - 2 = " + proxy.Sub(4, 2));
            Debug.Log("4 * 2 = " + proxy.Mul(4, 2));
            Debug.Log("4 / 2 = " + proxy.Div(4, 2));
        }
    }

    /// <summary>
    /// The 'Subject interface
    /// </summary>
    public interface IMath
    {
        double Add(double x, double y);
        double Sub(double x, double y);
        double Mul(double x, double y);
        double Div(double x, double y);
    }

    /// <summary>
    /// The 'RealSubject' class
    /// </summary>
    class Math : IMath
    {
        public double Add(double x, double y) { return x + y; }
        public double Sub(double x, double y) { return x - y; }
        public double Mul(double x, double y) { return x * y; }
        public double Div(double x, double y) { return x / y; }
    }

    /// <summary>
    /// The 'Proxy Object' class
    /// </summary>
    class MathProxy : IMath
    {
        private Math _math = new Math();

        public double Add(double x, double y)
        {
            return _math.Add(x, y);
        }
        public double Sub(double x, double y)
        {
            return _math.Sub(x, y);
        }
        public double Mul(double x, double y)
        {
            return _math.Mul(x, y);
        }
        public double Div(double x, double y)
        {
            return _math.Div(x, y);
        }
    }
}
using UnityEngine;
using System.Collections;


namespace ObjectPoolPatternExample
{
    public class PoolObjectBehaviour : MonoBehaviour
    {

        /// <summary>
        /// 设置对象的初始状态
        /// </summary>
        void OnEnable()
        {
            if (GetComponent<Rigidbody>() == null)
            {
                return;
            }

            GetComponent<Rigidbody>().velocity = new Vector3(0, Random.Range(-10, 11), 0);
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, Random.Range(-10, 11), 0);
        }

    }
}
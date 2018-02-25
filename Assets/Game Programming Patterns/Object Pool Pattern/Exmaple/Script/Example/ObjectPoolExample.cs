using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace ObjectPoolPatternExample
{
    public class ObjectPoolExample : MonoBehaviour
    {
        //池名称
        public string poolName;
        //对象List
        public List<GameObject> ObjectList = new List<GameObject>();

        public void Start()
        {
            //初始化对象池
            PoolManager.Instance.Init();
            //开始运行时，先从池中取出一个对象
            GetObjectFromPool();
        }


        /// <summary>
        /// 从池中取出对象，并设置随机位置
        /// </summary>
        public void GetObjectFromPool()
        {
            if (ObjectList == null)
            {
                return;
            }

            //设置随机位置
            Vector3 pos = new Vector3();
            pos.x = Random.Range(-5, 6);
            pos.y = 0f;
            pos.z = Random.Range(-5, 6);

            GameObject go = PoolManager.Instance.GetObjectFromPool(poolName, pos, Quaternion.identity);
            if (go)
            {
                ObjectList.Add(go);
            }
        }

        /// <summary>
        /// 将索引为0的对象返回池中
        /// </summary>
        public void ReturnOneObjectToPool()
        {
            if (ObjectList == null || ObjectList.Count <= 0)
            {
                return;
            }

            PoolManager.Instance.ReturnObjectToPool(ObjectList[0]);
            ObjectList.Remove(ObjectList[0]);
        }

        /// <summary>
        /// 将所有对象返回池中
        /// </summary>
        public void ReturnAllObjectToPool()
        {
            if (ObjectList == null)
            {
                return;
            }

            foreach (GameObject go in ObjectList)
            {
                PoolManager.Instance.ReturnObjectToPool(go);
            }
            ObjectList.Clear();
        }
    }
}
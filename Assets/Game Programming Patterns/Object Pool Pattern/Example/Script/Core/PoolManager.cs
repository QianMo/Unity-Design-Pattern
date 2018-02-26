//-------------------------------------------------------------------------------------
//	PoolManager.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace ObjectPoolPatternExample
{

    /// <summary>
    /// 对象池类
    /// </summary>
    public class Pool
    {
        //池中可用对象的栈
        private Stack<PoolObject> availableObjStack = new Stack<PoolObject>();
        //是否固定尺寸
        private bool fixedSize;
        //对象prefab
        private GameObject poolObjectPrefab;
        //池的尺寸
        private int poolSize;
        //池的名称
        private string poolName;

        public Pool(string poolName, GameObject poolObjectPrefab, int initialCount, bool fixedSize)
        {
            this.poolName = poolName;
            this.poolObjectPrefab = poolObjectPrefab;
            this.poolSize = initialCount;
            this.fixedSize = fixedSize;
            //填充池 | populate the pool
            for (int index = 0; index < initialCount; index++)
            {
                AddObjectToPool(NewObjectInstance());
            }
        }

        /// <summary>
        /// 将对象加入池，复杂度o(1)
        /// </summary>
        /// <param name="po"></param>
        private void AddObjectToPool(PoolObject po)
        {
            //add to pool
            po.gameObject.SetActive(false);
            availableObjStack.Push(po);
            po.IsPooled = true;
        }

        /// <summary>
        /// 新建一个对象实例
        /// </summary>
        /// <returns></returns>
        private PoolObject NewObjectInstance()
        {
            GameObject go = (GameObject)GameObject.Instantiate(poolObjectPrefab);
            PoolObject po = go.GetComponent<PoolObject>();
            if (po == null)
            {
                po = go.AddComponent<PoolObject>();
            }
            //set name
            po.PoolName = poolName;
            return po;
        }

        //o(1)
        /// <summary>
        /// 获取一个池中可用对象，如池中已无可用对象，则新建一个对象实例
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public GameObject NextAvailableObject(Vector3 position, Quaternion rotation)
        {
            PoolObject po = null;
            //池中有可用对象，直接从池中取
            if (availableObjStack.Count > 0)
            {
                po = availableObjStack.Pop();
            }
            //池中已无可用对象，new一个
            else if (fixedSize == false)
            {
                //increment size var, this is for info purpose only
                poolSize++;
                Debug.Log(string.Format("Growing pool {0}. New size: {1}", poolName, poolSize));
                //create new object
                po = NewObjectInstance();
            }
            else
            {
                Debug.LogWarning("No object available & cannot grow pool: " + poolName);
            }

            //设置对象的行为
            GameObject result = null;
            if (po != null)
            {
                po.IsPooled = false;
                result = po.gameObject;
                result.SetActive(true);

                result.transform.position = position;
                result.transform.rotation = rotation;
            }

            return result;
        }

        /// <summary>
        /// 将指定对象返回池中，复杂度o(1)
        /// </summary>
        /// <param name="po"></param>
        public void ReturnObjectToPool(PoolObject po)
        {

            if (poolName.Equals(po.PoolName))
            {

                // We could have used availableObjStack.Contains(po) to check if this object is in pool.
                // While that would have been more robust, it would have made this method O(n) 
                if (po.IsPooled)
                {
                    Debug.LogWarning(po.gameObject.name + " is already in pool. Why are you trying to return it again? Check usage.");
                }
                else
                {
                    AddObjectToPool(po);
                }

            }
            else
            {
                Debug.LogError(string.Format("Trying to add object to incorrect pool {0} {1}", po.PoolName, poolName));
            }
        }
    }

    /// <summary>
    /// PoolManager
    /// </summary>
    public class PoolManager : MonoBehaviour
    {
        /// <summary>
        /// 单例
        /// </summary>
        private static PoolManager instance;
        public static PoolManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PoolManager();
                }
                return instance;
            }
        }

        /// <summary>
        /// 多个对象池的索引<对象池名称，对应的池>
        /// </summary>
        private Dictionary<string, Pool> poolMap = new Dictionary<string, Pool>();
        public Dictionary<string, Pool> PoolMap
        {
            get { return poolMap; }
            set { poolMap = value; }
        }

        [Header("[对象池信息，(运行时修改无效)]")]
        public PoolInfo[] poolInfo;


        /// <summary>
        /// 构造函数
        /// </summary>
        PoolManager()
        {
            //set instance
            instance = this;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            //检测对象池是否重名 | check for duplicate names
            CheckForDuplicatePoolNames();
            //创建对象池 | create pools
            CreatePools();
        }


        /// <summary>
        /// 检测对象池是否重名
        /// </summary>
        private void CheckForDuplicatePoolNames()
        {
            for (int index = 0; index < poolInfo.Length; index++)
            {
                string poolName = poolInfo[index].poolName;
                if (poolName.Length == 0)
                {
                    Debug.LogError(string.Format("Pool {0} does not have a name!", index));
                }
                for (int internalIndex = index + 1; internalIndex < poolInfo.Length; internalIndex++)
                {
                    if (poolName.Equals(poolInfo[internalIndex].poolName))
                    {
                        Debug.LogError(string.Format("Pool {0} & {1} have the same name. Assign different names.", index, internalIndex));
                    }
                }
            }
        }

        /// <summary>
        /// 创建对象池
        /// </summary>
        private void CreatePools()
        {
            foreach (PoolInfo currentPoolInfo in poolInfo)
            {

                Pool pool = new Pool(currentPoolInfo.poolName, currentPoolInfo.prefab, currentPoolInfo.poolSize, currentPoolInfo.fixedSize);

                Debug.Log("Creating Pool: " + currentPoolInfo.poolName);

                //add to mapping dict
                poolMap[currentPoolInfo.poolName] = pool;
            }
        }


        /// <summary>
        /// 从池中获取一个对象并返回
        ///  null in case the pool does not have any object available & can grow size is false.
        /// </summary>
        /// <param name="poolName">名称</param>
        /// <param name="position">位置</param>
        /// <param name="rotation">rotation</param>
        /// <returns></returns>
        public GameObject GetObjectFromPool(string poolName, Vector3 position, Quaternion rotation)
        {
            GameObject result = null;

            if (poolMap.ContainsKey(poolName))
            {
                Pool pool = poolMap[poolName];
                result = pool.NextAvailableObject(position, rotation);
                //scenario when no available object is found in pool
                if (result == null)
                {
                    Debug.LogWarning("No object available in pool. Consider setting fixedSize to false.: " + poolName);
                }

            }
            else
            {
                Debug.LogError("Invalid pool name specified: " + poolName);
            }

            return result;
        }

        public void ReturnObjectToPool(GameObject go)
        {
            PoolObject po = go.GetComponent<PoolObject>();
            if (po == null)
            {
                Debug.LogWarning("Specified object is not a pooled instance: " + go.name);
            }
            else
            {
                if (poolMap.ContainsKey(po.PoolName))
                {
                    Pool pool = poolMap[po.PoolName];
                    pool.ReturnObjectToPool(po);
                }
                else
                {
                    Debug.LogWarning("No pool available with name: " + po.PoolName);
                }
            }
        }
    }


    /// <summary>
    /// 对象池信息
    /// </summary>
    [System.Serializable]
    public class PoolInfo
    {
        //名称
        public string poolName;
        //prefab对象
        public GameObject prefab;
        //尺寸
        public int poolSize;
        //是否固定尺寸的池
        public bool fixedSize;
    }
}

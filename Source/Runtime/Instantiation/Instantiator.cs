using System.Collections.Generic;
using UnityCore.Instantiation.Pooling;
using UnityEngine;

namespace UnityCore.Instantiation
{
    /// <summary>
    /// Controls runtime instantiation of gameobjects/prefabs
    /// </summary>
    public static class Instantiator
    {
        #region Variables

        /// <summary>
        /// 
        /// </summary>
        private static readonly List<GameObjectPool> _pools = new List<GameObjectPool>();

        #endregion Variables
        
        
        #region Instantiation
        
        public static Object Instantiate(Object go)
        {
            return Object.Instantiate(go);
        }
        
        public static  GameObject Instantiate(GameObject go)
        {
            return Object.Instantiate(go).gameObject;
        }
    
        public static  GameObject Instantiate(GameObject go, Vector3 p, Quaternion r)
        {
            return Object.Instantiate(go, p, r).gameObject;
        }
        
        public static GameObject Instantiate(GameObject go, Transform parent)
        {
            return Object.Instantiate(go, parent);
        }

        #endregion


        #region Pooling

        public static GameObject Pooled(GameObject go, Vector3 p, Quaternion r)
        {
            GameObject g = Pooled(go);
            g.transform.SetPositionAndRotation(p, r);
            return g;
        }

        public static GameObject Pooled(GameObject go, Transform t)
        {
            GameObject g = Pooled(go);
            g.transform.SetParent(t);
            return g;
        }

        public static void SetObjectPoolCapacity(
            GameObject go,
            int capacityMin, 
            int capacityMax)
        {
            // Find the pool for the associated gameObject
            GameObjectPool targetPool = GetPoolForObject(go);
            targetPool.capacityMin = capacityMin;
            targetPool.capacityMax = capacityMax;
        }

        /// <summary>
        /// Returns the next available pooled gameObject.
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        private static GameObject Pooled(GameObject go)
        {
            // Find the pool for the associated gameObject
            GameObjectPool targetPool = GetPoolForObject(go);

            // Return next pooled item
            GameObject g = (targetPool.GetNext() as GameObjectPooledComponent).gameObject;
            return g;
        }

        /// <summary>
        /// Finds and returns
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        private static GameObjectPool GetPoolForObject(GameObject go)
        {
            // Find the pool for the associated gameObject
            GameObjectPool targetPool = null;
            foreach (var pool in _pools)
            {
                if (pool.pooledGameObject == go)
                {
                    targetPool = pool;
                    break;
                }
            }
    
            // If the target is null, there doesn't exist a pool for this GameObject yet
            if (targetPool == null)
            {
                targetPool = new GameObjectPool
                {
                    pooledGameObject = go, 
                    poolLabel = "monoPool_" + go.transform.name
                };
                _pools.Add(targetPool);
            }

            return targetPool;
        }

        #endregion Pooling
    }
}

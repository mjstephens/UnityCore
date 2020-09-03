using SharpCore.Utility.Pooling;
using UnityEngine;

namespace UnityCore.Instantiation.Pooling
{
    /// <summary>
    /// 
    /// </summary>
    public class GameObjectPool : PoolBase
    {
        public GameObject pooledGameObject;
        
        protected override IClientPoolable CreateNewPoolable()
        {
            GameObject newObj = Instantiator.Instantiate(pooledGameObject);
            return newObj.AddComponent<GameObjectPooledComponent>();
        }
    }
}
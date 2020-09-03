using SharpCore.Utility.Pooling;
using UnityEngine;

namespace UnityCore.Instantiation.Pooling
{
    /// <summary>
    /// This script is added to gameObjects when they are created for pooled use.
    /// Manages the gameObject lifecycle in relation to the pool ownership status.
    /// </summary>
    public class GameObjectPooledComponent : MonoBehaviour, IClientPoolable
    {
        #region Properties

        public bool availableInPool { get; set; }

        #endregion Properties
        
        
        #region Variables

        private GameObject _go;
        private IPool _pool;
        private bool _deactivateCacheFlag;
        private bool _activateCacheFlag;
        
        #endregion Variables


        #region Lifecycle
        
        /// <summary>
        /// Automatic callback when gameObject is enabled.
        /// </summary>
        private void OnEnable()
        {
            if (!_activateCacheFlag)
            {
                _pool?.ClaimInstance(this);
            }
            else
            {
                _activateCacheFlag = false;
            }
        }
        
        /// <summary>
        /// Automatic callback when gameObject is disabled.
        /// </summary>
        private void OnDisable()
        {
            if (!_deactivateCacheFlag)
            {
                _pool.RelinquishInstance(this);
            }
            else
            {
                _deactivateCacheFlag = false;
            }
        }

        /// <summary>
        /// Automatic callback when gameObject is destroyed.
        /// </summary>
        private void OnDestroy()
        {
            if (!_deactivateCacheFlag)
            {
                _pool.DeleteFromInstance(this);
            }
            else
            {
                _deactivateCacheFlag = false;
            }
        }

        #endregion Lifecycle


        #region Pooling

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pool"></param>
        void IClientPoolable.OnInstanceCreated(PoolBase pool)
        {
            _pool = pool;
            _go = gameObject;
        }

        /// <summary>
        /// 
        /// </summary>
        void IClientPoolable.Claim()
        {
            availableInPool = false;
            if (!_go.activeSelf)
            {
                _activateCacheFlag = true;
                _go.SetActive(true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void IClientPoolable.Relinquish()
        {
            availableInPool = true;
            if (_go.activeSelf)
            {
                _deactivateCacheFlag = true;
                _go.SetActive(false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void IClientPoolable.Recycle()
        {
            _deactivateCacheFlag = true;
            _activateCacheFlag = true;
            _go.SetActive(false);
            _go.SetActive(true);
        }

        /// <summary>
        /// 
        /// </summary>
        void IClientPoolable.DeleteFromPool()
        {
            _deactivateCacheFlag = true;
            Destroy(_go);
        }

        #endregion Pooling
    }
}
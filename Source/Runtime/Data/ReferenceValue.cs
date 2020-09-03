using System;
using UnityEngine;

namespace UnityCore.Data
{
    public abstract class ReferenceValue<T> : UnitySODataContainer, ISerializationCallbackReceiver
    {
        #region Values

        /// <summary>
        /// Initial value, serialized in editor.
        /// </summary>
        public T InitialValue;

        /// <summary>
        /// Runtime value, non-serialized to prevent runtime disc changes.
        /// </summary>
        [NonSerialized]
        public T Value;

        #endregion Values


        #region Serialization

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            Value = InitialValue;
        }

        #endregion Serialization
    }
}
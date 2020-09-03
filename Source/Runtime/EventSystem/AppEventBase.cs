using System;
using SharpCore.EventSystem;
using UnityCore.Data;

namespace UnityCore.EventSystem
{
    public class AppEventBase<T> : UnitySODataContainer
    {
        [NonSerialized]
        public GameEvent <T> Event = new GameEvent<T>();
    }
}
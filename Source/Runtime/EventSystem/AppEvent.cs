using System;
using SharpCore.EventSystem;
using UnityCore.Data;
using UnityEngine;

namespace UnityCore.EventSystem
{
    [CreateAssetMenu(
        fileName = "New Event",
        menuName = "Events/Blank Event")]
    public class AppEvent : UnitySODataContainer
    {
        [NonSerialized]
        public GameEvent Event = new GameEvent();
    }
}
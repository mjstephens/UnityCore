using UnityEngine;

namespace UnityCore.EventSystem
{
    [CreateAssetMenu(
        fileName = "New Transform Event",
        menuName = "Events/Transform Event")]
    public class AppEventTransform : AppEventBase<Transform>
    {
        
    }
}
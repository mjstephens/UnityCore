using UnityEngine;

namespace UnityCore.EventSystem
{
    [CreateAssetMenu(
        fileName = "New Quaternion Event",
        menuName = "Events/Quaternion Event")]
    public class AppEventQuaternion : AppEventBase<Quaternion>
    {
        
    }
}
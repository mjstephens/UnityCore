using UnityEngine;

namespace UnityCore.EventSystem
{
    [CreateAssetMenu(
        fileName = "New Vector3 Event",
        menuName = "Events/Vector3 Event")]
    public class AppEventVector3 : AppEventBase<Vector3>
    {
        
    }
}
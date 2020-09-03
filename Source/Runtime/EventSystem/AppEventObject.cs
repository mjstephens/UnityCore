using UnityEngine;

namespace UnityCore.EventSystem
{
    [CreateAssetMenu(
        fileName = "New Object Event",
        menuName = "Events/Object Event")]
    public class AppEventObject : AppEventBase<object>
    {
        
    }
}
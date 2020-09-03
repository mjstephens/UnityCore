using UnityEngine;

namespace UnityCore.EventSystem
{
    [CreateAssetMenu(
        fileName = "New String Event",
        menuName = "Events/String Event")]
    public class AppEventString : AppEventBase<string>
    {
        
    }
}
using UnityEngine;

namespace UnityCore.Loading
{
    public class StartupSceneLoader : MonoBehaviour
    {
        #region Initialization

        private void Awake()
        {
            // Temp
            OnStartupSceneLoadFinished();
        }

        #endregion Initialization


        #region Load

        /// <summary>
        /// After the startup scene has finished its loading, we can load the gameScene
        /// </summary>
        private void OnStartupSceneLoadFinished()
        {
            CoreLoader.LoadGameScene();
        }

        #endregion Load
    }
}
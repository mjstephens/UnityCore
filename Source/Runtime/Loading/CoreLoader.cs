using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityCore.Loading
{
    public static class CoreLoader
    {
        #region Variables

        public static Transform coreTransform;
        
        private static int _sourceGameScene;

        #endregion Variables
        

        #region Pre-Scene Load

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void LoadCore()
        {
            // Create core
            coreTransform = new GameObject().transform;
            coreTransform.name = "_Core";
            Object.DontDestroyOnLoad(coreTransform);
        }

        #endregion Pre-Scene Load


        #region Scene

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void LoadScene()
        {
            // Switch to startu scene if we aren't there already
            int activeScene = SceneManager.GetActiveScene().buildIndex;
            if (activeScene != 0)
            {
                _sourceGameScene = activeScene;
                SceneManager.LoadScene(0);
            }
        }

        public static void LoadGameScene()
        {
            if (_sourceGameScene != 0)
            {
                SceneManager.LoadScene(_sourceGameScene);
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }

        #endregion Scene
    }
}
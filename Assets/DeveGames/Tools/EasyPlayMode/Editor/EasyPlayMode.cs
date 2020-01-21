using UnityEditor;
using UnityEditor.SceneManagement;
using Utilities.Constants;

namespace DeveGames.Tools.EasyPlayMode.Editor
{
    public static class EasyPlayMode
    {
        private const string LastSceneNameKey = "LastSceneNameKey";
        
        [MenuItem("DeveGames/Tools/Play-Stop %l")]
        public static void PlayStopFromPreLaunchScene()
        {
            if (EditorApplication.isPlaying)
            {
                EditorApplication.isPlaying = false;
                EditorApplication.playModeStateChanged += LoadPrevScene_OnEditorStopOnce;
            }
            else
            {
                EditorPrefs.SetString(LastSceneNameKey, UnityEngine.SceneManagement.SceneManager.GetActiveScene().path);
                EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                EditorSceneManager.OpenScene($"Assets/Scenes/{SceneNames.Loader}.unity");
                EditorApplication.isPlaying = true;
            }
        }


        [MenuItem("DeveGames/Tools/Load Previous Scene")]
        public static void LoadPrevScene()
        {
            if (EditorPrefs.HasKey(LastSceneNameKey))
            {
                EditorSceneManager.OpenScene(EditorPrefs.GetString(LastSceneNameKey));
            }
        }
    
        #region Event Listeners

        private static void LoadPrevScene_OnEditorStopOnce(PlayModeStateChange state)
        {
            EditorApplication.playModeStateChanged -= LoadPrevScene_OnEditorStopOnce;

            LoadPrevScene();
        }

        #endregion
    }
}

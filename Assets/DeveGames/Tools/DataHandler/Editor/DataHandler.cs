using DeveGames.Utilities;
using UnityEditor;
using UnityEngine;

namespace DeveGames.Tools.DataHandler.Editor
{
    public static class DataHandler
    {
        [MenuItem("DeveGames/Tools/Delete Local Data")]
        public static void DeleteLocalData()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
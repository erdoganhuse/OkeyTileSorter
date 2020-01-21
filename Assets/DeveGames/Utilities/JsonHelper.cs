using System;
using UnityEngine;

namespace DeveGames.Utilities
{
    public static class JsonHelper
    {
        public static T[] GetJsonArray<T>(string json)
        {
            string newJson = "{ \"array\": " + json + "}";
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>> (newJson);
            return wrapper.array;
        }
 
        [Serializable]
        private class Wrapper<T>
        {
            public T[] array;
        }    
    }
}
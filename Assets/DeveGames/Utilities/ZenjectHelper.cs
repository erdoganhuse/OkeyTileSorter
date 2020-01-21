using System;
using System.Reflection;
using Zenject;

namespace DeveGames.Utilities
{
    public static class ZenjectHelper
    {
        public static T GetInstaller<T>() where T : MonoInstaller
        {
            return UnityEngine.Object.FindObjectOfType<T>();
        }

        public static DiContainer GetContainerFrom<T>() where T : MonoInstaller
        {
            T installer = GetInstaller<T>();
            
            if (installer == null) return null;

            Type type = installer.GetType();
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            PropertyInfo propertyInfo = type.GetProperty("Container", bindingFlags);

            if (propertyInfo != null)
            {
                return (DiContainer) propertyInfo.GetValue(installer);
            }
            
            return null;
        }
    }
}
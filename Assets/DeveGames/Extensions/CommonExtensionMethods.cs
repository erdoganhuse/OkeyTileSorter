using UnityEngine;

namespace DeveGames.Extensions
{
    public static class CommonExtensionMethods
    {
        public static bool Contains(this LayerMask layerMask, int layer)
        {
            return (layerMask.value & (1 << layer)) > 0;
        }

        public static int ToLayer(int bitmask)
        {
            int result = bitmask > 0 ? 0 : 31;
            while( bitmask > 1 ) 
            {
                bitmask >>= 1;
                result++;
            }
            return result;
        }
    }
}
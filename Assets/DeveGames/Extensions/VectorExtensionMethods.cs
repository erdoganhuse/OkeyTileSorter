using UnityEngine;

namespace DeveGames.Extensions
{
    public static class VectorExtensionMethods
    {
        public static void RotateX( this Vector3 source, float angle )
        {
            float sin = Mathf.Sin( angle );
            float cos = Mathf.Cos( angle );
           
            float ty = source.y;
            float tz = source.z;
            source.y = (cos * ty) - (sin * tz);
            source.z = (cos * tz) + (sin * ty);
        }
       
        public static void RotateY( this Vector3 source, float angle )
        {
            float sin = Mathf.Sin( angle );
            float cos = Mathf.Cos( angle );
           
            float tx = source.x;
            float tz = source.z;
            source.x = (cos * tx) + (sin * tz);
            source.z = (cos * tz) - (sin * tx);
        }
     
        public static Vector3 RotateZ( this Vector3 source, float angle )
        {
//            float sin = Mathf.Sin( angle );
//            float cos = Mathf.Cos( angle );
//           
//            float tx = source.x;
//            float ty = source.y;
//            
//            float x = (cos * tx) - (sin * ty);
//            float y = (cos * ty) + (sin * tx);
//
//            return new Vector3(x, y, source.z);
            
            return Quaternion.Euler(0f, 0f,angle) * source;
        }

        public static float GetPitch( this Vector3 source )
        {
            float len = Mathf.Sqrt( (source.x * source.x) + (source.z * source.z) );
            return( -Mathf.Atan2( source.y, len ) );
        }
           
        public static float GetYaw( this Vector3 source )
        {
            return( Mathf.Atan2( source.x, source.z ) );
        }

        public static float GetXPositionOnLine(Vector3 startOfLine, Vector3 endOfLine, float positionY)
        {
            return (positionY - (endOfLine.x * startOfLine.y - startOfLine.x * endOfLine.y) /
                    (endOfLine.x - startOfLine.x)) / ((endOfLine.y - startOfLine.y) / (endOfLine.x - startOfLine.x));
        }

        public static float GetYPositionOnLine(Vector3 startOfLine, Vector3 endOfLine, float positionX)
        {
            return positionX * ((endOfLine.y - startOfLine.y) / (endOfLine.x - startOfLine.x)) +
                   (endOfLine.x * startOfLine.y - startOfLine.x * endOfLine.y) / (endOfLine.x - startOfLine.x);
        }
    }
}
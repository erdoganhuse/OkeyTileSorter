using System;
using UnityEngine;

namespace DeveGames.Utilities
{
    public static class MathfHelper
    {
        public static float Step(float value, float min, float max, int stepCount)
        {
            if (Math.Abs(value - max) < 0.001f)
            {
                return value;
            }
            else
            {
                float stepGap = (max - min) / stepCount;
                return min + (int)((value - min)/stepGap) * stepGap;
            }
        }

        public static float Angle(Vector3 startPoint, Vector3 endPoint)
        {
            float angle = Mathf.Atan2((endPoint - startPoint).z, (endPoint - startPoint).x) * Mathf.Rad2Deg;

            if (startPoint.x < endPoint.x && startPoint.z > endPoint.z) 
                return 90f - angle;
            else if (startPoint.x > endPoint.x && startPoint.z > endPoint.z) 
                return 270f + angle;
            else if (startPoint.x > endPoint.x && startPoint.z < endPoint.z) 
                return angle - 90f;
            else 
                return 90f - angle;
        }
    }
}
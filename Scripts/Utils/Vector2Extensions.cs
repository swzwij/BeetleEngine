using BeetleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeetleEngine
{
    public static class Vector2Extensions
    {
        /// <summary>
        /// Returns the magnitude of a Vector.
        /// </summary>
        public static double Magnitude(this Vector2 vector)
        {
            double magnitude = Math.Sqrt((vector.x * vector.x) + (vector.y * vector.y));
            return magnitude;
        }

        /// <summary>
        /// Return a normalized vector (magnitude of 1).
        /// </summary>
        public static Vector2 Normalized(this Vector2 vector)
        {
            Vector2 normalizedVector = new Vector2(0, 0);
            double magnitude = Magnitude(vector);

            if(vector.x != 0 && magnitude != 0) normalizedVector.x = vector.x / magnitude;
            if (vector.y != 0 && magnitude != 0) normalizedVector.y = vector.y / magnitude;

            return normalizedVector;
        }      
    }
}

using BeetleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugEngine
{
    public static class Vector2Utils
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

            normalizedVector.x = vector.x / magnitude;
            normalizedVector.y = vector.y / magnitude;

            return normalizedVector;
        }
    }
}

using BeetleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeetleEngine
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

        #region Vector2 (Zero, One, Up, Down, Right, Left)

        /// <summary>
        /// Short for Vector2(0, 0)
        /// </summary>
        public static Vector2 Zero(this Vector2 vector)
        {
            return new Vector2(0, 0);
        }

        /// <summary>
        /// Short for Vector2(1, 1)
        /// </summary>
        public static Vector2 One(this Vector2 vector)
        {
            return new Vector2(1, 1);
        }

        /// <summary>
        /// Short for Vector2(0, 1)
        /// </summary>
        public static Vector2 Up(this Vector2 vector)
        {
            return new Vector2(0, 1);
        }

        /// <summary>
        /// Short for Vector2(0, -1)
        /// </summary>
        public static Vector2 Down(this Vector2 vector)
        {
            return new Vector2(0, -1);
        }

        /// <summary>
        /// Short for Vector2(1, 0)
        /// </summary>
        public static Vector2 Right(this Vector2 vector)
        {
            return new Vector2(1, 0);
        }

        /// <summary>
        /// Short for Vector2(-1, 0)
        /// </summary>
        public static Vector2 Left(this Vector2 vector)
        {
            return new Vector2(-1, 0);
        }

        #endregion 

        #region Vector2 (Add, Subtract, Multiply, Devide)

        /// <summary>
        /// Add two vectors with eachother
        /// </summary>
        public static Vector2 Add(this Vector2 vectorA, Vector2 vectorB)
        {
            double x = vectorA.x + vectorB.x;
            double y = vectorA.y + vectorB.y;
            return new Vector2(x, y);
        }

        /// <summary>
        /// Subtract two vectors with eachother
        /// </summary>
        public static Vector2 Subtract(this Vector2 vectorA, Vector2 vectorB)
        {
            double x = vectorA.x - vectorB.x;
            double y = vectorA.y - vectorB.y;
            return new Vector2(x, y);
        }

        /// <summary>
        /// Multiply two vectors with eachother
        /// </summary>
        public static Vector2 Multiply(this Vector2 vectorA, Vector2 vectorB)
        {
            double x = vectorA.x * vectorB.x;
            double y = vectorA.y * vectorB.y;
            return new Vector2(x, y);
        }

        /// <summary>
        /// Devide two vectors with eachother
        /// </summary>
        public static Vector2 Devide(this Vector2 vectorA, Vector2 vectorB)
        {
            double x = vectorA.x - vectorB.x;
            double y = vectorA.y - vectorB.y;
            return new Vector2(x, y);
        }

        #endregion 
    }
}

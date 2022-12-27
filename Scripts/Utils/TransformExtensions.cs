using BeetleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeetleEngine
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Return the middle point of a object.
        /// </summary>
        public static Vector2 GetMiddle(this Transform transform) // TODO: maybe Rename
        {
            Vector2 position = transform.Position;
            Vector2 scale = transform.Scale;
            Vector2 middle = new Vector2((int)position.x + (int)scale.x / 2, (int)position.y + (int)scale.y / 2);
            return middle;
        }

        /// <summary>
        /// Return direction from one Vector to another.
        /// </summary>
        public static Vector2 Direction(Vector2 from, Vector2 too) // TODO: maybe Rename
        {
            Vector2 direction = new Vector2(too.x - from.x, too.y - from.y);
            return direction;
        }

        /// <summary>
        /// Return the distance between two Vectors.
        /// </summary>
        public static Double GetDistance(Vector2 pointA, Vector2 pointB)
        {
            if (pointA == null || pointB == null) return 0;

            double x = Math.Abs(pointA.x - pointB.x);
            double y = Math.Abs(pointA.y - pointB.y);
            double distance = Math.Sqrt((x * x) + (y * y));

            return distance;
        }
    }
}

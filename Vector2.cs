using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BeetleEngine
{
    public class Vector2
    {
        public double x { get; set; }
        public double y { get; set; }

        public Vector2(double X, double Y)
        {
            x = X;
            y = Y;
        }

        /// <summary>
        /// Return the middle point of a object.
        /// </summary>
        public static Vector2 GetMiddle(Vector2 position, Vector2 Scale) // TODO: maybe Rename
        {
            Vector2 middle = new Vector2((int)position.x + (int)Scale.x / 2, (int)position.y + (int)Scale.y / 2);
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

        /// <summary>
        /// Returns the closest Shape with certain Tag.
        /// </summary>
        public static GameObject GetClosestGameObject(Vector2 Position, string tag, GameObject exeption)
        {
            List<GameObject> shapes = BeetleEngine.GetGameObjectsWithTag(tag);

            if (shapes.Count <= 0) return null; // TODO: Error Log 

            GameObject closestShape = shapes[0];

            foreach (GameObject shape in shapes)
            {
                if (shape == exeption) continue;

                if (GetDistance(shape.Position, Position) < GetDistance(closestShape.Position, Position))
                {
                    closestShape = shape;
                }
            }

            return closestShape;
        }

        #region Vector2 Operator overloading

        public static Vector2 operator +(Vector2 vectorA, Vector2 vectorB) => new Vector2(vectorA.x + vectorB.x, vectorA.y + vectorB.y);
        public static Vector2 operator -(Vector2 vectorA, Vector2 vectorB) => new Vector2(vectorA.x - vectorB.x, vectorA.y - vectorB.y);
        public static Vector2 operator *(Vector2 vectorA, Vector2 vectorB) => new Vector2(vectorA.x * vectorB.x, vectorA.y * vectorB.y);
        public static Vector2 operator /(Vector2 vectorA, Vector2 vectorB) => new Vector2(vectorA.x / vectorB.x, vectorA.y / vectorB.y);

        #endregion
    }
}

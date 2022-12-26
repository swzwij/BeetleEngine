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

        public static Vector2 operator +(Vector2 vectorA, Vector2 vectorB) => new Vector2(vectorA.x + vectorB.x, vectorA.y + vectorB.y);
        public static Vector2 operator -(Vector2 vectorA, Vector2 vectorB) => new Vector2(vectorA.x - vectorB.x, vectorA.y - vectorB.y);
        public static Vector2 operator *(Vector2 vectorA, Vector2 vectorB) => new Vector2(vectorA.x * vectorB.x, vectorA.y * vectorB.y);
        public static Vector2 operator /(Vector2 vectorA, Vector2 vectorB) => new Vector2(vectorA.x / vectorB.x, vectorA.y / vectorB.y);
    }
}

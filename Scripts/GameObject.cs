using BugEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BeetleEngine
{
    public class GameObject
    {
        public Transform Transform { get; set; }
        public Color Color = Color.Black;
        public string Tag;
        public bool HasGravity;

        public GameObject(Transform transform, Color color, string tag, bool hasGravity = false)
        {
            Transform = transform;
            this.Color = color;
            Tag = tag;
            BeetleEngine.RegisterGameObject(this);
            HasGravity = hasGravity;
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

                if (TransformExtensions.GetDistance(shape.Transform.Position, Position) < TransformExtensions.GetDistance(closestShape.Transform.Position, Position))
                {
                    closestShape = shape;
                }
            }

            return closestShape;
        }
    }
}

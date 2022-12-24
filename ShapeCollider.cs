using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeetleEngine
{
    public static class ShapeCollider
    {
        public static bool IsColliding(this Shape shape, string tag)
        {
            List<Shape> shapes = BeetleEngine.GetShapesWithTag(tag);
            for (int i = 0; i < shapes.Count; i++)
            {
                Shape obj = shapes[i];

                if (obj.Position.y + obj.Scale.y > shape.Position.y &&
                    shape.Position.y + shape.Scale.y > obj.Position.y &&
                    obj.Position.x + obj.Scale.x > shape.Position.x &&
                    shape.Position.x + shape.Scale.x > obj.Position.x)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeetleEngine
{
    public static class GameObjectCollider
    {
        public static bool IsColliding(this GameObject shape, string tag)
        {
            List<GameObject> shapes = BeetleEngine.GetGameObjectsWithTag(tag);
            for (int i = 0; i < shapes.Count; i++)
            {
                GameObject obj = shapes[i];

                if (obj.Transform.Position.y + obj.Transform.Scale.y > shape.Transform.Position.y &&
                    shape.Transform.Position.y + shape.Transform.Scale.y > obj.Transform.Position.y &&
                    obj.Transform.Position.x + obj.Transform.Scale.x > shape.Transform.Position.x &&
                    shape.Transform.Position.x + shape.Transform.Scale.x > obj.Transform.Position.x)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

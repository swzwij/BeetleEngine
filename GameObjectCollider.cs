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

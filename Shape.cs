using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeetleEngine
{
    public class Shape
    {
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public Color Color = Color.Black;
        public string Tag;

        public Shape(Vector2 position, Vector2 scale, Color color, string tag)
        {
            Position = position;
            Scale = scale;
            this.Color = color;
            Tag = tag;
            BeetleEngine.RegisterShape(this);
        }

        public bool IsCollided(Shape shape, string tag)
        {
            // TODO: correcte AABB intersection gebruiken
            List<Shape> shapes = BeetleEngine.GetShapesWithTag(tag);

            foreach (Shape obj in shapes)
            {
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

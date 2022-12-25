using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeetleEngine
{
    public class GameObject
    {
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public Color Color = Color.Black;
        public string Tag;
        public bool HasGravity;

        public GameObject(Vector2 position, Vector2 scale, Color color, string tag, bool hasGravity = false)
        {
            Position = position;
            Scale = scale;
            this.Color = color;
            Tag = tag;
            BeetleEngine.RegisterGameObject(this);
            HasGravity = hasGravity;
        }
    }
}

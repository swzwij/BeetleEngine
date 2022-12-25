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
    }
}

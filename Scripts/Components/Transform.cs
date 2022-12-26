using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeetleEngine
{
    public class Transform
    {
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }

        public Transform(Vector2 position, Vector2 scale)
        {
            Position = position;
            Scale = scale;
        }
    }
}

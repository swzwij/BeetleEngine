using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeetleEngine
{
    public class MouseInput
    {
        // Mouse clicks
        public Vector2 MousePosition => new Vector2(Control.MousePosition.X, Control.MousePosition.Y);
    }
}

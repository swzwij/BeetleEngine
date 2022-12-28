using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;

namespace BeetleEngine
{
    public class KeyInput
    {
        public bool Up => (Keyboard.GetKeyStates(Key.Up) & KeyStates.Down) > 0;
        public bool Down => (Keyboard.GetKeyStates(Key.Down) & KeyStates.Down) > 0;
        public bool Left => (Keyboard.GetKeyStates(Key.Left) & KeyStates.Down) > 0;
        public bool Right => (Keyboard.GetKeyStates(Key.Right) & KeyStates.Down) > 0;
        public bool Plus => (Keyboard.GetKeyStates(Key.P) & KeyStates.Down) > 0;
        public bool Minus => (Keyboard.GetKeyStates(Key.O) & KeyStates.Down) > 0;
    }
}

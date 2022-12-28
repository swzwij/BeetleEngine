using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace BeetleEngine
{
    public class Debug
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void Error(string message, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null)
        {

            DateTime currentTime = DateTime.Now;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(currentTime + " > " + message + " at line " + lineNumber + " in " + caller);
            Console.ForegroundColor= ConsoleColor.White;
        }

        public void Warning(string message, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null)
        {
            DateTime currentTime = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(currentTime + " > " + message + " at line " + lineNumber + " in " + caller);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

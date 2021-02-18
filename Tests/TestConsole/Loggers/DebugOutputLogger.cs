using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Loggers
{
    internal class DebugOutputLogger : Logger
    {
        public override void Log(string Message)
        {
            System.Diagnostics.Debug.WriteLine(Message);
        }
    }
}

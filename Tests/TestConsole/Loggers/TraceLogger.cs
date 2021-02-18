using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Loggers
{
    internal class TraceLogger : Logger
    {
        public override void Log(string Message)
        {
            System.Diagnostics.Trace.WriteLine(Message);
        }

        public override void Flush()
        {
            System.Diagnostics.Trace.Flush();
        }
    }
}

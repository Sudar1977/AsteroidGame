using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Loggers
{
    internal class ConsoleLogger : Logger
    {

        public override void Log(string Message)
        {
            Console.WriteLine(Message);
        }
    }
}

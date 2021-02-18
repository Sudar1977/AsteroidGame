using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Loggers
{
    internal class CombineLogger : Logger
    {
        private readonly List<Logger> _Loggers = new List<Logger>();

        public void Add(Logger logger)
        {
            _Loggers.Add(logger);
        }

        public override void Log(string Message)
        {
            foreach(var logger in _Loggers)
            {
                logger.Log(Message);
            }
        }

        public override void Flush()
        {
            foreach(var logger in _Loggers)
            {
                logger.Flush();
            }
        }
    }
}

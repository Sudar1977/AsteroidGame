using System;

namespace TestConsole
{
    internal abstract class Logger
    {
        public abstract void Log(string Message);

        public void LogInformation(string Message)
        {
            Log($"{DateTime.Now:s}[info]:{Message}");
        }

        public void LogWarning(string Message)
        {
            Log($"{DateTime.Now:s}[warn]:{Message}");
        }

        public void LogError(string Message)
        {
            Log(string.Format("{0:s}[error]:{1}", DateTime.Now,Message));
        }
    }

}

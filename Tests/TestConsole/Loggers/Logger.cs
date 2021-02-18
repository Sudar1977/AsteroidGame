using System;

namespace TestConsole
{
    internal abstract class Logger : ILogger //1:59:17
    {
        public static Logger CreateFileLogger(string FileName)
        {
            return new TextFileLogger(FileName);
        }
 
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

        public virtual void Flush()
        {

        }

    }
}

using System.IO;

namespace TestConsole
{
    internal class TextFileLogger : Logger
    {
        private readonly TextWriter _Writer;
        private int _Counter;

        public TextFileLogger(string FileName)
        {
            _Writer = File.CreateText(FileName);
        }

        public override void Log(string Message)
        {
            _Writer.WriteLine("{0}>{1}",_Counter++,Message);
        }

        public override void Flush()
        {
            _Writer.Flush();
        }
    }

}

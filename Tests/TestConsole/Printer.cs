using System;

namespace TestConsole
{
    class Printer
    {
        public virtual void Print(string Message)
        {
            Console.WriteLine(Message);
        }
    }
}

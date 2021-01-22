using System;

namespace TestConsole
{
    class PrefixPrinter : Printer
    {
        public string Prefix { get; set; }

        public void PrintData(double X)
        {
            Console.WriteLine("{1} - double:{0}", X, Prefix);
        }

        public override void Print(string Message)
        {
            Console.WriteLine(Prefix);
            base.Print(Message);

        }
    }
}

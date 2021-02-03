﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Loggers;
using System.Diagnostics;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)//Ctrl+K,D
        {
            //Player player0 = null;
            //Player player1 = new Player();
            //player1.Name = "Иванов";
            //player1.Birthday = new DateTime(1977, 03, 23, 9, 0, 0);
#if false
            Console.Write("Введите фамилию >");
            var surname = Console.ReadLine();

            Player player1 = new Player(surname, new DateTime(1977, 03, 23, 9, 0, 0));

            Console.WriteLine(player1.GetName());
            Console.WriteLine(player1.Name);
#endif

#if false
            var v1 = new Vector2D(5, 7);
            var v2 = new Vector2D(-7, 2);
            var v3 = v1 + v2;
            var v4 = v3 + 3.1459265358979;

            CultureInfo ru = new CultureInfo("ru-ru");
            CultureInfo en_us = new CultureInfo("en-us");

            double pi = double.Parse("3.1459265358979",en_us);
            int i = (int)pi;

            double lenght = v4;
#endif

#if false
            Printer printer = new Printer();
            PrefixPrinter prefixPrinter = new PrefixPrinter();
            prefixPrinter.Prefix = "!!!!!!!-------!!!!!!!";
            prefixPrinter.Print("QWE");

            printer.Print("Hello World!");
            prefixPrinter.PrintData(3.14);

            printer.Print("123");

            printer = prefixPrinter;

            Printer printer1 = new PrefixPrinter();

            printer.Print("345");
            printer1.Print("678");
#endif

            //Lesson2
            //Logger log = new TextFileLogger("text.log");
            //Logger log = new ConsoleLogger();
            //Logger log = new DebugOutputLogger();
            //Logger log = new TraceLogger();
            CombineLogger log = new CombineLogger();
            log.Add(new ConsoleLogger());
            log.Add(new DebugOutputLogger());
            log.Add(new TraceLogger());
            log.Add(new TextFileLogger("new_log.log"));

            //Trace.Listeners.Add(new TextWriterTraceListener("logger.log"));
            //Trace.Listeners.Add(new XmlWriterTraceListener("logger.xml"));

            log.LogInformation("Message1");
            log.LogWarning("Info message");
            log.LogError("Error message");


       

            ComputeLongDataValue(100,log);

            Console.WriteLine("Программа завршена");
            Console.ReadLine();
            log.Flush();

        }

        private static double ComputeLongDataValue(int Count, Logger Log) //1:12:39
        {
            var result = 0;
            for(var i = 0;i < Count; i++)
            {
                result++;
                Log.LogInformation($"Вычисление итерации {i}"); ;
                System.Threading.Thread.Sleep(100);
            }
            return result;
        }

    }
}

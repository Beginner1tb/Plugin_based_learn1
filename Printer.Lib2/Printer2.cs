using Printer.SDK;
using System;

namespace Printer.Lib2
{
    public class Printer2:IPrinter
    {
        public void print(string str)
        {
            Console.WriteLine("Printer2 is Working.Out "+str);
        }
    }
}

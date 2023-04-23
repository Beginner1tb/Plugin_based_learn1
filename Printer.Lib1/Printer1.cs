using Printer.SDK;
using System;

namespace Printer.Lib1
{
    public class Printer1:IPrinter
    {
        public void print(string str)
        {
            Console.WriteLine("Print1 is Working.Out " + str);
        }
    }
}

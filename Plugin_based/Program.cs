using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Loader;
using Printer.SDK;
using System.Linq;

namespace Plugin_based
{
    class Program
    {
        static void Main(string[] args)
        {
            //object ooo = new object[] { };
            //var ii =ooo as MyInt;
            //ii.iiii1();
            var folder = Path.Combine(Environment.CurrentDirectory, "PrintMachine");
            var files = Directory.GetFiles(folder);
            var printerTypes = new List<Type>();
            foreach (var file in files)
            {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file);
                ///效果相同
                //var assembly = System.Reflection.Assembly.LoadFrom(file);
                var types = assembly.GetTypes();
                foreach (var t in types)
                {
                    //if (t.GetMethod("print") != null)
                    //{
                    //    printerTypes.Add(t);
                    //}
                    if (t.GetInterfaces().Contains(typeof(IPrinter)))
                    {
                        printerTypes.Add(t);
                    }

                }
            }       

            if (printerTypes.Count>0)
            {
                for (int i = 0; i < printerTypes.Count; i++)
                {
                    Console.WriteLine(printerTypes[i].Name);

                }

                var t = printerTypes[1];
                var m = t.GetMethod("print");
                var o = Activator.CreateInstance(t);
                //m.Invoke(o, new object[] { "Print2 OK" });
                var a = o as IPrinter;
                a.print("it's Printer2");
            }



        }
    }

    //interface MyInt
    //{
    //    void iiii1();
    //}

    //public class MyC : MyInt
    //{
    //    public void iiii1()
    //    {
    //        Console.WriteLine("00000");
    //    }
    //}
}

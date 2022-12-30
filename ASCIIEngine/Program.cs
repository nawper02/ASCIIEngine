using ASCIIEngine_SRC;
using System;
using System.Security.Cryptography;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(195, 45);
            int rows = Console.WindowHeight;
            int cols = Console.WindowWidth;

            MainWindow mw = new(rows, cols, " ASCII Engine ");
            
            InteractiveLabel i = new("Hello World!", ConsoleColor.White, 2, 2);
            InteractiveLabel i2 = new("Hello World 2!", ConsoleColor.White, 2, 2);

            Panel p = new(23, 50, 20, 45, " Panel 1 ");
            Panel p2 = new(10, 30, 30, 5, " Panel 2 ");

            List<string> strings = new();
            strings.Add("Item 1");
            strings.Add("Item 2");
            
            ListView lv = new(strings, 2, 2);
            lv.SetAction(0, i2.ChangeColor);
            lv.SetAction(1, i.ChangeColor);


            p.AddElement(lv);
            p2.AddElement(i2);
            mw.AddPanel(p);
            mw.AddPanel(p2);
            mw.AddElement(i);

            mw.Run();

        }
    }
}
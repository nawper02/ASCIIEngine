using ASCIIEngine_SRC;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(195, 45);
            int rows = Console.WindowHeight;
            int cols = Console.WindowWidth;
            
            MainWindow mw = new(rows, cols);
            mw.SetName(" Main Window ", ConsoleColor.White);
            
            InteractiveLabel i = new("Hello World!", ConsoleColor.White, 2, 2);
            InteractiveLabel i2 = new("Hello World 2!", ConsoleColor.White, 2, 2);

            Panel p = new(10, 30, 30, 30);

            p.AddElement(i);
            mw.AddElement(p);
            mw.AddElement(i2);

            mw.Run();

        }
    }
}
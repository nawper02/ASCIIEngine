using ASCIIEngine_SRC;
using System;


// add interactables / event handling (done by main window)


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(195, 45);
            int rows = Console.WindowHeight;
            int cols = Console.WindowWidth;

            // Console.SetWindowSize(width, height);

            MainWindow mw = new(rows, cols);
            mw.SetName(" Main Window ", ConsoleColor.White);

            Panel p = new(10, 40, 10, 10);

            Panel p2 = new(10, 40, 25, 10);

            p.SetName(" Panel Name ", ConsoleColor.Cyan);
            p2.SetName(" Other panel name!!! ", ConsoleColor.Red);
            Label l = new("Hello", ConsoleColor.DarkBlue, 1, 1);
            //Panel p3 = new(3, 10, 10, 10);
            //p.AddElement(l);
            //p.AddElement(p3);
            p.AddElement(l);

            mw.AddElement(p);
            mw.AddElement(p2);

            //mw.AddElement(p3);

            mw.Draw();

            Console.SetCursorPosition(0, 0); // x, y (col, row)

            Console.ReadKey();

        }
    }
}
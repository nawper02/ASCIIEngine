﻿using System;
namespace ASCIIEngine_SRC
{
	public class MainWindow : Panel
	{

        public MainWindow(int rows, int cols) : base (rows, cols, 0, 0)
        {
            //Init();
        }

        public void Draw()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                { 
                    Console.ForegroundColor = buffer[i, j].color;
                    Console.Write(buffer[i, j].c);
                }
                if (!(i == rows-1)) Console.WriteLine();
            }
        }
    }
}

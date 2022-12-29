using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASCIIEngine_SRC
{
	public class MainWindow : Panel
	{
        public List<Panel> panels;
        public int activeIndex;
        public Panel activePanel;
        
        public MainWindow(int rows, int cols, string name) : base (rows, cols, 0, 0, name)
        {
            activeIndex = 0;
            
            panels = new List<Panel>();
            panels.Add(this);

            activePanel = panels[activeIndex];
            panels[activeIndex].Activate();

        }


        public void Run()
        {
            while (true)
            {
                Draw();
                HandleEvents();
            }
        }
        
        private void Draw()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.BackgroundColor = buffer[i, j].background;
                    Console.ForegroundColor = buffer[i, j].color;
                    Console.Write(buffer[i, j].c);
                }
                if (!(i == rows - 1)) Console.WriteLine();
            }
        }
        public void AddPanel(Panel p)
        {
            panels.Add(p);

            AddElement(p);
        }
        public void CycleActivePanel()
        {
            // Deactivate the current active panel
            panels[activeIndex].IsActive = false;

            panels[activeIndex].Deactivate();

            // Increment the active index and wrap around if necessary
            activeIndex = (activeIndex + 1) % panels.Count;

            // Activate the new active panel
            panels[activeIndex].IsActive = true;

            panels[activeIndex].Activate();

            activePanel = panels[activeIndex];
        }
        public void HandleEvents()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Escape) Environment.Exit(0);
            else if (keyInfo.Key == ConsoleKey.Tab)
            {
                CycleActivePanel();
            }
            else
            {
                activePanel.HandleEvent(keyInfo);
            }
            //foreach (Interactive i in interactables)
            //{
            //    i.HandleKeyPress(keyInfo);
            //}
        }
    }
}


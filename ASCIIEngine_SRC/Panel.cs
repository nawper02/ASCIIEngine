using System;
namespace ASCIIEngine_SRC
{
	public class Panel : Interactive
	{
        public List<Interactive> interactables = new List<Interactive>();
        public bool IsActive { get; set; }
        public string name;
        
        public Panel(int rows, int cols, int row, int col, string name) : base(rows, cols, row, col)
            {
                this.name = name;
                Init();
            }
        
        public void Init()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    char c = Util.GetEdgeChar(i, j, rows, cols);
                    buffer[i, j] = new TextElement(c, ConsoleColor.White);
                }
            }
            SetName(name, ConsoleColor.White);
        }

        public void SetName(string s, ConsoleColor color)
        {
            try
            {
                for (int i = 0; i < s.Length; i++)
                {
                    buffer[0, i + 2].color = color;
                    buffer[0, i + 2].c = s[i];
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Name too long for Panel: " + ex.Message);
                Environment.Exit(1);
            }
        }

        public void Activate()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Util.IsEdge(i, j, rows, cols))
                    {
                        buffer[i, j].Flip();
                    }
                }
            }
        }
        
        public void Deactivate()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Util.IsEdge(i, j, rows, cols))
                    {
                        buffer[i, j].Flip();
                    }
                }
            }
        }

        public void AddElement(BoundedElement e)
        {
            try
            {
                for (int i = 0; i < e.rows; i++)
                {
                    for (int j = 0; j < e.cols; j++)
                    {
                        buffer[i + e.row, j + e.col] = e.buffer[i, j];
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Element doesn't fit in MainWindow: " + ex.Message);
                Environment.Exit(1);
            }
            if (e is Interactive)
            {
                interactables.Add((Interactive)e);
                foreach (KeyValuePair<ConsoleKey, Action> kvp in ((Interactive)e).actions)
                {
                    this.AddAction(kvp.Key, kvp.Value);
                }
            }
        }
        public void HandleEvent(ConsoleKeyInfo keyInfo)
        {
            foreach (Interactive i in interactables)
            {
                i.HandleKeyPress(keyInfo);
            }
        }
    }
}


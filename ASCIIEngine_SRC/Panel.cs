using System;
namespace ASCIIEngine_SRC
{
	public class Panel : Interactive
	{
        public List<Interactive> interactables = new List<Interactive>();
        public Panel(int rows, int cols, int row, int col) : base(rows, cols, row, col)
        {
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
            // if e is interactive, add to list of interactables
            if (e is Interactive)
            {
                interactables.Add((Interactive)e);
                // add all of e's actions to this panel's actions
                foreach (KeyValuePair<ConsoleKey, Action> kvp in ((Interactive)e).actions)
                {
                    this.AddAction(kvp.Key, kvp.Value);
                }
            }
        }
    }
}


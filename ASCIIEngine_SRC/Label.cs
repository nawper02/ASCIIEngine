using System;
namespace ASCIIEngine_SRC
{
	public class Label : BoundedElement
	{
        public string s;
        public ConsoleColor color;
		public Label(string s, ConsoleColor color, int row, int col) : base(1, s.Length, row, col)
		{
            this.s = s;
            this.color = color;
            Init();
		}

        public void Init()
        {
            for (int i = 0; i < s.Length; i++)
            {
                    buffer[0, i] = new TextElement(s[i], color);
            }
        }
    }
}

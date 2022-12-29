using System;
namespace ASCIIEngine_SRC
{
	public class TextElement
	{
		public char c;
		public ConsoleColor color;
        public ConsoleColor background;
        public TextElement(char c, ConsoleColor color)
		{
			this.c = c;
			this.color = color;
            this.background = ConsoleColor.Black;
        }
        public void Flip()
        {
            if (background == ConsoleColor.Black)
            {
                background = ConsoleColor.White;
                color = ConsoleColor.Black;
            }
            else
            {
                background = ConsoleColor.Black;
                color = ConsoleColor.White;
            }
        }
    }
}


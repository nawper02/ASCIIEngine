// Class just like the 'Label' class, but interactable so it changes color when q is pressed

using System;
namespace ASCIIEngine_SRC
{
    public class InteractiveLabel : Interactive
    {
        public string s;
        public ConsoleColor color;
        public bool IsRed;
        public InteractiveLabel(string s, ConsoleColor color, int row, int col) : base(1, s.Length, row, col)
        {
            this.IsRed = false;
            this.s = s;
            this.color = color;
            this.AddAction(ConsoleKey.Q, () => { ChangeColor(); });
            Init();
        }

        public void Init()
        {
            for (int i = 0; i < s.Length; i++)
            {
                buffer[0, i] = new TextElement(s[i], color);
            }
        }
        public void ChangeColor()
        {
            if (!IsRed)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    buffer[0, i].color = ConsoleColor.Red;
                    IsRed = true;
                }
            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    buffer[0, i].color = ConsoleColor.White;
                    IsRed = false;
                }
            }
        }
    }
}
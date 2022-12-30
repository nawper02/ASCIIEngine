// Class just like the 'Label' class, but interactable so it changes color when q is pressed

using System;
namespace ASCIIEngine_SRC
{
    public class ListView : Interactive
    {
        public List<string> strings;
        public List<Action> LV_Actions;
        public int activeIndex;
        public ListView(List<string> strings, int row, int col) : base(strings.Count, strings.Max(s => s.Length), row, col)
        {
            this.strings = strings;
            this.LV_Actions = new();
            
            this.AddAction(ConsoleKey.DownArrow, () => { CycleActiveDown(); });
            this.AddAction(ConsoleKey.UpArrow, () => { CycleActiveUp(); });
            this.AddAction(ConsoleKey.Enter, () => { Select(); });
            
            Init();
        }

        public void Init()
        {
            for (int i = 0; i < strings.Count; i++)
            {
                for (int j = 0; j < strings[i].Length; j++)
                {
                    buffer[i, j] = new TextElement(strings[i][j], ConsoleColor.White);
                }
                for (int j = strings[i].Length; j < strings.Max(s => s.Length); j++)
                {
                    buffer[i, j] = new TextElement(' ', ConsoleColor.White);
                }

            }
            activeIndex = 0;
            FlipActive();
        }
        public void FlipActive()
        {
            for (int i = 0; i < strings.Max(s => s.Length); i++)
            {
                buffer[activeIndex, i].Flip();
            }
        }
        public void CycleActiveUp()
        {

            FlipActive();

            if (activeIndex == 0)
            {
                activeIndex = strings.Count - 1;
            }
            else
            {
                activeIndex = (activeIndex - 1) % strings.Count;
            }

            FlipActive();

        }
        public void CycleActiveDown()
        {
            FlipActive();

            activeIndex = (activeIndex + 1) % strings.Count;

            FlipActive();
        }
        public void Select()
        {
            LV_Actions[activeIndex]();

        }
        public void SetAction(int index, Action action)
        {
            LV_Actions[index] = action;

        }

    }
}
// Class just like the 'Label' class, but interactable so it changes color when q is pressed

using System;
namespace ASCIIEngine_SRC
{
    public class ListView : Interactive
    {
        public List<string> strings;
        public ListView(List<string> strings, int row, int col) : base(strings.Count, strings.Max(s => s.Length), row, col)
        {
            this.strings = strings;
            this.AddAction(ConsoleKey.DownArrow, () => { CycleActiveDown(); });
            this.AddAction(ConsoleKey.UpArrow, () => { CycleActiveUp(); });
            Init();
        }

        public void Init()
        {

        }
        public void CycleActiveUp()
        {

        }
        public void CycleActiveDown()
        {

        }
    }
}
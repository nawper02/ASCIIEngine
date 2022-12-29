using System;
namespace ASCIIEngine_SRC
{
    public class Interactive : BoundedElement
    {
        public Dictionary<ConsoleKey, Action> actions;
        public Interactive(int rows, int cols, int row, int col) : base(rows, cols, row, col)
        {
            this.actions = new();
        }
        public void AddAction(ConsoleKey key, Action action)
        {
            actions[key] = action;
        }

        public void HandleKeyPress(ConsoleKeyInfo keyInfo)
        {
            if (actions.ContainsKey(keyInfo.Key))
            {
                actions[keyInfo.Key]();
            }
        }
    }
}

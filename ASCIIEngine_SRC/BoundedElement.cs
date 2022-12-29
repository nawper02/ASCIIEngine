using System;
namespace ASCIIEngine_SRC
{
	public class BoundedElement
	{
        public int row;
        public int col;
        public int rows;
        public int cols;
        public TextElement[,] buffer;

        public BoundedElement(int rows, int cols, int row, int col)
		{
            this.row = row;
            this.col = col;
            this.rows = rows;
            this.cols = cols;
            this.buffer = new TextElement[rows, cols];
        }
	}
}


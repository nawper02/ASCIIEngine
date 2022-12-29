using System;
namespace ASCIIEngine_SRC
{
	public static class Util
	{
		public static char GetEdgeChar(int i, int j, int rows, int cols)
		{
            if ((i == 0) && (j == 0))
            {
                return '╔';
            }

            else if ((i == rows-1) && (j == 0))
            {
                return '╚';
            }

            else if ((i == 0) && (j == cols-1))
            {
                return '╗';
            }

            else if ((i == rows - 1) && (j == cols - 1))
            {
                return '╝';
            }

            else if ((j == 0) || (j == cols - 1))
            {
                return '║';
            }

            else if ((i == 0) || (i == rows - 1))
            {
                return '═';
            }

            else
            {
                return ' ';
            }
        }
	}
}


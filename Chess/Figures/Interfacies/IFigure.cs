using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures
{
    public interface IFigure
    {
        public void GetStepOnField(int x, int y, bool[,] field);
        public int GetHashCode();
    }
}

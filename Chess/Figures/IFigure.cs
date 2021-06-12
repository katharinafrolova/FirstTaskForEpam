using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures
{
    public interface IFigure
    {
        public void GetStep(int x, int y);
    }
}

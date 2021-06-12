using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures
{
    public abstract class Figure: IFigure
    {
        public string Color { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public bool BeingOnTheField { get; set; }

        public abstract void GetStep(int x, int y, bool[,] field);

        public abstract bool ChekingFreeSquaries(int x, int y, bool[,] field);
        //public abstract void TakePiece(int x, int y);





    }
}

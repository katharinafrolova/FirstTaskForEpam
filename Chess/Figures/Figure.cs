using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures
{
    public abstract class Figure: IFigure, ICloneable
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public bool BeingOnTheField { get; set; }

        public abstract bool GetStepOnField(int x, int y, bool[,] field);

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        //public abstract int GetHashCode();
        //public abstract string ToString();

    }
}

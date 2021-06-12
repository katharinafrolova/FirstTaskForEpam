using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures.TypeOfFigures
{
    public class Pawn: Figure
    {
        bool FirstStap { get; set; }

        public Pawn(string color, int positionX, int positionY, bool beingOnTheField, bool firstStap)
        {
            FirstStap = firstStap;
            Color = color;
            PositionX = positionX;
            PositionY = positionY;
            BeingOnTheField = beingOnTheField;
        }
        public override void GetStep(int x, int y, bool[,] field)
        {
            try
            {
                if (FirstStap == true && PositionX - x == 0 && (Math.Abs(PositionY - y) == 2 || Math.Abs(PositionY - y) == 1))
                {
                    PositionX = x;
                    PositionY = y;
                }
                else if (FirstStap == false && PositionX - x == 0 && Math.Abs(PositionY - y) == 1)
                {
                    PositionX = x;
                    PositionY = y;
                }
                else
                    throw new Exception("Wrong move!");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override string ToString()
        {
            return ($"Color: {Color} \n  Position X: {PositionX.ToString()} \n Position Y: {PositionY.ToString()} \n Being on the field: {BeingOnTheField.ToString()} \n");
        }
        public override int GetHashCode()
        {
            int hashCode = -831015500;
            hashCode = hashCode * -1521134295 + Color.GetHashCode();
            hashCode = hashCode * -1521134295 + PositionX.GetHashCode();
            hashCode = hashCode * -1521134295 + PositionY.GetHashCode();
            hashCode = hashCode * -1521134295 + BeingOnTheField.GetHashCode();
            return hashCode;
        }

    }
}

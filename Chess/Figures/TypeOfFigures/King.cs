using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures
{
    public class King: Figure
    {

        public King(string color, int positionX, int positionY, bool beingOnTheField)
        {
            Name = "King";
            Color = color;
            PositionX = positionX;
            PositionY = positionY;
            BeingOnTheField = beingOnTheField;
        }
        public override void GetStepOnField(int x, int y, bool[,] field)
        {
            try
            {
                if(Math.Abs(PositionX-x) == 1 && Math.Abs(PositionY -y) == 1)
                {
                    PositionX = x;
                    PositionY = y;
                }
                else
                    throw new Exception("Wrong move!");

            }
            catch(Exception ex)
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

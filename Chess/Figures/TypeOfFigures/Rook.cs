using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures.TypeOfFigures
{
    public class Rook: Figure
    {
        public Rook(string color, int positionX, int positionY, bool beingOnTheField)
        {
            Name = "Rook";
            Color = color;
            PositionX = positionX;
            PositionY = positionY;
            BeingOnTheField = beingOnTheField;
        }
        public override bool GetStepOnField(int x, int y, bool[,] field)
        {
            bool eatingPiece = false;

            if (PositionX - x != 0 && PositionY - y == 0 || PositionX - x == 0 && PositionY - y != 0)
            {
                if (ChekingFreeSquaries(x, y, field))
                {
                    if (field[x, y] == false)
                        eatingPiece = true;
                    PositionX = x;
                    PositionY = y;
                }
                else
                    throw new Exception("This piace doesn't walk through the others!");
            }
            else
                throw new Exception("Wrong move!");


            return eatingPiece;
        }

        public bool ChekingFreeSquaries(int x, int y, bool[,] field)
        {
            bool result = true;
            int i = 1;
            int firstPositionOfTheChangingCoordinate = 0;
            int lastPositionOfTheChangingCoordinate = 0;
            if (Math.Abs(PositionX - x) > 1 || Math.Abs(PositionY - y) > 1)
            {
                if (PositionX > x && PositionX - x != 0)
                {
                    firstPositionOfTheChangingCoordinate = PositionX;
                    lastPositionOfTheChangingCoordinate = x;
                    i = -1;
                }
                else if (PositionY > y && PositionY - y != 0)
                {
                    firstPositionOfTheChangingCoordinate = PositionY;
                    lastPositionOfTheChangingCoordinate = y;
                    i = -1;
                }
                    
                while (firstPositionOfTheChangingCoordinate + i != lastPositionOfTheChangingCoordinate)
                {
                    if (PositionX - x != 0 && field[PositionX + i, PositionY] == false)
                    {
                        result = false;
                        break;
                    }
                    else if(PositionY - y != 0 && field[PositionX, PositionY + i] == false)
                    {
                        result = false;
                        break;
                    }
                    if (PositionX > x || PositionY > y)
                        i--;
                    else if(PositionX < x || PositionY < y)
                        i++;
                }
            }
            return result;
        }
 
        public override string ToString()
        {
            return ($"Color: {Color} \n  Position X: {PositionX.ToString()} \n Position Y: {PositionY.ToString()} \n Being on the Field: {BeingOnTheField.ToString()} \n");
        }

        public override bool Equals(object obj) => obj is Rook rook && Name == rook.Name && Color == rook.Color && PositionX == rook.PositionX && PositionY == rook.PositionY;

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

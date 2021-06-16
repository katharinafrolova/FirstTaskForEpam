using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures.TypeOfFigures
{
    public class Knight: Figure
    {
        public Knight(string color, int positionX, int positionY, bool beingOnTheField)
        {
            Name = "Knight";
            Color = color;
            PositionX = positionX;
            PositionY = positionY;
            BeingOnTheField = beingOnTheField;
        }

        /// <summary>
        /// A Knight move that is checked for the correct move if the pawn
        /// </summary>
        /// <param name="x"> Finish coordinat x</param>
        /// <param name="y"> Finish coordinat y</param>
        /// <param name="field"> Map for piace with bool value (true - free; false = not free)</param>
        /// <returns> 
        /// If the place that the Knight moved to was occupied (Rook is eating another piace) - true; 
        /// If the place that the Knight moved to wasn't occupied (Rook isn't eating another piace) - false; 
        /// </returns>
        public override bool GetStepOnField(int x, int y, bool[,] field)
        {
            bool eatingPiece = false;

            if (Math.Abs(PositionX - x) + Math.Abs(PositionY - y) == 3)
            {
                if (field[x, y] == false)
                    eatingPiece = true;
                PositionX = x;
                PositionY = y;
            }
            else
                throw new Exception("Wrong move!");


            return eatingPiece;
        }

        public override string ToString()
        {
            return ($"Color: {Color} \n  Position X: {PositionX.ToString()} \n Position Y: {PositionY.ToString()} \n Being on the Field: {BeingOnTheField.ToString()} \n");
        }

        public override bool Equals(object obj) => obj is Knight knight && Name == knight.Name && Color == knight.Color && PositionX == knight.PositionX && PositionY == knight.PositionY;

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

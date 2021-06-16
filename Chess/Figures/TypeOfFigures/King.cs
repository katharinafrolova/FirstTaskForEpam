﻿using System;
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

        public King()
        { }
        public override bool GetStepOnField(int x, int y, bool[,] field)
        {
            bool eatingPiece = false;

            if (Math.Abs(PositionX - x) == 1 && Math.Abs(PositionY - y) == 1 || (PositionX - x == 1 && PositionY - y == 0) || (PositionX - x == 0 && PositionY - y == 1))
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

        public override bool Equals(object obj) => obj is King king && Name == king.Name && Color == king.Color && PositionX == king.PositionX && PositionY == king.PositionY ;

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

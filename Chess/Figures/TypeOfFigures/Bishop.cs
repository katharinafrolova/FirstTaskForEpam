﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures.TypeOfFigures
{
    public class Bishop: Figure
    {
        public Bishop(string color, int positionX, int positionY, bool beingOnTheField)
        {
            Name = "Bishop";
            Color = color;
            PositionX = positionX;
            PositionY = positionY;
            BeingOnTheField = beingOnTheField;
        }
        /// <summary>
        /// A Bishop move that is checked for the correct move if the pawn
        /// </summary>
        /// <param name="x"> Finish coordinat x</param>
        /// <param name="y"> Finish coordinat y</param>
        /// <param name="field"> Map for piace with bool value (true - free; false = not free)</param>
        /// <returns> 
        /// If the place that the Bishop moved to was occupied (Rook is eating another piace) - true; 
        /// If the place that the Bishop moved to wasn't occupied (Rook isn't eating another piace) - false; 
        /// </returns>
        public override bool GetStepOnField(int x, int y, bool[,] field)
        {
            bool eatingPiece = false;

            if (Math.Abs(PositionX - x) == Math.Abs(PositionY - y))
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

        /// <summary>
        /// Function for forbidding the Bishop to walk through the pieces
        /// </summary>
        /// <param name="x"> Finish coordinat x</param>
        /// <param name="y"> Finish coordinat y</param>
        /// <param name="field"> Field for piace with bool value (true - free; false = not free)</param>
        /// <returns> 
        /// If the another piace isn't on the path - true; 
        /// If the another piace is on the path - false; 
        /// </returns>
        public bool ChekingFreeSquaries(int x, int y, bool[,] field)
        {
            bool result = true;
            int i = 1;
            int j = 1;
            if(Math.Abs(PositionX - x) > 1 && Math.Abs(PositionY - y) > 1)
            {
                if (PositionX > x)
                    i = -1;
                if (PositionY > y)
                    j = -1;
                while (PositionX + i != x)
                {
                    if(field[PositionX + i, PositionY + i] == false)
                    {
                        result = false;
                        break;
                    }
                    if (PositionX > x)
                        i--;
                    else
                        i++;
                    if (PositionY > y)
                        j--;
                    else
                        j++;
                }
            }

            return result;
        }

        public override string ToString()
        {
            return ($"Color: {Color} \n  Position X: {PositionX.ToString()} \n Position Y: {PositionY.ToString()} \n Being on the Field: {BeingOnTheField.ToString()} \n");
        }

        public override bool Equals(object obj) => obj is Bishop bishop && Name == bishop.Name && Color == bishop.Color && PositionX == bishop.PositionX && PositionY == bishop.PositionY;

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

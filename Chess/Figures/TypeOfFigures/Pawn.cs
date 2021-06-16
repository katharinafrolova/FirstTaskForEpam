﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures.TypeOfFigures
{
    public class Pawn: Figure
    {
        bool FirstStap { get; set; }

        public Pawn(string color, int positionX, int positionY, bool beingOnTheField, bool firstStap)
        {
            Name = "Pawn";
            FirstStap = firstStap;
            Color = color;
            PositionX = positionX;
            PositionY = positionY;
            BeingOnTheField = beingOnTheField;
        }



        /// <summary>
        /// A pawn move that is checked for the correct move if the pawn
        /// </summary>
        /// <param name="x"> Finish coordinat x</param>
        /// <param name="y"> Finish coordinat y</param>
        /// <param name="field"> Field for piace with bool value (true - free; false = not free)</param>
        /// <returns> 
        /// If the place that the pawn moved to was occupied (pawn is eating another piace) - true; 
        /// If the place that the pawn moved to wasn't occupied (pawn isn't eating another piace) - false; 
        /// </returns>
        public override bool GetStepOnField(int x, int y, bool[,] field)
        {
            bool eatingPiece = false;
            if (FirstStap == true && PositionX - x == 0 
                    && ((PositionY - y == 2 && Color == "black") 
                    || (PositionY - y == -2 && Color == "white") 
                    || (PositionY - y == 1 && Color == "black") 
                    || (PositionY - y == -1 && Color == "white")))
            {
                if (ChekingFreeSquaries(x, y, field))
                    PositionY = y;
                else
                    throw new Exception("This piace doesn't walk through the others!");
            }
            else if (FirstStap == false && PositionX - x == 0 && ((PositionY - y == 1 && Color == "black") 
                                                                  || (PositionY - y == -1 && Color == "white")))
                 {
                     if (ChekingFreeSquaries(x, y, field))
                         PositionY = y;
                     else
                         throw new Exception("This piace doesn't take others on straight!");
                 }
            else if (Math.Abs(PositionX - x) == 1 && field[x, y] == false && ((PositionY - y == -1 && Color == "black") 
                                 || (PositionY - y == 1 && Color == "white")) )
                 {
                     eatingPiece = true;
                     PositionX = x;
                     PositionY = y;
                 }
            else
                throw new Exception("Wrong move!");

            return eatingPiece;
        }

        /// <summary>
        /// Function for forbidding the pawn to walk through the pieces
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
            if (Math.Abs(PositionY - y) >= 1)
            {
                if (PositionY > y)
                    i = -1;
                while (PositionY + i != y)
                {
                    if (field[PositionX, PositionY + i] == false)
                    {
                        result = false;
                        break;
                    }
                    if (PositionY > y)
                        i--;
                    else if (PositionY < y)
                        i++;
                }
                if (field[PositionX, y] == false)
                    result = false;

            }
            return result;
        }


        public override string ToString()
        {
            return ($"Color: {Color} \n  Position X: {PositionX.ToString()} \n Position Y: {PositionY.ToString()} \n Being on the Field: {BeingOnTheField.ToString()} \n");
        }

        public override bool Equals(object obj) => obj is Pawn pawn && Name == pawn.Name && Color == pawn.Color && PositionX == pawn.PositionX && PositionY == pawn.PositionY && BeingOnTheField == pawn.BeingOnTheField;

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

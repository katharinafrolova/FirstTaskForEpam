using Chess.Figures;
using Chess.Figures.TypeOfFigures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Game
{
    public class Game
    {
        Figure[,] field;
        bool[,] map;
        string winner;


        public Game()
        {
            winner = null;
            field = new Figure[8,8];
            map = new bool[8, 8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    field[i, j] = null;
                    map[i, j] = true;
                }
                    
            PlaceЕhePiecesOnTheField("white");
            PlaceЕhePiecesOnTheField("black");
        }

        public void PlaceЕhePiecesOnTheField(string color)
        {
            int firstPositionX = 0;
            int firstPositionY = 0;
            if (color == "white")
                firstPositionY = 7;

            field[firstPositionX, firstPositionY] = new Rook(color, firstPositionX, firstPositionY, true);
            field[firstPositionX + 7, firstPositionY] = new Rook(color, firstPositionX + 7, firstPositionY, true);
            map[firstPositionX, firstPositionY] = false;
            map[firstPositionX + 7, firstPositionY] = false;

            field[firstPositionX + 1, firstPositionY] = new Knight(color, firstPositionX + 1, firstPositionY, true);
            field[firstPositionX + 6, firstPositionY] = new Knight(color, firstPositionX + 6, firstPositionY, true);
            map[firstPositionX + 1, firstPositionY] = false;
            map[firstPositionX + 6, firstPositionY] = false;


            field[firstPositionX + 2, firstPositionY] = new Bishop(color, firstPositionX + 2, firstPositionY, true);
            field[firstPositionX + 5, firstPositionY] = new Bishop(color, firstPositionX + 5, firstPositionY, true);
            map[firstPositionX + 2, firstPositionY] = false;
            map[firstPositionX + 5, firstPositionY] = false;

            field[firstPositionX + 3, firstPositionY] = new Queen(color, firstPositionX + 3, firstPositionY, true);
            field[firstPositionX + 4, firstPositionY] = new Queen(color, firstPositionX + 4, firstPositionY, true);
            map[firstPositionX + 3, firstPositionY] = false;
            map[firstPositionX + 4, firstPositionY] = false;


            if (color == "white")
                firstPositionY = 6;
            else
                firstPositionY = 1;
            for (int i = 0; i < 8; i++)
            {
                field[firstPositionX + i, firstPositionY] = new Pawn(color, firstPositionX + i, firstPositionY, true, true);
                map[firstPositionX + i, firstPositionY] = false;
            }

        }

        public void ProcessOfGame()
        {
           
            //Player player1 = new Player("white", ");
            //Player player2 = new Player("black");

        }

        public bool CheckForAnEndlessGame()
        {
            bool result = true;
            
            return result;
        }

        public bool StepOfSomePlayer(Player player, int StartX, int StartY, int FinishX, int FinishY)
        {
            bool endOfGame = false;
            try
            {
                if(player.ColorOfPlayersPiace != field[StartX, StartY].Color )
                    throw new Exception("This piece isn't your!");

                if(field[FinishX, FinishY] != null)
                {
                    if (field[FinishX, FinishY].Name == "King")
                    {
                        endOfGame = true;
                        winner = player.Name;
                    }
                        
                    EatingSomePiece(StartX, StartY, FinishX, FinishY);
                    player.AddStepInHistory(FinishX, FinishY, field[FinishX, FinishY].Name);
                }
                else
                {
                    field[StartX, StartY].GetStepOnField(FinishX, FinishY, map);
                    player.AddStepInHistory(FinishX, FinishY, field[FinishX, FinishY].Name);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return endOfGame;
        }


       public void EatingSomePiece(int StartX, int StartY, int FinishX, int FinishY)
       {
            
            field[StartX, StartY].GetStepOnField(FinishX, FinishY, map);
            field[FinishX, FinishY] = field[StartX, StartY];
            field[StartX, StartY] = null;
       }

    }
}

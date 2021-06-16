using Chess.Figures;
using Chess.Figures.TypeOfFigures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Game
{
    public class Game
    {
        public Figure[,] Field { get; set; }
        public bool[,] Map { get; set; }
        public string Winner { get; set; }


        public Game()
        {
            Winner = null;
            Field = new Figure[8,8];
            Map = new bool[8, 8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    Field[i, j] = null;
                    Map[i, j] = true;
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

            Field[firstPositionX, firstPositionY] = new Rook(color, firstPositionX, firstPositionY, true);
            Field[firstPositionX + 7, firstPositionY] = new Rook(color, firstPositionX + 7, firstPositionY, true);
            Map[firstPositionX, firstPositionY] = false;
            Map[firstPositionX + 7, firstPositionY] = false;

            Field[firstPositionX + 1, firstPositionY] = new Knight(color, firstPositionX + 1, firstPositionY, true);
            Field[firstPositionX + 6, firstPositionY] = new Knight(color, firstPositionX + 6, firstPositionY, true);
            Map[firstPositionX + 1, firstPositionY] = false;
            Map[firstPositionX + 6, firstPositionY] = false;


            Field[firstPositionX + 2, firstPositionY] = new Bishop(color, firstPositionX + 2, firstPositionY, true);
            Field[firstPositionX + 5, firstPositionY] = new Bishop(color, firstPositionX + 5, firstPositionY, true);
            Map[firstPositionX + 2, firstPositionY] = false;
            Map[firstPositionX + 5, firstPositionY] = false;

            Field[firstPositionX + 3, firstPositionY] = new Queen(color, firstPositionX + 3, firstPositionY, true);
            Field[firstPositionX + 4, firstPositionY] = new Queen(color, firstPositionX + 4, firstPositionY, true);
            Map[firstPositionX + 3, firstPositionY] = false;
            Map[firstPositionX + 4, firstPositionY] = false;


            if (color == "white")
                firstPositionY = 6;
            else
                firstPositionY = 1;
            for (int i = 0; i < 8; i++)
            {
                Field[firstPositionX + i, firstPositionY] = new Pawn(color, firstPositionX + i, firstPositionY, true, true);
                Map[firstPositionX + i, firstPositionY] = false;
            }

        }

        public void ProcessOfGame()
        {
           
            //Player player1 = new Player("white", ");
            //Player player2 = new Player("black");

        }

        public bool CheckForAnEndlessGame()
        {
            bool endlessGame = true;

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (Field[i, j].Name != null || Field[i, j].Name != "King")
                        endlessGame = false;
                }

            return endlessGame;
        }

        public bool StepOfSomePlayer(Player player, int StartX, int StartY, int FinishX, int FinishY)
        {
            bool endOfGame = false;
            try
            {
                if(player.ColorOfPlayersPiace != Field[StartX, StartY].Color )
                    throw new Exception("This piece isn't your!");

                if(Field[FinishX, FinishY] != null)
                {
                    if (Field[FinishX, FinishY].Name == "King")
                    {
                        endOfGame = true;
                        Winner = player.Name;
                    }
                        
                    EatingSomePiece(StartX, StartY, FinishX, FinishY);
                    player.AddStepInHistory(FinishX, FinishY, Field[FinishX, FinishY].Name);
                }
                else
                {
                    Field[StartX, StartY].GetStepOnField(FinishX, FinishY, Map);
                    player.AddStepInHistory(FinishX, FinishY, Field[FinishX, FinishY].Name);
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
            
            Field[StartX, StartY].GetStepOnField(FinishX, FinishY, Map);
            Field[FinishX, FinishY] = Field[StartX, StartY];
            Field[StartX, StartY] = null;
       }

    }
}

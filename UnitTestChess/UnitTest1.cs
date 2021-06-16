using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Chess;
using Chess.Figures;
using Chess.Game;
using Chess.Figures.TypeOfFigures;

namespace UnitTestChess
{
    [TestClass]
    public class ChessTest
    {
        //private readonly King _kingService;

        //public ChessTest()
        //{
        //    _kingService = new King();
        //}

        [DataTestMethod, Description("Take uncorrect step for king. Throw argument exception")]
        [DataRow(0, 0)]
        [DataRow(1, 7)]
        [DataRow(5, 5)]
        public void GetStepOnField_TakeUncorrectStepForKing_ThrowsArgumentException(int coord1, int coord2)
        {
            bool[,] field = {  {true, true, true, true, true, true, true, true},
                               {true, true, false, false, true, true, true, true },
                               {true, true, true, false, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
            };
            King king = new King("White", 2, 3, true);
            Assert.ThrowsException<Exception>(() => king.GetStepOnField(coord1, coord2, field));
        }

        [DataTestMethod, Description("King takes another piace. Positive test result")]
        [DataRow(2, 2)]
        [DataRow(1, 3)]
        [DataRow(3, 2)]
        public void GetStepOnField_KingTakeAnotherPiace_PositiveTestResult(int coord1, int coord2)
        {
            bool[,] field = {  {true, true, true, true, true, true, true, true},
                               {true, true, true, false, true, true, true, true },
                               {true, true, false, false, true, true, true, true },
                               {true, true, false, false, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
            };
            King king = new King("White", 2, 3, true);
            Assert.IsTrue(king.GetStepOnField(coord1, coord2, field) == true);
            
        }



       

        [DataTestMethod, Description("Take uncorrect step for Queen. Throw argument exception")]
        [DataRow(2, 2)]
        [DataRow(7, 7)]
        [DataRow(5, 6)]
        public void GetStepOnField_TakeUncorrectStepForQueen_ThrowsArgumentException(int coord1, int coord2)
        {
            bool[,] field = {  {true, true, true, true, true, true, true, true},
                               {true, true, false, false, true, true, true, true },
                               {true, true, true, false, true, true, true, true },
                               {true, true, false, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, false, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
            };
            Queen queen = new Queen("White", 3, 5, true);
            Assert.ThrowsException<Exception>(() => queen.GetStepOnField(coord1, coord2, field));
        }

        [DataTestMethod, Description("Take step for Queen through the others . Throw argument exception")]
        [DataRow(0, 3)]
        [DataRow(2, 0)]
        public void GetStepOnField_TakeStepForQueenThroughTheOthers_ThrowsArgumentException(int coord1, int coord2)
        {
            bool[,] field = {  {true, true, true, true, true, true, true, true},
                               {true, true, false, true, true, true, true, true },
                               {true, true, true, false, true, true, true, true },
                               {true, false, false, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, false, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
            };
            Queen queen = new Queen("White", 3, 5, true);
            Assert.ThrowsException<Exception>(() => queen.GetStepOnField(coord1, coord2, field));
        }


        [DataTestMethod, Description("Queen takes another piace. Positive test result")]
        [DataRow(0, 3)]
        [DataRow(4, 1)]
        [DataRow(5, 6)]
        public void GetStepOnField_QueenTakeAnotherPiace_PositiveTestResult(int coord1, int coord2)
        {
            bool[,] field = {  {true, true, true, false, true, true, true, true},
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, false, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, false, true, true, true, true, true, true },
                               {true, true, true, true, true, true, false, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
            };
            Queen queen = new Queen("White", 2, 3, true);
            Assert.IsTrue(queen.GetStepOnField(coord1, coord2, field) == true);

        }



        [DataTestMethod, Description("Take uncorrect step for Rook. Throw argument exception")]
        [DataRow(2, 4)]
        [DataRow(7, 7)]
        [DataRow(4, 6)]
        public void GetStepOnField_TakeUncorrectStepForRook_ThrowsArgumentException(int coord1, int coord2)
        {
            bool[,] field = {  {true, true, true, true, true, true, true, true},
                               {true, true, false, false, true, true, true, true },
                               {true, true, true, false, true, true, true, true },
                               {true, true, false, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, false, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
            };
            Rook rook = new Rook("White", 3, 5, true);
            Assert.ThrowsException<Exception>(() => rook.GetStepOnField(coord1, coord2, field));
        }





        [DataTestMethod, Description("Take step for Rook through the others. Throw argument exception")]
        [DataRow(3, 1)]
        [DataRow(5, 0)]
        [DataRow(5, 7)]
        public void GetStepOnField_TakeStepForRookThroughTheOthers_ThrowsArgumentException(int coord1, int coord2)
        {
            bool[,] field = {  {true, true, true, true, true, true, true, true},
                               {true, true, false, true, true, true, true, true },
                               {true, true, true, false, true, true, true, true },
                               {true, true, false, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, false, false, true, true, false, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
            };
            Rook rook = new Rook("White", 3, 5, true);
            Assert.ThrowsException<Exception>(() => rook.GetStepOnField(coord1, coord2, field));
        }


        [DataTestMethod, Description("Rook takes another piace. Positive test result")]
        [DataRow(0, 3)]
        [DataRow(2, 0)]
        [DataRow(3, 3)]
        public void GetStepOnField_RookTakeAnotherPiace_PositiveTestResult(int coord1, int coord2)
        {
            bool[,] field = {  {true, true, true, false, true, true, true, true},
                               {true, true, true, true, true, true, true, true },
                               {false, true, true, false, true, true, true, true },
                               {true, true, true, false, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
            };
            Rook rook = new Rook("White", 2, 3, true);
            Assert.IsTrue(rook.GetStepOnField(coord1, coord2, field) == true);

        }


        [DataTestMethod, Description("Take uncorrect step for Knight. Throw argument exception")]
        [DataRow(3, 4)]
        [DataRow(3, 3)]
        [DataRow(2, 4)]
        [DataRow(0, 0)]
        public void GetStepOnField_TakeUncorrectStepForKnight_ThrowsArgumentException(int coord1, int coord2)
        {
            bool[,] field = {  {true, true, true, true, true, true, true, true},
                               {true, true, false, false, true, true, true, true },
                               {true, true, true, false, true, true, true, true },
                               {true, true, false, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, false, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
            };
            Knight knight = new Knight("White", 3, 5, true);
            Assert.ThrowsException<Exception>(() => knight.GetStepOnField(coord1, coord2, field));
        }


        [DataTestMethod, Description("Knight takes another piace. Positive test result")]
        [DataRow(0, 2)]
        [DataRow(4, 4)]
        [DataRow(4, 2)]
        public void GetStepOnField_KnightTakeAnotherPiace_PositiveTestResult(int coord1, int coord2)
        {
            bool[,] field = {  {true, true, false, true, true, true, true, true},
                               {true, true, true, true, true, true, true, true },
                               {false, true, true, false, true, true, true, true },
                               {true, true, true, false, true, true, true, true },
                               {true, true, false, true, false, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
            };
            Knight knight = new Knight("White", 2, 3, true);
            Assert.IsTrue(knight.GetStepOnField(coord1, coord2, field) == true);

        }


        [DataTestMethod, Description("Take uncorrect step for Bishop. Throw argument exception")]
        [DataRow(3, 4)]
        [DataRow(3, 6)]
        [DataRow(2, 5)]
        [DataRow(4, 5)]
        public void GetStepOnField_TakeUncorrectStepForBishop_ThrowsArgumentException(int coord1, int coord2)
        {
            bool[,] field = {  {true, true, true, true, true, true, true, true},
                               {true, true, false, false, true, true, true, true },
                               {true, true, true, false, true, true, true, true },
                               {true, true, false, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, false, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
            };
            Bishop bishop = new Bishop("White", 3, 5, true);
            Assert.ThrowsException<Exception>(() => bishop.GetStepOnField(coord1, coord2, field));
        }

        [DataTestMethod, Description("Bishop takes another piace. Positive test result")]
        [DataRow(1, 2)]
        [DataRow(3, 4)]
        [DataRow(3, 2)]
        public void GetStepOnField_BishopTakeAnotherPiace_PositiveTestResult(int coord1, int coord2)
        {
            bool[,] field = {  {true, true, true, true, true, true, true, true},
                               {true, true, false, true, true, true, true, true },
                               {false, true, true, false, true, true, true, true },
                               {true, true, false, true, false, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
            };
            Bishop bishop = new Bishop("White", 2, 3, true);
            Assert.IsTrue(bishop.GetStepOnField(coord1, coord2, field) == true);

        }

        [DataTestMethod, Description("Take step for Bishop through the others. Throw argument exception")]
        [DataRow(7, 1)]
        [DataRow(0, 2)]
        [DataRow(5, 7)]
        public void GetStepOnField_TakeStepForBishopThroughTheOthers_ThrowsArgumentException(int coord1, int coord2)
        {
            bool[,] field = {  {true, true, true, true, true, true, true, true},
                               {true, true, true, false, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, false, true, true },
                               {true, true, true, true, true, true, false, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, false, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
            };
            Bishop bishop = new Bishop("White", 3, 5, true);
            Assert.ThrowsException<Exception>(() => bishop.GetStepOnField(coord1, coord2, field));
        }


        [DataTestMethod, Description("Take uncorrect first step for Pawn. Throw argument exception")]
        [DataRow(3, 6)]
        [DataRow(4, 5)]
        [DataRow(4, 4)]
        [DataRow(3, 3)]

        public void GetStepOnField_TakeUncorrectFirstStepForPawn_ThrowsArgumentException(int coord1, int coord2)
        {
            bool[,] field = {  {true, true, true, true, true, true, true, true},
                               {true, true, false, false, true, true, true, true },
                               {true, true, true, false, true, true, true, true },
                               {true, true, false, false, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, false, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
            };
            Pawn pawn = new Pawn("White", 3, 5, true, true);
            Assert.ThrowsException<Exception>(() => pawn.GetStepOnField(coord1, coord2, field));
        }

        [DataTestMethod, Description("Take step for Pawn through the others. Throw argument exception")]
        [DataRow(3, 3)]
        
        public void GetStepOnField_TakeStepForPawnThroughTheOthers_ThrowsArgumentException(int coord1, int coord2)
        {
            bool[,] field = {  {true, true, true, true, true, true, true, true},
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, false, false, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
            };
            Bishop bishop = new Bishop("White", 3, 5, true);
            Assert.ThrowsException<Exception>(() => bishop.GetStepOnField(coord1, coord2, field));
        }


        [DataTestMethod, Description("Pawn takes another piace. Positive test result")]
        [DataRow(1, 4)]
        [DataRow(3, 4)]
        public void GetStepOnField_PawnTakeAnotherPiace_PositiveTestResult(int coord1, int coord2)
        {
            bool[,] field = {  {true, true, true, true, true, true, true, true},
                               {true, true, true, true, false, true, true, true },
                               {true, true, true, false, true, true, true, true },
                               {true, true, true, true, false, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
                               {true, true, true, true, true, true, true, true },
            };
            Pawn pawn = new Pawn("black", 2, 3, true, false);
            Assert.IsTrue(pawn.GetStepOnField(coord1, coord2, field) == true);

        }



    }

    [TestClass]
    public class GameTest
    {
        [DataTestMethod, Description("Take not your piace. Throw argument exception")]
        [DataRow(1, 6, 1, 5)]
        [DataRow(6, 6, 6, 4)]
        [DataRow(7, 1, 5, 0)]
        public void StepOfSomePlayer_TakeNotYourPiace_ThrowsArgumentException(int startCoord1, int startCoord2, int endCoord1, int endCoord2)
        {
            Game game = new Game();
            Player player = new Player("black", "Kate");
            Assert.ThrowsException<Exception>(() => game.StepOfSomePlayer(player, startCoord1, startCoord2, endCoord1, endCoord2));
        }

        [DataTestMethod, Description("End of game. Positive test result")]
        [DataRow(2, 4, 2, 3)]
        
        public void StepOfSomePlayer_EndOfGame_PositiveTestResult(int startCoord1, int startCoord2, int endCoord1, int endCoord2)
        {
            Game game = new Game();
            Player player1 = new Player("black", "Kate");
            Player player2 = new Player("white", "Not Kate");
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    game.Field[i, j] = null;
                    
                }
            game.Field[2, 3] = new King("white", 2, 3, true);
            game.Field[2, 4] = new Rook("black", 2, 4, true);

            Assert.IsTrue(game.StepOfSomePlayer(player1, startCoord1, startCoord2, endCoord1, endCoord2) == true);
        }

        [DataTestMethod, Description("Check for endless game. Positive test result")]
        public void CheckForAnEndlessGame_EndOfEndlessGame_PositiveTestResult()
        {
            Game game = new Game();
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    game.Field[i, j] = null;
            game.Field[2, 3] = new King("white", 2, 3, true);
            game.Field[4, 5] = new King("black", 4, 5, true);
            Assert.IsTrue(game.CheckForAnEndlessGame() == true);
        }

    }

}




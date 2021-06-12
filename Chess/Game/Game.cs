using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Game
{
    public class Game
    {
        bool[,] field;
        string Player1 { get; set; }
        string Player2 { get; set; }

        public Game(string player1, string player2)
        {
            Player1 = player1;
            Player2 = player2;
            field = new bool[8,8];
        }





    }
}

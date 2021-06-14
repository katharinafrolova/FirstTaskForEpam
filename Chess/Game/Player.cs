using Chess.Figures;
using Chess.Figures.TypeOfFigures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Game
{
    public class Player
    {
        public string Name { get; set; }
        public string ColorOfPlayersPiace { get; set; }
        List<string> AllStep { get; set; } 

        public Player(string color, string name)
        {
            Name = name;
            ColorOfPlayersPiace = color;
            AllStep = new List<string>();        }

        public void AddStepInHistory(int x, int y, string name)
        {
            if(name == null)
                AllStep.Add("x: " + x.ToString() + "  y: " + y.ToString());
            else
                AllStep.Add("x: " + x.ToString() + "  y: " + y.ToString() + "  eating peace: " + name);
        }

    }
}

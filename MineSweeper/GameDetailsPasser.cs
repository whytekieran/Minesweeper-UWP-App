using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    //Simple class used to pass information from Game.xaml.cs to the SetHighScore.xaml.cs if the player wins.
    class GameDetailsPasser
    {
        public int gridSize { get; set; }
        public int score { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using MineSweeper.Data;

namespace MineSweeper.Models
{
    //Class is responsible for speaking to the data class (Score) and the data service which holds database communication
    class ScoreOrganizer
    {
        public List<ScoreGeneric> scores { get; set; }

        //Overloaded constructor
        public ScoreOrganizer()
        { }

        //Contructor gets list of scores from the data service depending on user choice made.
        public ScoreOrganizer(int choosenTable)
        {
            DataService.choosenTable = choosenTable;
            scores = DataService.GetScores();
        }

        //Add to scores list, needed by view model and add to the database itself
        public void Add(string user, string difficulty, int score, int gridSize)
        {
            DataService.Insert(user, difficulty, score, gridSize);
        }
    }
}

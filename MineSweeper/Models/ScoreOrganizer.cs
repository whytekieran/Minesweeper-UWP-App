using System;
using System.Collections.Generic;
using System.Linq;
using MineSweeper.Data;
using MineSweeper.ViewModels;
using System.Threading.Tasks;

namespace MineSweeper.Models
{
    //Class is responsible for speaking to the data class (Score) and the data service which holds database communication
    class ScoreOrganizer
    {
        public List<ScoreGeneric> scores { get; set; }

        //Overloaded constructors for different tasks
        public ScoreOrganizer()//adding a score
        { }

        //Contructor gets list of scores from the data service depending on user choice made.
        public ScoreOrganizer(int choosenTable)//getting a score - offline
        {
            DataService.choosenTable = choosenTable;
            scores = DataService.GetScores();
        }
    
        //Add to the database by passing the needed variables from score organizer view model to the data service
        //the data service will then add the score to the correct table
        public void Add(string user, string difficulty, int score, int gridSize)
        {
            DataService.Insert(user, difficulty, score, gridSize);
        }
    }
}

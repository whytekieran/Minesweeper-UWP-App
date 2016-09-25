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

        //Contructor gets list of scores from the data service depending on user choice made.
        public ScoreOrganizer(int choosenTable)
        {
            DataService.choosenTable = choosenTable;
            scores = DataService.GetScores();
        }

        //Add to scores list, needed by view model and add to the database itself
        public void Add(ScoreGeneric score)
        {
            if (!scores.Contains(score))
            {
                scores.Add(score);
                DataService.Insert(score);
            }
        }

        //commented code below may not be needed for this program
        /*
        //delete from scores list, needed by view model and delete from the database itself
        public void Delete(Score score)
        {
            if (scores.Contains(score))
            {
                scores.Remove(score);
                DataService.Delete(score);
            }
        }

        public void Update(Score score)
        {
            if (scores.Contains(score))
            {
                //not sure if this feature is nessesary yet, may not add it into the project.
                //scores.Up(score);
                DataService.Update(score);
            }
        }*/
    }
}

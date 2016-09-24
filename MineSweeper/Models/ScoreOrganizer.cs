using System;
using System.Collections.Generic;
using System.Linq;
using MineSweeper.Data;

namespace MineSweeper.Models
{
    class ScoreOrganizer
    {
        public List<Score> scores { get; set; }
        public String Name { get; set; }

        public ScoreOrganizer(int choosenTable)
        {
            DataService.choosenTable = choosenTable;
            scores = DataService.GetScores();
        }

        public void Add(Score score)
        {
            if (!scores.Contains(score))
            {
                scores.Add(score);
                DataService.Insert(score);
            }
        }

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
        }
    }
}

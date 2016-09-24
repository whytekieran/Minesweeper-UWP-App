using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Data
{
    public class Score
    {
        private String username;
        private int userScore;

        public String Username
        {
            get { return username; }
            set { username = value; }
        }

        public int UserScore
        {
            get { return userScore; }
            set { userScore = value; }
        }
    }

    public class DataService
    {
        public static String gameDifficulty;

        //Fake score data for now until database or cloud service is added.
        public static List<Score> GetScores()
        {
            Debug.WriteLine("GET for user scores.");

            if(gameDifficulty == "Easy")
            {
                return new List<Score>()
                {    
                    //Some fake data good enough for now in local database or cloud service can go here 
                    new Score() { Username="eChris Cole", UserScore=10 },
                    new Score() { Username="eKelly Kale", UserScore=32 },
                    new Score() { Username="eDylan Durbin", UserScore=18 }
                };
            }
            else if(gameDifficulty == "Medium")
            {
                return new List<Score>()
                {
                    //Some fake data good enough for now in local database or cloud service can go here 
                    new Score() { Username="mChris Cole", UserScore=10 },
                    new Score() { Username="mKelly Kale", UserScore=32 },
                    new Score() { Username="mDylan Durbin", UserScore=18 }
                };
            }
            else
            {
                return new List<Score>()
                {
                    //Some fake data good enough for now in local database or cloud service can go here 
                    new Score() { Username="hChris Cole", UserScore=10 },
                    new Score() { Username="hKelly Kale", UserScore=32 },
                    new Score() { Username="hDylan Durbin", UserScore=18 }
                };
            }
        }

        //all method below will write to some sort of database in the future, either local or on a cloud service
        public static void Insert(Score score)
        {
            Debug.WriteLine("INSERT score with username " + score.Username);
        }

        public static void Delete(Score score)
        {
            Debug.WriteLine("Delete score with username " + score.Username);
        }

        public static void Update(Score score)
        {
            Debug.WriteLine("Update score with username " + score.Username);
        }
    }
}


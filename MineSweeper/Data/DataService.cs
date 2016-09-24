using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Data
{
    //Score class acts as a basic model to hold score objects
    public class Score
    {
        //Each high score has a username and score
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

    //The dataservice class is responsible for communicating with the database, getting and inserting scores for storage
    public class DataService
    {
        //This variable is set by the view model so we know which table to read from
        public static int choosenTable;

        //Fake score data for now until database or cloud service is added.
        public static List<Score> GetScores()
        {
            //Perfrom a switch depending on user choice made to select a certain high score table
            switch(choosenTable)
            {
                case 0:
                    return new List<Score>()
                    {    
                        //Some fake data good enough for now in local database or cloud service can go here 
                        new Score() { Username="0Chris Cole", UserScore=10 },
                        new Score() { Username="0Kelly Kale", UserScore=32 },
                        new Score() { Username="0Dylan Durbin", UserScore=18 }
                    };
                case 1:
                    return new List<Score>()
                    {    
                        //Some fake data good enough for now in local database or cloud service can go here 
                        new Score() { Username="1Chris Cole", UserScore=10 },
                        new Score() { Username="1Kelly Kale", UserScore=32 },
                        new Score() { Username="1Dylan Durbin", UserScore=18 }
                    };
                case 2:
                    return new List<Score>()
                    {    
                        //Some fake data good enough for now in local database or cloud service can go here 
                        new Score() { Username="2Chris Cole", UserScore=10 },
                        new Score() { Username="2Kelly Kale", UserScore=32 },
                        new Score() { Username="2Dylan Durbin", UserScore=18 }
                    };
                case 3:
                    return new List<Score>()
                    {    
                        //Some fake data good enough for now in local database or cloud service can go here 
                        new Score() { Username="3Chris Cole", UserScore=10 },
                        new Score() { Username="3Kelly Kale", UserScore=32 },
                        new Score() { Username="3Dylan Durbin", UserScore=18 }
                    };
                case 4:
                    return new List<Score>()
                    {    
                        //Some fake data good enough for now in local database or cloud service can go here 
                        new Score() { Username="4Chris Cole", UserScore=10 },
                        new Score() { Username="4Kelly Kale", UserScore=32 },
                        new Score() { Username="4Dylan Durbin", UserScore=18 }
                    };
                case 5:
                    return new List<Score>()
                    {    
                        //Some fake data good enough for now in local database or cloud service can go here 
                        new Score() { Username="5Chris Cole", UserScore=10 },
                        new Score() { Username="5Kelly Kale", UserScore=32 },
                        new Score() { Username="5Dylan Durbin", UserScore=18 }
                    };
                case 6:
                    return new List<Score>()
                    {    
                        //Some fake data good enough for now in local database or cloud service can go here 
                        new Score() { Username="6Chris Cole", UserScore=10 },
                        new Score() { Username="6Kelly Kale", UserScore=32 },
                        new Score() { Username="6Dylan Durbin", UserScore=18 }
                    };
                case 7:
                    return new List<Score>()
                    {    
                        //Some fake data good enough for now in local database or cloud service can go here 
                        new Score() { Username="7Chris Cole", UserScore=10 },
                        new Score() { Username="7Kelly Kale", UserScore=32 },
                        new Score() { Username="7Dylan Durbin", UserScore=18 }
                    };
                case 8:
                    return new List<Score>()
                    {    
                        //Some fake data good enough for now in local database or cloud service can go here 
                        new Score() { Username="8Chris Cole", UserScore=10 },
                        new Score() { Username="8Kelly Kale", UserScore=32 },
                        new Score() { Username="8Dylan Durbin", UserScore=18 }
                    };
                default:
                    return new List<Score>()
                    {    
                        //Some fake data good enough for now in local database or cloud service can go here 
                        new Score() { Username="Empty", UserScore=0 },
                    };
            }//end switch
        }//end getScores()

        //all methods below will write to some sort of database in the future, either local or on a cloud service
        public static void Insert(Score score)
        {
            Debug.WriteLine("INSERT score with username " + score.Username);
        }

        //Commented code below may not be nessesary for this program
        /*
        public static void Delete(Score score)
        {
            Debug.WriteLine("Delete score with username " + score.Username);
        }

        public static void Update(Score score)
        {
            Debug.WriteLine("Update score with username " + score.Username);
        }*/
    }
}


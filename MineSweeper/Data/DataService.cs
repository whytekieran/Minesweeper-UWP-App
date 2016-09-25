using SQLite.Net;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MineSweeper.Data
{
    //The dataservice class is responsible for communicating with the database, getting and inserting scores for storage
    public class DataService
    {
        public static int choosenTable;         //This variable is set by the view model so we know which table to read from
        private static SQLiteConnection con;           //Connection object for SQLite database
        private static string path;                    //The path of the database in the file system
        private static List<ScoreGeneric> results;

        //Fake score data for now until database or cloud service is added.
        public static List<ScoreGeneric> GetScores()
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Minesweeper.sqlite");
            con = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            Debug.WriteLine(path);

            //Perfrom a switch depending on user choice made to select a certain high score table
            switch (choosenTable)
            {
                case 0:
                    con.CreateTable<EScore6>();//creates a table called 'EScore6'
                    results = con.Query<ScoreGeneric>("select * from EScore6").ToList<ScoreGeneric>();
                    break;
                case 1:
                    con.CreateTable<EScore8>();//creates a table called 'EScore8'
                    results = con.Query<ScoreGeneric>("select * from EScore8").ToList<ScoreGeneric>();
                    break;
                case 2:
                    con.CreateTable<EScore10>();//creates a table called 'EScore10'
                    results = con.Query<ScoreGeneric>("select * from EScore10").ToList<ScoreGeneric>();
                    break;
                case 3:
                    con.CreateTable<MScore6>();//creates a table called 'MScore6'
                    results = con.Query<ScoreGeneric>("select * from MScore6").ToList<ScoreGeneric>();
                    break;
                case 4:
                    con.CreateTable<MScore8>();//creates a table called 'MScore8'
                    results = con.Query<ScoreGeneric>("select * from MScore8").ToList<ScoreGeneric>();
                    break;
                case 5:
                    con.CreateTable<MScore10>();//creates a table called 'MScore10'
                    results = con.Query<ScoreGeneric>("select * from MScore10").ToList<ScoreGeneric>();
                    break;
                case 6:
                    con.CreateTable<HScore6>();//creates a table called 'HScore6'
                    results = con.Query<ScoreGeneric>("select * from HScore6").ToList<ScoreGeneric>();
                    break;
                case 7:
                    con.CreateTable<HScore8>();//creates a table called 'HScore8'
                    results = con.Query<ScoreGeneric>("select * from HScore8").ToList<ScoreGeneric>();
                    break;
                case 8:
                    con.CreateTable<HScore10>();//creates a table called 'HScore10'
                    results = con.Query<ScoreGeneric>("select * from HScore10").ToList<ScoreGeneric>();
                    break;
            }//end switch

            return results;         //return the querys results

        }//end getScores()

        //all methods below will write to some sort of database in the future, either local or on a cloud service
        public static void Insert(ScoreGeneric score)
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


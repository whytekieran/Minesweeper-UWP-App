using MineSweeper.ViewModels;
using Newtonsoft.Json;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;
using Windows.UI.Popups;

namespace MineSweeper.Data
{
    //The dataservice class is responsible for communicating with the database, getting and inserting scores for storage
    public class DataService
    {
        public static int choosenTable;          //This variable is set by the view model so we know which table to read from
        private static SQLiteConnection con;           //Connection object for SQLite database
        private static string path;                    //The path of the database in the file system
        private static List<ScoreGeneric> results;

        //Retrieves data(scores from the database depending on which scores user choose to see)
        public static List<ScoreGeneric> GetScores()
        {
            //Connect to the database in windows local folder, specify the platform being used
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Minesweeper.sqlite");
            con = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            Debug.WriteLine(path);

            //Perfrom a switch depending on user choice made to select a certain high score table
            switch (choosenTable)
            {
                case 0:
                    con.CreateTable<EScore6>();//creates a table called 'EScore6' ..get data highest score first
                    results = con.Query<ScoreGeneric>("select * from EScore6 ORDER BY userscore DESC").ToList<ScoreGeneric>();//get the scores
                    con.Close();//close the connection after scores have been retrieved
                    break;
                case 1:
                    con.CreateTable<EScore8>();//creates a table called 'EScore8'
                    results = con.Query<ScoreGeneric>("select * from EScore8 ORDER BY userscore DESC").ToList<ScoreGeneric>();//get the scores
                    con.Close();//close the connection after scores have been retrieved
                    break;
                case 2:
                    con.CreateTable<EScore10>();//creates a table called 'EScore10'
                    results = con.Query<ScoreGeneric>("select * from EScore10 ORDER BY userscore DESC").ToList<ScoreGeneric>();//get the scores
                    con.Close();//close the connection after scores have been retrieved
                    break;
                case 3:
                    con.CreateTable<MScore6>();//creates a table called 'MScore6'
                    results = con.Query<ScoreGeneric>("select * from MScore6 ORDER BY userscore DESC").ToList<ScoreGeneric>();//get the scores
                    con.Close();//close the connection after scores have been retrieved
                    break;
                case 4:
                    con.CreateTable<MScore8>();//creates a table called 'MScore8'
                    results = con.Query<ScoreGeneric>("select * from MScore8 ORDER BY userscore DESC").ToList<ScoreGeneric>();
                    con.Close();
                    break;
                case 5:
                    con.CreateTable<MScore10>();//creates a table called 'MScore10'
                    results = con.Query<ScoreGeneric>("select * from MScore10 ORDER BY userscore DESC").ToList<ScoreGeneric>();
                    con.Close();
                    break;
                case 6:
                    con.CreateTable<HScore6>();//creates a table called 'HScore6'
                    results = con.Query<ScoreGeneric>("select * from HScore6 ORDER BY userscore DESC").ToList<ScoreGeneric>();
                    con.Close();
                    break;
                case 7:
                    con.CreateTable<HScore8>();//creates a table called 'HScore8'
                    results = con.Query<ScoreGeneric>("select * from HScore8 ORDER BY userscore DESC").ToList<ScoreGeneric>();
                    con.Close();
                    break;
                case 8:
                    con.CreateTable<HScore10>();//creates a table called 'HScore10'
                    results = con.Query<ScoreGeneric>("select * from HScore10 ORDER BY userscore DESC").ToList<ScoreGeneric>();
                    con.Close();
                    break;
            }//end switch

            return results;         //return the querys results

        }//end getScores()

        //Methods below will write to the database (should add async here when posting)
        public static void Insert(string user, string difficulty, int score, int gridSize)
        {
            //Connect to the database in windows local folder, specify the platform being used
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Minesweeper.sqlite");
            con = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            string url;

            //If difficulty setting of the game is easy
            if (difficulty == "Easy")
            {
                //checks which type of easy game was played and inserts high score into the corresponding table
                if (gridSize == 6)
                {
                    // set the url to post to the custom made api
                    url = "http://localhost:8080/Minesweeper/webapi/scores/escore6";
                    con.CreateTable<EScore6>();
                    con.Insert(new EScore6() { username = user, userscore = score });
                    con.Close();
                    postScoreToAPI(user, score, url);//converts data to JSON then sends to the API
                }
                else if (gridSize == 8)
                {
                    url = "http://localhost:8080/Minesweeper/webapi/scores/escore8";
                    con.CreateTable<EScore8>();
                    con.Insert(new EScore8() { username = user, userscore = score });
                    con.Close();
                    postScoreToAPI(user, score, url);
                }
                else if (gridSize == 10)
                {
                    url = "http://localhost:8080/Minesweeper/webapi/scores/escore10";
                    con.CreateTable<EScore10>();
                    con.Insert(new EScore10() { username = user, userscore = score });
                    con.Close();
                    postScoreToAPI(user, score, url);
                }
            }
            else if (difficulty == "Medium")//If difficulty setting of the game is medium
            {
                //checks which type of easy game was played and inserts high score into the corresponding table
                if (gridSize == 6)
                {
                    url = "http://localhost:8080/Minesweeper/webapi/scores/mscore6";
                    con.CreateTable<MScore6>();
                    con.Insert(new MScore6() { username = user, userscore = score });
                    con.Close();
                    postScoreToAPI(user, score, url);
                }
                else if (gridSize == 8)
                {
                    url = "http://localhost:8080/Minesweeper/webapi/scores/mscore8";
                    con.CreateTable<MScore8>();
                    con.Insert(new MScore8() { username = user, userscore = score });
                    con.Close();
                    postScoreToAPI(user, score, url);
                }
                else if (gridSize == 10)
                {
                    url = "http://localhost:8080/Minesweeper/webapi/scores/mscore10";
                    con.CreateTable<MScore10>();
                    con.Insert(new MScore10() { username = user, userscore = score });
                    con.Close();
                    postScoreToAPI(user, score, url);
                }
            }
            else if (difficulty == "Hard")//If difficulty setting of the game is hard
            {
                //checks which type of easy game was played and inserts high score into the corresponding table
                if (gridSize == 6)
                {
                    url = "http://localhost:8080/Minesweeper/webapi/scores/hscore6";
                    con.CreateTable<HScore6>();
                    con.Insert(new HScore6() { username = user, userscore = score });
                    con.Close();
                    postScoreToAPI(user, score, url);
                }
                else if (gridSize == 8)
                {
                    url = "http://localhost:8080/Minesweeper/webapi/scores/hscore8";
                    con.CreateTable<HScore8>();
                    con.Insert(new HScore8() { username = user, userscore = score });
                    con.Close();
                    postScoreToAPI(user, score, url);//post users score to the online api
                }
                else if (gridSize == 10)
                {
                    url = "http://localhost:8080/Minesweeper/webapi/scores/hscore10";
                    con.CreateTable<HScore10>();
                    con.Insert(new HScore10() { username = user, userscore = score });
                    con.Close();
                    postScoreToAPI(user, score, url);
                }
            }
        }

        //Posts high score data to the Apps API (Written using JAX-RS)
        public static async void postScoreToAPI(string user, int score, string url)
        {
            ScoreGeneric sg;
            HttpClient httpClient;

            try
            {
                sg = new ScoreGeneric();
                sg.id = 0;
                sg.username = user;
                sg.userscore = score;
                httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(sg);
                Debug.WriteLine(json.ToString());

                var postContent = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                await httpClient.PostAsync(url, postContent);
            }
            catch(HttpRequestException e)
            {
                MessageDialog msg = new MessageDialog("An issue occured while sending your highscore to online highscores: "+e, "Upload Problem");
            }
        }
    }
}


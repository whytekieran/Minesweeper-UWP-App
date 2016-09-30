using MineSweeper.Data;
using MineSweeper.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MineSweeper
{
    
    public sealed partial class ViewOnlineHighScore : Page
    {
        private IndexPasser passedData; //Index passer to get the selected index from the online high score menu page

        public ViewOnlineHighScore()
        {
            this.InitializeComponent();
        }

        //When the page is navigated to
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Get information from HighScoresMenu stating which highscores the user wants
            passedData = e.Parameter as IndexPasser;

            //request different URL depending on the menu option the user choose
            switch(passedData.index)
            {
                case 0:
                    getRequest("http://localhost:8080/Minesweeper/webapi/scores/escore6");
                    break;
                case 1:
                    getRequest("http://localhost:8080/Minesweeper/webapi/scores/escore8");
                    break;
                case 2:
                    getRequest("http://localhost:8080/Minesweeper/webapi/scores/escore10");
                    break;
                case 3:
                    getRequest("http://localhost:8080/Minesweeper/webapi/scores/mscore6");
                    break;
                case 4:
                    getRequest("http://localhost:8080/Minesweeper/webapi/scores/mscore8");
                    break;
                case 5:
                    getRequest("http://localhost:8080/Minesweeper/webapi/scores/mscore10");
                    break;
                case 6:
                    getRequest("http://localhost:8080/Minesweeper/webapi/scores/hscore6");
                    break;
                case 7:
                    getRequest("http://localhost:8080/Minesweeper/webapi/scores/hscore8");
                    break;
                case 8:
                    getRequest("http://localhost:8080/Minesweeper/webapi/scores/hscore10");
                    break;
            }
        }

         private async void getRequest(string url)
         {
             using (HttpClient client = new HttpClient())
             {
                 using (HttpResponseMessage response = await client.GetAsync(url))
                 {
                     using (HttpContent content = response.Content)
                     {
                         string myContent = await content.ReadAsStringAsync();
                         JsonArray array = JsonArray.Parse(myContent);
                         List<ScoreGeneric> scoreList = getScoreList(array);
                         highscoreOnlineList.ItemsSource = scoreList;
                     }
                 }
             }
         }

         private static List<ScoreGeneric> getScoreList(JsonArray jList)
         {
             List<ScoreGeneric> scores = new List<ScoreGeneric>();
             foreach (var item in jList)
             {
                 var oneScore = item.GetObject();
                 ScoreGeneric score = new ScoreGeneric();
                 foreach (var key in oneScore.Keys)
                 {
                     IJsonValue value;
                     if (!oneScore.TryGetValue(key, out value))
                         continue;
                     switch (key)
                     {
                         case "id":
                             var id = value.GetNumber();
                             score.id = Convert.ToInt32(id);
                             break;
                         case "username":
                             score.username = value.GetString();
                             break;
                         case "userscore":
                             var userscore = value.GetNumber();
                             score.userscore = Convert.ToInt32(userscore);
                             break;
                     } // end switch
                 } // end foreach(var key in oneScore.Keys )
                 scores.Add(score);
             } // end foreach (var item in jList)

             return scores;
         }

        //Click event takes us to the Settings page
        private void settingsClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings));
        }

        //Click event takes us to the Rules page
        private void rulesClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Rules));
        }

        //Click event takes us to the Main page (home)
        private void homeClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}

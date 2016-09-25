using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MineSweeper.ViewModels;
using Windows.UI;
using Windows.Storage;

namespace MineSweeper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SetHighScore : Page
    {
        //Game details passer to retrieve needed data from the previous page and a score organizer view model to
        //communicate with the database
        private GameDetailsPasser gameDetails;
        private ScoreOrganizerViewModel scoreOrganizerVM;

        public SetHighScore()
        {
            this.InitializeComponent();
        }

        //When this page is navigated to we get the nessesary details needed for submitting a score from the previous page.
        //Output the players score in a textblock and instantiate the ScoreOrganizerViewModel
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            gameDetails = e.Parameter as GameDetailsPasser;
            txtScore.Text = gameDetails.score.ToString();
            scoreOrganizerVM = new ScoreOrganizerViewModel();
        }

        //When the user clicks the submit score button, click event here fires
        private void submitScoreClick(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text;             //Get the name the user entered
            string difficulty = getGameDifficulty();    //Get the difficulty setting
            int gridSize = gameDetails.gridSize;        //get the grid size
            int score = gameDetails.score;              //finally get the score
            
            //Pass them all into the add method of our coreOrganizerViewModel
            scoreOrganizerVM.Add(username, difficulty, score, gridSize);
            this.Frame.Navigate(typeof(MainPage));//Then go back to the main page after all is done

        }

        //Button for submitting score changes colour when hovered over
        private void btnHover(object sender, PointerRoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Background = new SolidColorBrush(Colors.SeaGreen);
        }

        //Button for submitting score changes back to default colur when not hovered over
        private void btnHoverStopped(object sender, PointerRoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Background = new SolidColorBrush(Colors.White);
        }

        //gets the games difficulty setting from local storage
        private string getGameDifficulty()
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            App.difficulty = (string)localSettings.Values["gameDifficulty"];

            return App.difficulty; //return the difficulty of the game
        }

        //Click event to navigate to main page (home)
        private void homeClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        //Click event to navigate to settings
        private void settingsClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings));
        }

        //Click event to navigate to rules page
        private void rulesClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Rules));
        }
    }
}

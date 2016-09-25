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
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MineSweeper.Data;
using MineSweeper.ViewModels;
using Windows.UI;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MineSweeper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SetHighScore : Page
    {
        private GameDetailsPasser gameDetails;
        private ScoreOrganizerViewModel scoreOrganizerVM;

        public SetHighScore()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            gameDetails = e.Parameter as GameDetailsPasser;
            txtScore.Text = gameDetails.score.ToString();
            scoreOrganizerVM = new ScoreOrganizerViewModel();
        }

        private void submitScoreClick(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text;
            string difficulty = getGameDifficulty();
            int gridSize = gameDetails.gridSize;
            int score = gameDetails.score;
            
            scoreOrganizerVM.Add(username, difficulty, score, gridSize);
            this.Frame.Navigate(typeof(MainPage));

        }

        private void btnHover(object sender, PointerRoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Background = new SolidColorBrush(Colors.SeaGreen);
        }

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

        private void homeClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void settingsClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings));
        }

        private void rulesClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Rules));
        }
    }
}

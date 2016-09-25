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
using MineSweeper.ViewModels;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MineSweeper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewHighScore : Page
    {
        private IndexPasser passedData; //Index passer to get the selected index from the high score menu page

        public ViewHighScore()
        {
            this.InitializeComponent();
        }

        //When the page is navigated to
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Get information from HighScoresMenu stating which highscores the user wants
            passedData = e.Parameter as IndexPasser;

            //Create a ScoreOrganizerViewModel which wraps Score objects inside an Observable Collection of ScoreViewModels
            //then also manages the Binding between them and our XAML view. Pass the selected index from the user
            //into the ScoreOrganizerViewModel so the correct table is choosen from the database.
            ScoreOrganizerVM = new ScoreOrganizerViewModel(passedData.index);
        }

        //Getter and setter for the ScoreOrganizerViewModel to allow binding
        public ScoreOrganizerViewModel ScoreOrganizerVM
        {
            get;
            set;
        }

        //gets the games difficulty setting from local storage
        private string getGameDifficulty()
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            App.difficulty = (string)localSettings.Values["gameDifficulty"];

            return App.difficulty; //return the difficulty of the game
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

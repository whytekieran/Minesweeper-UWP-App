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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MineSweeper
{
    public sealed partial class ScoresMenu : Page
    {
        List<HighScoreType> highscoreOptions;                       //List of HighScoreType objects to hold high score menu options
        int selectedIndex;                                     //An int to hold the index of the listbox item selected by the user

        public ScoresMenu()
        {
            this.InitializeComponent();

            createScoreOptionList();                                        //Create the score option list
            highscoreOptionsList.ItemsSource = highscoreOptions;            //Make list of Highscore options the item source for the list highscores menu page
        }

        private void createScoreOptionList()
        {
            HighScoreType option;                                        //Declare HighScoreType object

            if (highscoreOptions == null)                       //Instantiate list of HighScoreTypes if it hasnt been already
            {
                highscoreOptions = new List<HighScoreType>();            //Instantiate done here
            }

            //We then instantiate the single HighScoreTypes object, give its instance variable
            //(which is the variable we are binding) a value and add the 
            //object to the list
            option = new HighScoreType();
            option.userScoreChoice = " 6 x 6 Easy Scores";
            highscoreOptions.Add(option);

            //Repeat the process for each high score option
            option = new HighScoreType();
            option.userScoreChoice = " 8 x 8 Easy Scores";
            highscoreOptions.Add(option);

            option = new HighScoreType();
            option.userScoreChoice = " 10 x 10 Easy Scores";
            highscoreOptions.Add(option);

            option = new HighScoreType();
            option.userScoreChoice = " 6 x 6 Medium Scores";
            highscoreOptions.Add(option);

            option = new HighScoreType();
            option.userScoreChoice = " 8 x 8 Medium Scores";
            highscoreOptions.Add(option);

            option = new HighScoreType();
            option.userScoreChoice = " 10 x 10 Medium Scores";
            highscoreOptions.Add(option);

            option = new HighScoreType();
            option.userScoreChoice = " 6 x 6 Hard Scores";
            highscoreOptions.Add(option);

            option = new HighScoreType();
            option.userScoreChoice = " 8 x 8 Hard Scores";
            highscoreOptions.Add(option);

            option = new HighScoreType();
            option.userScoreChoice = " 10 x 10 Hard Scores";
            highscoreOptions.Add(option);
        }

        //Tap event for the listbox
        private void listItemTap(object sender, TappedRoutedEventArgs e)
        {
            //First get the index of the listbox item tapped by the user
            selectedIndex = Convert.ToInt32(highscoreOptionsList.SelectedIndex);

            //Go to HighScores.xaml and pass the users choice using the IndexPasser.cs class
            Frame.Navigate(typeof(ViewHighScore), new IndexPasser { index = selectedIndex });
        }

        //Click event that takes us to the setting page
        private void settingsClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings));
        }

        //Click event that takes us to the rules page
        private void rulesClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Rules));
        }

        //Click event that takes us to the MainPage (Home) page
        private void homeClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}

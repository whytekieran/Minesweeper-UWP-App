using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System.Profile;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Game : Page
    {
        DispatcherTimer timer;                                  //Timer is used to launch a tick event
        Stopwatch stopWatch;                                    //Stopwatch works by ticks specified by timer
        private long mins;                                      //Holds the minutes of the timer
        private long secs;                                      //Holds the seconds of the timer
        private string difficulty;                              //Holds the game difficulty setting
        private int score = 0;                                  //The users score
        private bool gameRunning = false;                       //Keeps track if a game is currently running or not

        public Game()
        {
            this.InitializeComponent();
            txtScore.Text = score.ToString();       //Set the score and time to defaults
            txtTimer.Text = "0:00";
        }

        //Click event to bring us to the settings page
        private void settingsClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings));
        }


        //Radio button checked event to start the minesweeper game
        private void startMineGame(object sender, RoutedEventArgs e)
        {
            startTimer();                                           //Start the games timer
        }

        //Method to start the games timer
        private void startTimer()
        {
            //make sure the game (hence a timer) is not already running. Only start the timer if a game isnt running
            if (gameRunning == false)
            {
                timer = new DispatcherTimer();              //Instantiate a timer
                stopWatch = new Stopwatch();                //Instantiate a stop watch

                difficulty = getGameDifficulty();           //Get current games difficulty from local storage

                setTimeBasedOnDifficulty(difficulty);       //Assign timers time based on difficulty

                timer.Interval = new TimeSpan(0, 0, 0, 1, 0);        //Set the timer interval to one second
                timer.Tick += timerTick;                             //Add event to timers tick event, will be ran every second
                timer.Start();                                       //Start the timer
                stopWatch.Start();                                   //Start the stopwatch
                gameRunning = true;
            }
            else //if a game is running output an appropriate message
            {
                gameRunningMessageDisplay();
            }
        }

        //Timer tick event that is ran at second intervals
        private void timerTick(object sender, object e)
        {
            --secs; //Every tick removes one second

            txtTimer.Text = mins.ToString() + ":" + secs.ToString(); //Output mins and seconds to the screen

            if (secs == 0)//If seconds  is zero
            {
                secs = 59; //reset it
                --mins;    //take away a minute

                //Time must still be outputted even if seconds is zero
                txtTimer.Text = mins.ToString() + ":" + secs.ToString();

                //if mins is less than zero and seconds is zero to (outer if) your out of time, game over
                if (mins < 0)
                {
                    txtTimer.Text = "0" + ":" + "00";                     //Output zero minutes and seconds
                    gameRunning = false;                                  //Game is not longer running
                    timer.Stop();                                         //Stop the timer
                    stopWatch.Stop();
                    gameOverMessageDisplay();                             //Output a message box stating the games over
                }
            }
        }

        //Displays a game over message box with the users score
        private async void gameOverMessageDisplay()
        {
            //Creating instance of MessageDialog and calling its show method to show a message box
            MessageDialog msgbox = new MessageDialog("You didnt finish in time - Game Over :P");
            await msgbox.ShowAsync();
        }

        //Displays a game running message
        private async void gameRunningMessageDisplay()
        {
            //Creating instance of MessageDialog and calling its show method to show a message box
            MessageDialog msgbox = new MessageDialog("Game is already running!! Go back to Home Screen then play again if you wish to restart.");
            await msgbox.ShowAsync();
        }

        //Method takes in the difficulty as a string and assigns game time based on it
        private void setTimeBasedOnDifficulty(string difficulty)
        {
            switch(difficulty)
            {
                case "Easy":                                    //Easy Game
                    secs = 60;                                  //seconds for timer is set to 60
                    mins = 0;                                   //minutes for timer is set to 6
                    break;
                case "Medium":                                  //Medium Game
                    secs = 60;                                  //seconds for timer is set to 60
                    mins = 4;                                   //minutes for timer is set to 4
                    break;
                case "Hard":                                    //Hard Game
                    secs = 60;                                  //seconds for timer is set to 60
                    mins = 3;                                   //minutes for timer is set to 3
                    break;
            }
        }

        //gets the games difficulty setting from local storage
        private string getGameDifficulty()
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            App.difficulty = (string)localSettings.Values["gameDifficulty"];

            return App.difficulty;
        }
    }
}

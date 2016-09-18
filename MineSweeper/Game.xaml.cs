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
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MineSweeper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Game : Page
    {
        //DispatcherTimer timer;                                  //Timer is used to launch a tick event
        //Stopwatch stopWatch;                                    //Stopwatch works by ticks specified by timer
        private long mins;                                      //Holds the minutes of the timer
        private long secs;                                      //Holds the seconds of the timer
        private string difficulty;                              //Holds the game difficulty setting
        private int score = 0;                                  //The users score
        //private bool gameRunning = false;                       //Keeps track if a game is currently running or not
        CheckBox btnChecked;                                    //Holds which user game choice is checked
        private int[] mines;                                    //Holds the mine locations
        Rectangle tappedCell;                                   //Holds the currently tapped rectangle
        private int gridSize;                                   //Holds the grid size, hence the amount of mines we need

        private List<int> list;

        public Game()
        {
            this.InitializeComponent();
        }

        //When page is naviagated to
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            txtScore.Text = score.ToString();       //Set the score and time to defaults
            txtTimer.Text = "0:00";
        }

        //Click event to bring us to the settings page
        private void settingsClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings));
        }


        //Checkbox checked event to start the minesweeper game
        private void startMineGame(object sender, RoutedEventArgs e)
        {
            //Make sure the game (hence a timer and grid) is not already running. 
            //Only start the timer and create a grid if a game isnt running
            if (App.gameRunning == false)
            {
                App.gameRunning = true;
                btnChecked = (CheckBox)sender; //get the checked button

                //get first value from content of radio button (6, 8 or 10)
                gridSize = Convert.ToInt32(btnChecked.Content.ToString().Substring(0,
                                           Convert.ToInt32(btnChecked.Content.ToString().IndexOf(" "))));

                createGamesGrid(gridSize);
                startTimer();                                           //Start the games timer

            }
            else //if a game is running output an appropriate message and uncheck the new radio button
            {
                CheckBox btnChecked = (CheckBox)sender;
                btnChecked.IsChecked = false;
                
                gameRunningMessageDisplay();
            }
        }

        //Creates the games grid based on user input
        private void createGamesGrid(int gridSize)
        {
            int cols;

            //Whatever grid size is create that amount of rows and columns, essentially creates the grid and its cells
            for (cols = 0; cols < gridSize; cols++)
            {
                gameGrid.RowDefinitions.Add(new RowDefinition());
                gameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            createClickableCells(gridSize);
            setMineLocations(gridSize);
        }

        //Sets the location and amount of mines depending on grid size and game difficulty
        private void setMineLocations(int gridSize)
        {
            Random rnd = new Random();
            difficulty = getGameDifficulty();           //Get current games difficulty from local storage

            if(difficulty == "Easy")//If game difficulty is easy
            {
                if(gridSize == 6)//if grid is 6 x 6 (36 cells)
                {
                    //Creates a list (global) thats gridSize * gridSize and has all cell numbers in it
                    generateRandomMinesList(gridSize);
                    //Shuffle list and take three random numbers (mines) from it
                    mines = list.OrderBy(_ => rnd.Next()).Take(3).ToArray();
                }
                else if(gridSize == 8)//if grid is 8 x 8 (64 cells)
                {
                    //Creates a list (global) thats gridSize * gridSize and has all cell numbers in it
                    generateRandomMinesList(gridSize);
                    //Shuffle list and take five random numbers (mines) from it
                    mines = list.OrderBy(_ => rnd.Next()).Take(5).ToArray();
                }
                else if(gridSize == 10)//if grid is 10 x 10 (100 cells)
                {
                    //Creates a list (global) thats gridSize * gridSize and has all cell numbers in it
                    generateRandomMinesList(gridSize);
                    //Shuffle list and take nine random numbers (mines) from it
                    mines = list.OrderBy(_ => rnd.Next()).Take(9).ToArray();
                }
            }
            else if(difficulty == "Medium")//If game difficulty is medium
            {
                if (gridSize == 6)//if grid is 6 x 6
                {
                    //Creates a list (global) thats gridSize * gridSize and has all cell numbers in it
                    generateRandomMinesList(gridSize);
                    //Shuffle list and take six random numbers (mines) from it
                    mines = list.OrderBy(_ => rnd.Next()).Take(6).ToArray();
                }
                else if (gridSize == 8)//if grid is 8 x 8
                {
                    //Creates a list (global) thats gridSize * gridSize and has all cell numbers in it
                    generateRandomMinesList(gridSize);
                    //Shuffle list and take nine random numbers (mines) from it
                    mines = list.OrderBy(_ => rnd.Next()).Take(9).ToArray();
                }
                else if (gridSize == 10)//if grid is 10 x 10
                {
                    //Creates a list (global) thats gridSize * gridSize and has all cell numbers in it
                    generateRandomMinesList(gridSize);
                    //Shuffle list and take thirtheen random numbers (mines) from it
                    mines = list.OrderBy(_ => rnd.Next()).Take(13).ToArray();
                }
            }
            else if(difficulty == "Hard")//If game difficulty is hard
            {
                if (gridSize == 6)//if grid is 6 x 6
                {
                    //Creates a list (global) thats gridSize * gridSize and has all cell numbers in it
                    generateRandomMinesList(gridSize);
                    //Shuffle list and take ten random numbers (mines) from it
                    mines = list.OrderBy(_ => rnd.Next()).Take(10).ToArray();
                }
                else if (gridSize == 8)//if grid is 8 x 8
                {
                    //Creates a list (global) thats gridSize * gridSize and has all cell numbers in it
                    generateRandomMinesList(gridSize);
                    //Shuffle list and take fifthteen random numbers (mines) from it
                    mines = list.OrderBy(_ => rnd.Next()).Take(15).ToArray();
                }
                else if (gridSize == 10)//if grid is 10 x 10
                {
                    //Creates a list (global) thats gridSize * gridSize and has all cell numbers in it
                    generateRandomMinesList(gridSize);
                    //Shuffle list and take three twenty numbers (mines) from it
                    mines = list.OrderBy(_ => rnd.Next()).Take(20).ToArray();
                }
            }
        }

        //Creates a list with all cell numbers by using gridsize x gridsize
        private void generateRandomMinesList(int gridSize)
        {
            list = new List<int>(gridSize * gridSize);
            int cellAmount = (gridSize * gridSize);

            for (int i = 1; i <= cellAmount; i++)
            {
                list.Add(i); //Create a list with 0-26
            }
        }

        //Adds a rectangle into each cell so we can click on it.
        private void createClickableCells(int gridSize)
        {
            int rows, cols;

            //Add rectangle (cell) to each of the grid squares with light grey colour to give cells a background and also to give us
            //something clickable (rectangle) inside each cell. Make them a little smaller
            Rectangle gridCell;
            for (cols = 0; cols < gridSize; cols++)
            {
                for (rows = 0; rows < gridSize; rows++)
                {
                    gridCell = new Rectangle();
                    gridCell.Name = "r" + cols.ToString() + "_" + rows.ToString(); // r0_0
                    gridCell.Width = (gameGrid.Width / gridSize) - 4;
                    gridCell.Height = (gameGrid.Height / gridSize) - 4;
                    gridCell.HorizontalAlignment = HorizontalAlignment.Center;
                    gridCell.VerticalAlignment = VerticalAlignment.Center;
                    gridCell.SetValue(Grid.RowProperty, rows);
                    gridCell.SetValue(Grid.ColumnProperty, cols);
                    gridCell.Fill = new SolidColorBrush(Colors.LightGray);
                    gridCell.Tapped += MyR_Tapped;                          //Tapped event for each of the cells
                    gameGrid.Children.Add(gridCell);
                }
            }
        }

        //Tapped event for each cell of the grid
        private void MyR_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // tappedCell = (Rectangle)sender;
            // int row = (int)tappedCell.GetValue(Grid.RowProperty);
            // int column = (int)tappedCell.GetValue(Grid.ColumnProperty);


        }

        //Used for testing
        /*private async void showMessage(int[] list)
        {
            list.ToString();
            MessageDialog msgbox = new MessageDialog(list.Count().ToString());
            await msgbox.ShowAsync();
        }*/

        //Method to start the games timer
        private void startTimer()
        {
            App.timer = new DispatcherTimer();              //Instantiate a timer
            App.stopWatch = new Stopwatch();                //Instantiate a stop watch

            difficulty = getGameDifficulty();           //Get current games difficulty from local storage

            setTimeBasedOnDifficulty(difficulty);       //Assign timers time based on difficulty

            App.timer.Interval = new TimeSpan(0, 0, 0, 1, 0);        //Set the timer interval to one second
            App.timer.Tick += timerTick;                             //Add event to timers tick event, will be ran every second
            App.timer.Start();                                       //Start the timer
            App.stopWatch.Start();                                   //Start the stopwatch
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
                    txtScore.Text = "0";                                  //Score set back to zero
                    App.gameRunning = false;                                  //Game is not longer running
                    App.timer.Stop();                                         //Stop the timer
                    App.stopWatch.Stop();                                     //Stop the stopwatch
                    btnChecked.IsChecked = false;                         //User game choice uncheck
                    gameGrid.ColumnDefinitions.Clear();                   //Clear everything in the grid
                    gameGrid.RowDefinitions.Clear();
                    gameGrid.Children.Clear();
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
                    secs = 10;                                  //seconds for timer is set to 60
                    mins = 0;                                   //minutes for timer is set to 6
                    break;
                case "Medium":                                  //Medium Game
                    secs = 10;                                  //seconds for timer is set to 60
                    mins = 0;                                   //minutes for timer is set to 4
                    break;
                case "Hard":                                    //Hard Game
                    secs = 10;                                  //seconds for timer is set to 60
                    mins = 0;                                   //minutes for timer is set to 3
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

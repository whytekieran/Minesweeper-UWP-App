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
    public sealed partial class Game : Page
    {
        private long mins;                                      //Holds the minutes of the timer
        private long secs;                                      //Holds the seconds of the timer
        private string difficulty;                              //Holds the game difficulty setting
        private int score;                                      //The users score
        CheckBox btnChecked;                                    //Holds which user game choice is checked
        private int[] mines;                                    //Holds the mine locations
        Rectangle tappedCell;                                   //Holds the currently tapped rectangle
        private int gridSize;                                   //Holds the grid size, hence the amount of mines we need 
        private int totalCellsLeft;                             //Holds how many cells are in the grid. taken from after each tap event   
        private int mineAmnt;                                   //Holds how many mines are in the game
        private List<int> list;                    //Holds the number of every cell in the grid, only some are choosen to be mines

        //Constructor
        public Game()
        {
            this.InitializeComponent();
        }

        //When page is naviagated to
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            applyGameDefaults();
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
                totalCellsLeft = gridSize * gridSize; //Set the total cell amount of the grid.

                createGamesGrid(gridSize);                              //Create the grid for the game
                startTimer();                                           //Start the games timer

            }
            else //if a game is running output an appropriate message and uncheck the new radio button
            {
                CheckBox btnChecked = (CheckBox)sender;
                btnChecked.IsChecked = false;               //Uncheck radio button that was checked
                
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

            createClickableCells(gridSize);         //creates clickable area in each cell using a rectangle in each cell
            setMineLocations(gridSize);             //Generates mines and their locations on the grid
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
                    //Finds how many mines are in this game
                    mineAmnt = 3;
                    showMessage(mines);

                    //THIS METHOD IS FOR TESTING ONLY
                    //showMessage(mines);
                }
                else if(gridSize == 8)//if grid is 8 x 8 (64 cells)
                {
                    //Creates a list (global) thats gridSize * gridSize and has all cell numbers in it
                    generateRandomMinesList(gridSize);
                    //Shuffle list and take five random numbers (mines) from it
                    mines = list.OrderBy(_ => rnd.Next()).Take(5).ToArray();
                    mineAmnt = 5;
                }
                else if(gridSize == 10)//if grid is 10 x 10 (100 cells)
                {
                    //Creates a list (global) thats gridSize * gridSize and has all cell numbers in it
                    generateRandomMinesList(gridSize);
                    //Shuffle list and take nine random numbers (mines) from it
                    mines = list.OrderBy(_ => rnd.Next()).Take(9).ToArray();
                    mineAmnt = 9;
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
                    mineAmnt = 6;
                }
                else if (gridSize == 8)//if grid is 8 x 8
                {
                    //Creates a list (global) thats gridSize * gridSize and has all cell numbers in it
                    generateRandomMinesList(gridSize);
                    //Shuffle list and take nine random numbers (mines) from it
                    mines = list.OrderBy(_ => rnd.Next()).Take(9).ToArray();
                    mineAmnt = 9;
                }
                else if (gridSize == 10)//if grid is 10 x 10
                {
                    //Creates a list (global) thats gridSize * gridSize and has all cell numbers in it
                    generateRandomMinesList(gridSize);
                    //Shuffle list and take thirtheen random numbers (mines) from it
                    mines = list.OrderBy(_ => rnd.Next()).Take(13).ToArray();
                    mineAmnt = 13;
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
                    mineAmnt = 10;
                }
                else if (gridSize == 8)//if grid is 8 x 8
                {
                    //Creates a list (global) thats gridSize * gridSize and has all cell numbers in it
                    generateRandomMinesList(gridSize);
                    //Shuffle list and take fifthteen random numbers (mines) from it
                    mines = list.OrderBy(_ => rnd.Next()).Take(15).ToArray();
                    mineAmnt = 15;
                }
                else if (gridSize == 10)//if grid is 10 x 10
                {
                    //Creates a list (global) thats gridSize * gridSize and has all cell numbers in it
                    generateRandomMinesList(gridSize);
                    //Shuffle list and take three twenty numbers (mines) from it
                    mines = list.OrderBy(_ => rnd.Next()).Take(20).ToArray();
                    mineAmnt = 20;
                }
            }
        }

      
        ///////////////////////////////////////////////////////////////////////
     
        //Used for testing
         private async void showMessage(int [] ary)
         {
             MessageDialog msgbox = new MessageDialog(ary[0].ToString() + " " + ary[1].ToString() + " " + ary[2].ToString());
             await msgbox.ShowAsync();
         }
       
        //////////////////////////////////////////////////////////////////////////
      
        //Creates a list with all the cell numbers by using gridsize x gridsize
        private void generateRandomMinesList(int gridSize)
        {
            list = new List<int>(gridSize * gridSize);
            int cellAmount = (gridSize * gridSize);

            for (int i = 1; i <= cellAmount; i++)
            {
                list.Add(i); //Create a list with each element as a cell number
            }
        }

        //Adds a rectangle into each cell so we can click on it.
        private void createClickableCells(int gridSize)
        {
            int rows, cols;

            //Add rectangle (cell) to each of the grid squares with light grey colour to give cells a background and also to give us
            //something clickable (rectangle) inside each cell. Make them a little smaller
            Rectangle gridCell;
            for (cols = 0; cols < gridSize; cols++)//Column loop
            {
                for (rows = 0; rows < gridSize; rows++)//Inner row loop
                {
                    gridCell = new Rectangle();                                         //make a rectangle for the grid cell
                    gridCell.Name = "r" + cols.ToString() + "_" + rows.ToString();      // give it a name
                    gridCell.Width = (gameGrid.Width / gridSize) - 4;              //Width and height of rectangle            
                    gridCell.Height = (gameGrid.Height / gridSize) - 4;
                    gridCell.HorizontalAlignment = HorizontalAlignment.Center;  //Centre it in the cell
                    gridCell.VerticalAlignment = VerticalAlignment.Center;
                    gridCell.SetValue(Grid.RowProperty, rows);                  //Set its cell positon
                    gridCell.SetValue(Grid.ColumnProperty, cols);
                    gridCell.Fill = new SolidColorBrush(Colors.LightGray);
                    gridCell.Tapped += MyR_Tapped;                          //Tapped event for each of the cells
                    gameGrid.Children.Add(gridCell);                        //Add it to the grid
                }
            }
        }

        //Tapped event for each cell of the grid
        private void MyR_Tapped(object sender, TappedRoutedEventArgs e)
        {
            tappedCell = (Rectangle)sender;                         //Find the rectangle (cell) that was tapped
            int row = (int)tappedCell.GetValue(Grid.RowProperty);   //Get its row and column
            int column = (int)tappedCell.GetValue(Grid.ColumnProperty);
            bool mineFound = false;

            //Get the actual cell number eg (2,3) would be cell number 16
            int tappedCellNumber = getCellsTappedNumber(row, column);  

            bool hit = searchForMine(tappedCellNumber); //Search if that location contains a mine

            if(hit)//If it does
            {
                tappedCell.Fill = new SolidColorBrush(Colors.Red);   //fill that cell red
                showAllTheMines();                                   //show where all the other mines are
                showMineHitGameOverMsg();                            //Output a game over message
            }
            else //if there was not a mine hit
            {
                mineFound = checkIfMineIsAdjacent(row, column);//Check if there are nearby mines

                if(mineFound == true)//if a mine is nearby
                {
                    tappedCell.Fill = new SolidColorBrush(Colors.Yellow);//tapped tile turns yellow (warning)
                }
                else//if not
                {
                    tappedCell.Fill = new SolidColorBrush(Colors.Green);//tapped tile turns greet (all clear)
                }

                //Method name speaks for itself :)
                incrementScoreBasedOnDifficulty();

                --totalCellsLeft;
                  
                if(totalCellsLeft == mineAmnt)//We have won!! Only mines left!!
                {
                    calculateScore();                   //calculate total score based on time
                    txtScore.Text = score.ToString();   //output it in score area
                    showWinnerMessage();                //show winner msg with play again or save high score option
                }
            }
        }

        //Calculates a users total score based on remaining time.
        private void calculateScore()
        {
            score = Convert.ToInt32(txtScore.Text);
            int iMins = (int)mins;
            int iSecs = (int)secs;
            int minsScore = 30 * iMins;//30 Points for each minute left
            int secsScore = 2 * iSecs;//2 points for every second left
            score = score + (minsScore + secsScore);
        }

        //Checks if any mines are directly adjacent to the cell the user just clicked
        private bool checkIfMineIsAdjacent(int row, int column)
        {
            int tappedNumber;
            bool mineFound = false;

            //Start with row above cell clicked, the same row, lastly the row below it.
            for (int i = (row - 1); i <= (row + 1); ++i)
            {
                if(mineFound == true)//If a mine has already been found break the outer loop
                {
                    break;
                }

                for(int j = (column - 1); j <= (column + 1); ++j)
                {
                    if((i < 0 || i >= gridSize) || (j < 0 || j >= gridSize))//out of bounds so dont check
                    {
                        continue;
                    }
                    else
                    {
                        if(i == row && j == column)//dont check the grid user just tapped for a mine
                        {
                            continue;
                        }
                        else
                        {
                            //Get cell number of grid we are looping over
                            //Check if the current grid we are looping over has a mine
                            tappedNumber = getCellsTappedNumber(i, j);
                            mineFound = searchForMine(tappedNumber);

                            if(mineFound == true) //if we find a mine break the inner loop
                            {
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }//inner if/else (inner loop)
                    }//outer if/else (inner loop)
                }//End inner loop
            }//End outer loop

            return mineFound;//return result stating if a mine was found adjacent to the clicked cell

        }//End method

        //Increments the players score based on how difficult the game is
        private void incrementScoreBasedOnDifficulty()
        {
            difficulty = getGameDifficulty();

            if(difficulty == "Easy")
            {
                score += 3;
            }
            else if(difficulty == "Medium")
            {
                score += 6;
            }
            else if(difficulty == "Hard")
            {
                score += 9;
            }

            txtScore.Text = score.ToString();//Set the score in the textblock
        }

        //Method to show all the mines as red rectangles
        private void showAllTheMines()
        {
            int row;
            int col;
            Rectangle mineCell;

            for(int i = 0; i < mines.Count(); ++i)//Loop over the mine location array
            {
                mineCell = new Rectangle();                     //Create rectangle
                row = convertTo2DRow(mines[i]);                 //Use mine location number in mines to get grids row
                col = convertTo2DCol(mines[i]);                 //Use location number to get grid column
                mineCell.SetValue(Grid.RowProperty, row);       //Set rectangle to the row and col values
                mineCell.SetValue(Grid.ColumnProperty, col);
                mineCell.Fill = new SolidColorBrush(Colors.Red);    //Colour rectangle red
                gameGrid.Children.Add(mineCell);                    //Add the rectangle to the grid
            }
        }

        //Method to convert the mine location number to a grid row
        private int convertTo2DCol(int mineNumber)
        {
            int col = mineNumber % gridSize;
            
            if(col != 0)
            {
                col -= 1;
            }
            else
            {
                col = 5;
            }

            return col;
        }

        //Method to convert the mine location number to a grid column
        private int convertTo2DRow(int mineNumber)
        {
            int row = mineNumber / gridSize;
            return row;
        }

       //Shows the user a congratulations you won message, async method runs in separate thread, so it wont slow UI
       private async void showWinnerMessage()
       {
            //Create a message dialong
            MessageDialog msgDialog = new MessageDialog("Well done you won, score total is: "+score, "Winner");

            //Add your highscore Button
            UICommand highscoreBtn = new UICommand("Add Highscore");
            highscoreBtn.Invoked = highscoreClick;                 //Add event for the okay button
            msgDialog.Commands.Add(highscoreBtn);

            //play again button
            UICommand playAgainBtn = new UICommand("Play Again");
            playAgainBtn.Invoked = playAgainClick;                 //Add event for the okay button
            msgDialog.Commands.Add(playAgainBtn);

            stopGameTimers();                                         //Stop the games timers

            await msgDialog.ShowAsync();
        }

        //Event for the play again button
        private void playAgainClick(IUICommand command)
        {
            applyGameDefaults();                                    //Apply default settings, does a refresh
            uncheckGameSelection();
        }

        //Event for the set high score button
        private void highscoreClick(IUICommand command)
        {
            //Navigate to the set score page and pass details about the gridsize and player score
            this.Frame.Navigate(typeof(SetHighScore), new GameDetailsPasser { gridSize = gridSize, score = score });
        }

        //Show message indicating a mine g=hit and end of game
        private async void showMineHitGameOverMsg()
        {
            MessageDialog msgDialog = new MessageDialog("You struck a mine - Game Over :(", "Game Over");

            //OK Button
            UICommand okBtn = new UICommand("OK");
            okBtn.Invoked = OkBtnClick;                 //Add event for the okay button
            msgDialog.Commands.Add(okBtn);

            stopGameTimers();                                           //Stop the games timers

            await msgDialog.ShowAsync();
        }

        //Okay button event for the showMineHitGameOverMsg() message dialog button
        private void OkBtnClick(IUICommand command)
        {
            applyGameDefaults();                                    //Apply default settings, does a refresh
            uncheckGameSelection();
        }

        //Checks if any mine number matches the tapped cells number
        private bool searchForMine(int tappedCellNumber)
        {
            bool hit = false;

            for(int i = 0; i < mines.Count(); ++i)//loop over array of mine locations
            {
                if(mines[i] == tappedCellNumber)//if any of the locations equal the tapped cell number
                {
                    hit = true;                 //hit is now true
                }
            }

            return hit;                         //return the result
        }

        //Gets the actual cell number of the tapped cell. eg (2,3) would be cell number 16. This way we can compare
        //the tapped cell number to the int array full of random mine locations.
        private int getCellsTappedNumber(int row, int column)
        {
            int tappedNumber = -1;

            switch(row)
            {
                case 0:
                    tappedNumber = column + 1;
                    break;
                case 1:
                    tappedNumber = ((gridSize * 1) + 1) + column;
                    break;
                case 2:
                    tappedNumber = ((gridSize * 2) + 1) + column;
                    break;
                case 3:
                    tappedNumber = ((gridSize * 3) + 1) + column;
                    break;
                case 4:
                    tappedNumber = ((gridSize * 4) + 1) + column;
                    break;
                case 5:
                    tappedNumber = ((gridSize * 5) + 1) + column;
                    break;
                case 6:
                    tappedNumber = ((gridSize * 6) + 1) + column;
                    break;
                case 7:
                    tappedNumber = ((gridSize * 7) + 1) + column;
                    break;
                case 8:
                    tappedNumber = ((gridSize * 8) + 1) + column;
                    break;
                case 9:
                    tappedNumber = ((gridSize * 9) + 1) + column;
                    break;
            }
            return tappedNumber;
        }

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
                    stopGameTimers();                                       //stop the games timers
                    applyGameDefaults();                                    //Apply defaults for game start
                    gameOverMessageDisplay();                             //Output a message box stating the games over
                }
            }
        }

        //Refreshes the grid, sets game running variable, sets score and time output back to 0
        private void applyGameDefaults()
        {
            txtTimer.Text = "0" + ":" + "00";                     //Output zero minutes and seconds
            txtScore.Text = "0";                                  //Score set back to zero
            score = 0;
            App.gameRunning = false;                                  //Game is not longer running
            gameGrid.ColumnDefinitions.Clear();                   //Clear everything in the grid
            gameGrid.RowDefinitions.Clear();
            gameGrid.Children.Clear();
        }

        private void uncheckGameSelection()
        {
            btnChecked.IsChecked = false;                         //User game choice uncheck
        }

        //Stops the games timers
        private void stopGameTimers()
        {
            App.timer.Stop();                                         //Stop the timer
            App.stopWatch.Stop();                                     //Stop the stopwatch
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
                    mins = 6;                                   //minutes for timer is set to 6
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

            return App.difficulty; //return the difficulty of the game
        }

        //Click event brings us to the rules page
        private void rulesClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Rules));
        }

        //Click event brings us to the main page (home)
        private void homeClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}

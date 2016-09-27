# **_MineSweeper_** &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  ![Constituencies](/ReadMeImages/Minesweeper1.png)

**Student Name:** Ciaran Whyte </br>
**Student ID:** G00254624 </br>
**Course:** Software Development </br>
**Current Year:** 4th Year </br>
**Module:** Mobile Application Development </br>
**Lecturer:** Martin Kenirons </br>

## **_Introduction_**
This is a Minesweeper game built for the Universal Windows Platform. The game consists of three difficulty settings, easy, medium and hard. The higher the difficulty, 
the more mines the player has to try and avoid. In any of these difficulty settings the player can choose from a 6x6 grid game, 8x8 grid game of a 10x10 grid game. <br><br>
To play the game you firstly choose the size of grid you want to play on. This will generate the grid for you. The player can then start to click/tap on the individual cells
of the grid. When clicked the cell can turn one of three colours. A green cell means that all the surrounding cells of the one clicked are safe and no mine is in them. A yellow 
grid means that there is a mine in one of the cells that surrounds that cell that was clicked. A red cell means that you have hit a mine, at this point all the other mines will
be shown (Blow up) and the game is over. When the player manages to only have cells with mines left in the grid he/she will be notified they have won. <br><br>
When the player wins a game he/she will then have the option to save their score to high scores. These are stored in an SQLite database and the table they are saved into depends
on which type of game and difficulty settings the user has choosen. The game itself does have a rules page which decribes how to play the game to any user that downloads it.
//could possibly add link to the store once its on it.

## **_Techical Summary_**

### **XAML**
XAML is used to the design the User Interface or "Views" of the application. These are the areas the user interacts with. The pages that have been created using XAML in
this project are as follows:

XAML Page | Description
------------ | -------------
MainPage.xaml | This is the home page of the application, from here the user can choose to play a game, view scores, go to settings, view the rules or simply exit.
Game.xaml | This is the page where the minesweeper game is actually played. The user selects what grid size he/she wants and then its created on the fly.
Rules.xaml | A page that shows a list of game rules to the user.
ScoresMenu.xaml | On this page the user can select from a list of menu options to view a particular set of high scores. Uses some basic binding.
SetHighScore.xaml | This page is shown after a user wins a game. It allows them to input a name and save their high score.
Settings.xaml | Here the user can set the game difficulty to easy medium or hard mode.
ViewHighScore.xaml | This page is where the user can view their high scores, the page uses the MVVM model to bind the scores to the page.

### **C#**
describe the back end, c# classes used for the game and MVVM

### **SQLite**
The SQLite database saves the scores on a local database. This database is used solely for the users scores and does not save online scores for all users that play the game.
The database called Minesweeper.db consists of nine tables which are as follows:

Table Name | Description
------------ | -------------
EScore6 | Holds high scores for an easy mode 6x6 game
EScore8 | Holds high scores for an easy mode 8x8 game
EScore10 | Holds high scores for an easy mode 10x10 game
MScore6 | Holds high scores for a medium mode 6x6 game
MScore8 | Holds high scores for a medium mode 8x8 game
MScore10 | Holds high scores for a medium mode 10x10 game
HScore6 | Holds high scores for a hard mode 6x6 game
HScore8 | Holds high scores for a hard mode 8x8 game
HScore10 | Holds high scores for a hard mode 10x10 game


### **Data Binding**
In this particular application data binding exists in a few places. Firstly there is a very basic example using the "Binding" keyword shown inside the ScoresMenu page.
In this example a List of objects is created using C# code, these objects simply contain information about each menu item. The menu or "list box items" are 
then binded to these objects by using the list boxes **ItemsSource** property.<br><br>
The second and more complex example of binding in this application uses the MVVM architecture and we use this in the ViewHighScores.xaml page. 
Basically what we do in the code behind for this page (ViewHighScores.xaml.cs) is we create an object of ScoreOrganizerViewModel type. This object then creates an object 
of ScoreOrganizer type which contains a list of GenericScore objects that have been retrieved from the database. Each one of these GenericScore objects is passed into an 
**Observable Collection** that sends notifications whenever any changes are made. This collection is the binded to the view which is what the user can see. The 
ScoreOrganizerViewModel inherites a class that implements the **INotifcationPropertyChanged** event and also has **generic methods** that can handle any object, hence making the
whole model incredibly flexible. MVVM and its advantages are discussed in much more detail directly below.

### **MVVM**
The Model View View-Model (MVVM) architecture is a style of writing applications that allows us to break up the code into easily managable modules.
//describe the MVVM model used and how its implemented

### **External Data Sources**
//describe briefly that the app also has an api, discussed more down below


## **_SQLite Data Storage_**
The local high score storage for this minesweeper game are usingan SQLite database. To install SQLite for a project on Visual Studio 2015 you must do the following:
- First you need to go to the SQLite download site at [https://www.sqlite.org/download.html](https://www.sqlite.org/download.html)
- Download SQLite for **Universal Windows Platform**
- Open up Visual Studio 2015
- The first thing we must do once Visual Studio 2015 is opened is add a reference to SQLite
- Right click on the **References** folder in your project on **Solution Explorer** and then click **Add Reference**
- On the pop up window, navigate to the **Universal Windows section** on the left and click **Extensions** 
- Tick the **SQLite for Universal App platform** box, and also the **C++ Runtime 2015** then click **OK**
- In your project in solution explorer once again right click on the **References** folder and select **Manage Nuget Packages**
- Select **Browse** and then type the following into the search area: **SQLite.Net-PCL**
- You should see the package, then click **install**
- Thats it, SQLite is now installed into the project

## **_The External API_**
//discuss the api created with jax-rs for global(online) high scores

## **_Deployment For Visual Studio 2015_**
//describe how to deploy the app here

## **_References_**
//Add references here
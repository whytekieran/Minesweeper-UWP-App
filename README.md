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
The C# Programming language is what provides this application with its functionality. The logic behind all the XAML page views and more is all written using the C# language, hence
every XAML page has a corresponding C# class behind it. A breakdown of the indiviual C# classes for this project is as follows:

Class | Description
------------ | -------------
App.xaml.cs | This class comes with any visual studio project and contains methods which describe what to do during the applications life cycle, example would be what the application does when its been launched, suspended or terminated. These methods give the developer great flexibility to describe what they want done during these critical stages ofthe application life cycle. This class also contains custom made methods that i have created to manage things like navigation between pages and the games timers.
Game.xaml.cs | This class is responsible for executing all the logic that goes into the minesweeper game itself. It is the most heavily coded area of the application. It contains methods for created the games grid, starting and stopping timers, positioning/checking for mines, applying game defaults, incrementing score and many others. The code itself has been heavily commented to assist anyone reading through it as best as possible.
MainPage.xaml.cs | This class is simple enough in its structure. It is the logic for the Main(Home) page of the application. It checks the local user game settings and also contains some events to handle navigation.
Rules.xaml.cs | A simple class that uses a custom made object called RulesSetter to bind objects to a list of game rules to be displayed for the user.
ScoresMenu.xaml.cs | This class is very similar to the Rules.xaml.cs as its used to bind objects to a list. The difference being that these list items have events attached to them so we can navigate to the selected page.
SetHighScore.xaml.cs | This class is used as the starting point to submit scores to our database via the MVVM model. It recieves data from the Game.xaml.cs page when a user has won a game. Then submits that data to storage after the user fills in his/her information. 
Settings.xaml.cs | This class is responible for changing the local settings of the game. The local setting change the games difficulty and are stored so this setting does not change when the app is closed. The class also contains some simple navigation methods.
ViewHighScore.xaml.cs | This class binds score information from the database to a list via the MVVM architecture. It begins the bind procedure by grabbing the index of the selected score menu from the list on the previous page. It then passes this index into the ScoreOrganizerViewModel (described further down) which then takes over.
GameDetailsPasser.cs | This class has two instance variables for score and grid size. It is used to pass game information from the game page to the set high score page once the user has won a game.
HighScoreType.cs | A very basic class with an instance variable of string type used to bind score menu options to a list item source in the high score menu page.
IndexPasser.cs | A  basic class like the one previous with one instance variable of int type used to pass the selected index of a list box to the next page.
(MVVM) Data/DataService.cs | This class is at the data layer of the MVVM model i have implemented into this application. This particular class is responible solely for managing the score data in the SQLite database and contains methods to both read and write from it.
(MVVM) Data/DataClasses.cs | This class contains all the class that are used to interact with the database. There are ten classes in total. Nine of these class are used to create the database tables hence giving each table a unique name apon creation, they are also used to insert data. The other class is a generic type which is the same as all the other classes. We use this class when retrieving data hence we dont need anymore than one observable collection and this makes everything more managable.
(MVVM) Models/ScoreOrganizer.cs | This class works at the model layer and has the sole responsibility of communicating with the data layer. Inside this class we have a list of score objects which are managed within this class.
(MVVM) ViewModels/VMHelper.cs | This class extends the INotification interface, this interface can tell when the property of an object has changed and can then describe how an object can participate in XAML bindings. It provides generalized methods that can be applied to any object that inherits this class and are performed when any property of the inheriting object(class) changes.
(MVVM) ViewModels/ScoreOrganizerViewModel.cs | This class is responible for wrapping the ScoreOrganizer.cs class. It retrieves a list of score objects from this class and passes each object in the list to its own View Model then passes that View Model into an observable collection. An observable collection sends notifications any time one of its elements are altered.
(MVVM) ViewModels/ScoreGenericViewModel.cs | Each element in the observable collection is of ScoreGenericViewModel type. The properties of this object use the setProperty method that it gets from inheriting our generic helper class, VMHelper. This method will send notications when one of the properties of this View Model changes.

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
The goal of using the MVVM model is to have **easily interchangable modules**, this allows us to swap modules in and out and makes testing much easier. A prime example would be in
**Unit Testing** where we can swap in a 'mock' module to replicate something and test the other components against it. The MVVM architecture is achieved by using **Generic classes** and
methods. **The Generic type(T)** in C# can except any type of object, hence making our programs much more flexible and reducing the need to re-write code.

### **Handling Orientation & Screen Rotation*

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
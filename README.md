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
/decribe the application structure, XAML pages etc

### **C#**
describe the back end, c# classes used for the game and MVVM

### **SQLite**
//decribe the SQLite database

### **MVVM**
//describe the MVVM model used and how its implemented

### **Data Binding**
//describe areas where there is data binding

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
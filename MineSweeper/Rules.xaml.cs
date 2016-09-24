using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace MineSweeper
{
    public sealed partial class Rules : Page
    {
        List<RulesSetter> rulesList;                       //List of RuleSetter objects to hold rules for list box view

        public Rules()
        {
            this.InitializeComponent();

            createRulesList();                                //Adds rules to the RulesSetter list
            rulesListView.ItemsSource = rulesList;            //Make list of rules the item source for the list on the rules page
        }

        private void createRulesList()
        {
            RulesSetter rule;                               //RulesSetter object

            if (rulesList == null)                          //Instantiate list of RuleSetters if it hasnt been already
            {
                rulesList = new List<RulesSetter>();        //Instantiate done here
            }

            //Instantiate RuleSetter object, give data and add to the list. Do this for each rule
            rule = new RulesSetter();
            rule.ruleID = "Rule 1";
            rule.ruleDescription = "The objective of the game is to clear all grid cells that dont have a mine before the time "+
                                   "runs out. Once all the grid cells have been claered and only mines remain you win and will recieve"+
                                   "a message congratulating you and asking if you wish to save your score";
            rulesList.Add(rule);

            rule = new RulesSetter();
            rule.ruleID = "Rule 2";
            rule.ruleDescription = "If you click a grid cell and its green it means there are no mines in any of the surrounding"+
                                   " grid cells.";
            rulesList.Add(rule);

            rule = new RulesSetter();
            rule.ruleID = "Rule 3";
            rule.ruleDescription = "If you click a grid cell and its yellow it means that there is a mine in one of the surrounding"+
                                   " grid cells.";
            rulesList.Add(rule);

            rule = new RulesSetter();
            rule.ruleID = "Rule 4";
            rule.ruleDescription = "So based on the green and yellow grid cells you click on try to use some of your own logic to avoid"+
                                   " any of the mines";             
            rulesList.Add(rule);

            rule = new RulesSetter();
            rule.ruleID = "Rule 5";
            rule.ruleDescription = "If you click on a grid cell and its red then all the mines explode and your game is over. You have"+
                                   " the option of starting again if you wish";
            rulesList.Add(rule);

            rule = new RulesSetter();
            rule.ruleID = "Rule 6";
            rule.ruleDescription = "You can set the difficulty of the game to easy, medium or hard. The harder the game the"+
                                   " more mines are hidden in the grid.";
            rulesList.Add(rule);

            rule = new RulesSetter();
            rule.ruleID = "Rule 7";
            rule.ruleDescription = "You get points addded to your score each time you click a grid that does not have a mine"+
                                   " but you can only save your score as a highscore if you finish the game. You final score"+
                                   " is then calculated based on the points you have already built up, the games difficulty"+
                                   " and how much time you still had left when you finshed.";
            rulesList.Add(rule);

            rule = new RulesSetter();
            rule.ruleID = "Thats Everything";
            rule.ruleDescription = "Enjoy the game";
            rulesList.Add(rule);
        }

        //Click event to bring us to the setting page
        private void settingsClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings));
        }

        //Click event to bring us to the main page (home)
        private void homeClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}

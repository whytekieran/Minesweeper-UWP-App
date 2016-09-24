using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Checks the radio button that the game difficulty is currently set to
            checkCurrentSettingRadioButton();
        }

        //sets the radio button to the current game difficulty
        private void checkCurrentSettingRadioButton()
        {
            //Get local settings
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            App.difficulty = (string)localSettings.Values["gameDifficulty"];

            if(App.difficulty == "Easy")
            {
                RadioButton btn = (RadioButton)this.FindName("rbEasy");
                btn.IsChecked = true;
            }
            else if(App.difficulty == "Medium")
            {
                RadioButton btn = (RadioButton)this.FindName("rbMedium");
                btn.IsChecked = true;
            }
            else if(App.difficulty == "Hard")
            {
                RadioButton btn = (RadioButton)this.FindName("rbHard");
                btn.IsChecked = true;
            }
        }

        //Checked event for radio buttons, when one is checked
        private void rbDifficulty(object sender, RoutedEventArgs e)
        {
            RadioButton checkedBtn = (RadioButton)sender;   //get the button thats been checked
            App.difficulty = checkedBtn.Content.ToString(); //Set global app variable to difficulty from button content

            setGameDifficulty(App.difficulty);  //Pass the variable into method to set local storage settings
        }

        //Sets the games difficulty in local storage
        private void setGameDifficulty(string difficulty)
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values["gameDifficulty"] = difficulty;
        }

        //Click event takes us to the Rules page
        private void rulesClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Rules));
        }

        //Click event takes us to the main page (home)
        private void homeClick(object sender, RoutedEventArgs e)
        {
           this.Frame.Navigate(typeof(MainPage));
        }
    }
}

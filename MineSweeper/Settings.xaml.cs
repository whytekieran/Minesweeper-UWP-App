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
    }
}

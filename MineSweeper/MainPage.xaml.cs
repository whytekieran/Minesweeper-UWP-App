using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MineSweeper
{
    public sealed partial class MainPage : Page
    {
       // private SimpleOrientationSensor orientationSensor;

        //Constructor
        public MainPage()
        {
            this.InitializeComponent();
        }
        //End constructor

        //When this page has been navigated to
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Call method to check local setting for difficulty
            checkDifficultySetting();
        }

        //Checks the current difficulty settings
        private async void checkDifficultySetting()
        {
            try
            {
                //Get difficulty settings from local storage
                ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
                App.difficulty = (string)localSettings.Values["gameDifficulty"];

                //If we get nothing back then just set default setting (easy mode)
                if (App.difficulty == null || App.difficulty == "")
                {
                    setDefaultSetting();
                }
            }
            catch
            {
                //Show error message
                MessageDialog msgbox = new MessageDialog("An issue has occured getting settings - defaults applied");
                await msgbox.ShowAsync();

                //If we get any exception then just set default setting (easy mode)
                setDefaultSetting();
            }
        }

        private void setDefaultSetting()
        {
            //Sets game difficulty to 'easy'
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            App.difficulty = "Easy";
            localSettings.Values["gameDifficulty"] = App.difficulty;
        }

        //Changes buttons background colour when we mouse over them
        private void btnHover(object sender, PointerRoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Background = new SolidColorBrush(Colors.SeaGreen);

        }

        //Changes buttons background colour back to default when mouse stops hovering over them
        private void btnHoverStopped(object sender, PointerRoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Background = new SolidColorBrush(Colors.White);
        }

        //Click event for exit button that closes the app
        private void exitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        //Click event for scores button that navigates us to the scores page
        private void scoresClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ScoresMenu));
        }

        //Click event for the play button that navigates us to the game page
        private void playClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Game));
        }

        //Click event to bring us to the settings page
        private void settingsClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings));
        }

        //Click event to bring us to the rules page
        private void rulesClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Rules));
        }
    }
}

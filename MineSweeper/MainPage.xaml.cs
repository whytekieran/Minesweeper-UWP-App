using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.Core;
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
        private SimpleOrientationSensor orientationSensor;

        //Constructor
        public MainPage()
        {
            this.InitializeComponent();
            orientationSensor = SimpleOrientationSensor.GetDefault();  //Get a default version of the orientation sensor.

            // Assign an event handler for the sensor orientation-changed event 
            if (orientationSensor != null)
            {
                orientationSensor.OrientationChanged += new TypedEventHandler<SimpleOrientationSensor, SimpleOrientationSensorOrientationChangedEventArgs>(OrientationChanged);
            }
        }
        //End constructor

        //This event handler is triggered when the orientation of the phone changes, because the method uses the
        //async keyword it will happen asynchronously. Hence allowing the application to continue with other tasks while this
        //method is being executed in a seperate thread to the UI thread.
        private async void OrientationChanged(object sender, SimpleOrientationSensorOrientationChangedEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                SimpleOrientation orientation = e.Orientation;      //Here we retrieve the current orientation of the sensor
                switch (orientation)
                {
                    case SimpleOrientation.NotRotated:  //If the phone isnt being rotated (portrait)
                        //Portrait 
                        DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;  //Set orientation to portrait
                        VisualStateManager.GoToState(this, "Portrait", true);                       //use portrait visual state
                        break;
                    case SimpleOrientation.Rotated90DegreesCounterclockwise:  //if rotated 90degrees to the left
                        //Landscape
                        DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape; //set orientation to landscape
                        VisualStateManager.GoToState(this, "Landscape", true);                      //use the landscape visual state
                        break;
                    case SimpleOrientation.Rotated270DegreesCounterclockwise: //if 90degrees rotated to the right
                        //Landscape
                        DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape; //set orientation to landscape
                        VisualStateManager.GoToState(this, "Landscape", true);                      //use the landscape visual state
                        break;
                }
            });
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
            this.Frame.Navigate(typeof(Scores));
        }

        //Click event for the play button that navigates us to the game page
        private void playClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Game));
        }

        private void settingsClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings));
        }
    }
}

using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MineSweeper.Data;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MineSweeper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SetHighScore : Page
    {
        public SetHighScore()
        {
            this.InitializeComponent();
        }

        private void add(object sender, RoutedEventArgs e)
        {
            //works
             SQLiteConnection con;           //Connection object for SQLite database
            string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Minesweeper.sqlite");
            con = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            string u = username.Text;
            int s = Convert.ToInt32(score.Text);

            con.Execute("insert into EScore6 (Username, UserScore) values ('"+u+"',"+s+")");
        }
    }
}

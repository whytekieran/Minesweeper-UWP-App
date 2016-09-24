using MineSweeper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.ViewModels
{
    //The NotificationBase class extends the INotifyPropertyChanged class which has generalized methods that describe what
    //should be done when the property of an object changes. Because ScoreOrganizer.cs has a constructor that takes a parameter
    //we cant include it as the wrapped model by using NotificationBase<ScoreOrganizer> instead we include it in the viewmodel
    //class as an instance variable and create a binding to it in MainPage.xaml.cs ..This is because the constructor for
    //NotificationBase has been set that way. (See VMHelper.cs)

    //NOTE: Commented out code may not be nessesary for this program - at least not for now, looks doubtful
    public class ScoreOrganizerViewModel : VMHelper
    {
        ScoreOrganizer organizer;

        //Contructor takes index of selected user option
        public ScoreOrganizerViewModel(int choosenTable)
        {
            //Create ScoreOrganizer which will create a list of scores based on that choice
            organizer = new ScoreOrganizer(choosenTable);
            //_SelectedIndex = -1;
           
            foreach (var score in organizer.scores)//access the list and loop over it (score objects)
            {
                var newScore = new ScoreViewModel(score);                   //add each score object to a new ScoreViewModel
                //newScore.PropertyChanged += Person_OnNotifyPropertyChanged; //add event handler for property changes
                _Scores.Add(newScore);  //add ScoreViewModel to observable collection list
            }
        }

        //observable collection list will notify if there is a change within it
        ObservableCollection<ScoreViewModel> _Scores
           = new ObservableCollection<ScoreViewModel>();

        //getters/setter for the list
        public ObservableCollection<ScoreViewModel> ScoresCollection
        {
            get { return _Scores; }
            set { SetProperty(ref _Scores, value); }
        }

        /*
        int _SelectedIndex;
        public int SelectedIndex
        {
            get
            {
                return _SelectedIndex;
            }
            set
            {
                if (SetProperty(ref _SelectedIndex, value))
                {
                    RaisePropertyChanged(nameof(SelectedScore));
                }
            }
        }

        public ScoreViewModel SelectedScore
        {
            get { return (_SelectedIndex >= 0) ? _Scores[_SelectedIndex] : null; }
        }*/

        public void Add()
        {
            var score = new ScoreViewModel();
            //score.PropertyChanged += Person_OnNotifyPropertyChanged;
            ScoresCollection.Add(score);
            organizer.Add(score);
            //SelectedIndex = ScoresCollection.IndexOf(score);
        }

       /* public void Delete()
        {
            if (SelectedIndex != -1)
            {
                var score = ScoresCollection[SelectedIndex];
                ScoresCollection.RemoveAt(SelectedIndex);
                organizer.Delete(score);
            }
        }*/

            /*
        //may not be nessesary for this program
        void Person_OnNotifyPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            organizer.Update((ScoreViewModel)sender);
        }
        */
    }
}

using MineSweeper.Data;
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
    //The VMHelper class extends the INotifyPropertyChanged class which has generalized methods that describe what
    //should be done when the property of an object changes. Because ScoreOrganizer.cs has a constructor that takes a parameter
    //we cant include it as the wrapped model by using VMHelper<ScoreOrganizer> instead we include it in the viewmodel
    //class as an instance variable and create a binding to it in MainPage.xaml.cs ..This is because the constructor for
    //VMHelper has been set that way. (See VMHelper.cs)

    //NOTE: Commented out code may not be nessesary for this program - at least not for now, looks doubtful
    public class ScoreOrganizerViewModel : VMHelper
    {
        ScoreOrganizer insertOrganizer;
        ScoreOrganizer organizer;
        ScoreGeneric scoreGeneric;

        //Overloaded default constructor
        public ScoreOrganizerViewModel()
        {
            insertOrganizer = new ScoreOrganizer();
        }

        //Contructor takes index of selected user option
        public ScoreOrganizerViewModel(int choosenTable)
        {
            //Create ScoreOrganizer which will create a list of scores based on that choice
            organizer = new ScoreOrganizer(choosenTable);
            //_SelectedIndex = -1;

            foreach (var score in organizer.scores)//access the list and loop over it (score objects)
            {
                scoreGeneric = (ScoreGeneric)score;                               //Cast generic object to score object type
                var newScore = new ScoreGenericViewModel(scoreGeneric);           //add each score object to a new ScoreGenericViewModel
                //newScore.PropertyChanged += Person_OnNotifyPropertyChanged; //add event handler for property changes
                scoresList.Add(newScore);
            }
        }

        //Observable collections for each view model
        ObservableCollection<ScoreGenericViewModel> scoresList
           = new ObservableCollection<ScoreGenericViewModel>();

        //getters/setter for the list
        public ObservableCollection<ScoreGenericViewModel> ScoresCollection
        {
            get { return scoresList; }
            set { SetProperty(ref scoresList, value); }
        }

        //Gets the variables sent from the Add method in SetHighScore.xaml.cs and passes them on to our score organizer
        public void Add(string user, string difficulty, int score, int gridSize)
        {
            insertOrganizer.Add(user, difficulty, score, gridSize);
        }
    }
}

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
    public class ScoreOrganizerViewModel : VMHelper
    {
        ScoreOrganizer organizer;

        public ScoreOrganizerViewModel(int choosenTable)
        {
            organizer = new ScoreOrganizer(choosenTable);
            _SelectedIndex = -1;
           
            foreach (var score in organizer.scores)
            {
                var newScore = new ScoreViewModel(score);
                newScore.PropertyChanged += Person_OnNotifyPropertyChanged;
                _Scores.Add(newScore);
            }
        }

        ObservableCollection<ScoreViewModel> _Scores
           = new ObservableCollection<ScoreViewModel>();

        public ObservableCollection<ScoreViewModel> ScoresCollection
        {
            get { return _Scores; }
            set { SetProperty(ref _Scores, value); }
        }

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
        }

        public void Add()
        {
            var score = new ScoreViewModel();
            score.PropertyChanged += Person_OnNotifyPropertyChanged;
            ScoresCollection.Add(score);
            organizer.Add(score);
            SelectedIndex = ScoresCollection.IndexOf(score);
        }

        public void Delete()
        {
            if (SelectedIndex != -1)
            {
                var score = ScoresCollection[SelectedIndex];
                ScoresCollection.RemoveAt(SelectedIndex);
                organizer.Delete(score);
            }
        }

        void Person_OnNotifyPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            organizer.Update((ScoreViewModel)sender);
        }
    }
}

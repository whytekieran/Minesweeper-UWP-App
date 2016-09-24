using System;
using MineSweeper.Data;

namespace MineSweeper.ViewModels
{
    //View model that wraps the Score model class to fire notifications when properties change
    public class ScoreViewModel : VMHelper<Score>
    {
        public ScoreViewModel(Score score = null) : base(score) { }

        public String Username
        {
            get { return This.Username; }
            //Set property lambda expression trigger anonomous method. Then [CallerNameMember] can check what triggered it then
            //change that property. In this case the property would be Username
            set { SetProperty(This.Username, value, () => This.Username = value); }
        }

        public int UserScore
        {
            get { return This.UserScore; }
            set { SetProperty(This.UserScore, value, () => This.UserScore = value); }
        }
    }
}

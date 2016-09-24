using System;
using MineSweeper.Data;

namespace MineSweeper.ViewModels
{
    public class ScoreViewModel : VMHelper<Score>
    {
        public ScoreViewModel(Score score = null) : base(score) { }

        public String Username
        {
            get { return This.Username; }
            set { SetProperty(This.Username, value, () => This.Username = value); }
        }

        public int UserScore
        {
            get { return This.UserScore; }
            set { SetProperty(This.UserScore, value, () => This.UserScore = value); }
        }
    }
}

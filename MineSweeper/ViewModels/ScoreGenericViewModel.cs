using MineSweeper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.ViewModels
{
    //View model that wraps the Score model class to fire notifications when properties change
    public class ScoreGenericViewModel : VMHelper<ScoreGeneric>
    {
        public ScoreGenericViewModel(ScoreGeneric score = null) : base(score) { }

        public int Id
        {
            get { return This.Id; }
            //Set property lambda expression trigger anonomous method. Then [CallerNameMember] can check what triggered it then
            //change that property. In this case the property would be Username
            set { SetProperty(This.Id, value, () => This.Id = value); }
        }

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

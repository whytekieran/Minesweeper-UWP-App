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

        public int id
        {
            get { return This.id; }
            //Set property lambda expression trigger anonomous method. Then [CallerNameMember] can check what triggered it then
            //change that property. In this case the property would be Username
            set { SetProperty(This.id, value, () => This.id = value); }
        }

        public String username
        {
            get { return This.username; }
            //Set property lambda expression trigger anonomous method. Then [CallerNameMember] can check what triggered it then
            //change that property. In this case the property would be Username
            set { SetProperty(This.username, value, () => This.username = value); }
        }

        public int userscore
        {
            get { return This.userscore; }
            set { SetProperty(This.userscore, value, () => This.userscore = value); }
        }
    }
}

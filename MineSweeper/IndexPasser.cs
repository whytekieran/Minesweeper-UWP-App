using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    //Simple class allows us to take the index of a choose intem on one page and pass it to another page using the
    //onNavigatedTo() method
    class IndexPasser
    {
        public int index { get; set; }
    }
}

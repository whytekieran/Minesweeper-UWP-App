using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    //Simple class to hold information about each game rule so we can add them to list item source using binding
    class RulesSetter
    {
        public string ruleID { get; set; }
        public string ruleDescription { get; set; }
    }
}

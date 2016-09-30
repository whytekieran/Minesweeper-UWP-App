using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Data
{
    //ScoreGeneric class is responsible for retrieving from the database as every class follows this pattern. Reduces code,
    //no need to have lists for every class.
    public class ScoreGeneric
    {
        //Each high score has a username and score and id for the database
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String username { get; set; }
        public int userscore { get; set; }
    }


    //Score classes acts as a basic model to hold score objects for each score table, 
    //need a different class for each SQLite table because whatever the class name will be same name for the table
    //Naming is done like so EScore6 are highscores for Easy-6Grid games. M is medium, H is hard
    public class EScore6
    {
        //Each high score has a username and score and id for the database
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String username { get; set; }
        public int userscore { get; set; }
    }

    public class EScore8
    {
        //Each high score has a username and score and id for the database
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String username { get; set; }
        public int userscore { get; set; }
    }

    public class EScore10
    {
        //Each high score has a username and score and id for the database
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String username { get; set; }
        public int userscore { get; set; }
    }

    public class MScore6
    {
        //Each high score has a username and score and id for the database
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String username { get; set; }
        public int userscore { get; set; }
    }

    public class MScore8
    {
        //Each high score has a username and score and id for the database
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String username { get; set; }
        public int userscore { get; set; }
    }

    public class MScore10
    {
        //Each high score has a username and score and id for the database
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String username { get; set; }
        public int userscore { get; set; }
    }

    public class HScore6
    {
        //Each high score has a username and score and id for the database
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String username { get; set; }
        public int userscore { get; set; }
    }

    public class HScore8
    {
        //Each high score has a username and score and id for the database
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String username { get; set; }
        public int userscore { get; set; }
    }

    public class HScore10
    {
        //Each high score has a username and score and id for the database
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String username { get; set; }
        public int userscore { get; set; }
    }
}

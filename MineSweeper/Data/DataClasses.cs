using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Data
{
    public class ScoreGeneric
    {
        //Each high score has a username and score and id for the database
        [PrimaryKey, AutoIncrement]
        private int id { get; set; }
        private String username;
        private int userScore;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Username
        {
            get { return username; }
            set { username = value; }
        }

        public int UserScore
        {
            get { return userScore; }
            set { userScore = value; }
        }
    }


    //Score classes acts as a basic model to hold score objects for each score table, need a different class for each SQLite table
    public class EScore6
    {
        //Each high score has a username and score and id for the database
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Username { get; set; }
        public int UserScore { get; set; }
    }

    public class EScore8
    {
        //Each high score has a username and score and id for the database
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Username { get; set; }
        public int UserScore { get; set; }
    }

    public class EScore10
    {
        //Each high score has a username and score and id for the database
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Username { get; set; }
        public int UserScore { get; set; }
    }

    public class MScore6
    {
        //Each high score has a username and score and id for the database
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Username { get; set; }
        public int UserScore { get; set; }
    }

    public class MScore8
    {
        //Each high score has a username and score and id for the database
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Username { get; set; }
        public int UserScore { get; set; }
    }

    public class MScore10
    {
        //Each high score has a username and score and id for the database
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Username { get; set; }
        public int UserScore { get; set; }
    }

    public class HScore6
    {
        //Each high score has a username and score and id for the database
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Username { get; set; }
        public int UserScore { get; set; }
    }

    public class HScore8
    {
        //Each high score has a username and score and id for the database
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Username { get; set; }
        public int UserScore { get; set; }
    }

    public class HScore10
    {
        //Each high score has a username and score and id for the database
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Username { get; set; }
        public int UserScore { get; set; }
    }
}

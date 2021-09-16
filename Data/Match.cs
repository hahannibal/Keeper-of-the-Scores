using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper_of_the_Scores
{
    class Match
    {
        private Team _team1;

        public Team Team1
        {
            get { return _team1; }
            set { _team1 = value; }
        }

        private Team _team2;

        public Team Team2
        {
            get { return _team2; }
            set { _team2 = value; }
        }

        private List<Score> _team1Scores;

        public List<Score> Team1Scores
        {
            get { return _team1Scores; }
            set { _team1Scores = value; }
        }

        private List<Score> _team2Scores;

        public List<Score> Team2Scores
        {
            get { return _team2Scores; }
            set { _team2Scores = value; }
        }

        private string _refName;

        public string RefName
        {
            get { return _refName; }
            set { _refName = value; }
        }

    }
}

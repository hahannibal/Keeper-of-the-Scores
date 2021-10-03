using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper_of_the_Scores
{
    public class Match
    {
        public override string ToString()
        {
            return $"{Team1} vs {Team2}";
        }

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

        private List<Score> _scores;

        public List<Score> Scores
        {
            get { return _scores; }
            set { _scores = value; }
        }

        private string _refName;

        public string RefName
        {
            get { return _refName; }
            set { _refName = value; }
        }

    }
}

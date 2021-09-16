using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper_of_the_Scores
{
    class Team
    {
        private string _teamName;

        public string TeamName
        {
            get { return _teamName; }
            set { _teamName = value; }
        }

        private string _nationality;

        public string Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }

        private List<Player> _players;

        public List<Player> Players
        {
            get { return _players; }
            set { _players = value; }
        }

    }
}

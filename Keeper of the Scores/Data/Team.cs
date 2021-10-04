using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper_of_the_Scores
{
    public class Team
    {
        public override string ToString()
        {
            return $"{TeamName}";
        }
        private string _teamName;

        public string TeamName
        {
            get { return _teamName; }
            set { _teamName = value; }
        }

        private List<Player> _players;

        public List<Player> Players
        {
            get { return _players; }
            set { _players = value; }
        }

    }
}

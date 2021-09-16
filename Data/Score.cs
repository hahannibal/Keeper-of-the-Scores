using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper_of_the_Scores
{
    class Score
    {
        private Player _scorer;

        public Player Scorer
        {
            get { return _scorer; }
            set { _scorer = value; }
        }

        private Player _assister;

        public Player Assister
        {
            get { return _scorer; }
            set { _scorer = value; }
        }

        private DateTime _dateTime;

        public DateTime DateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }


    }
}

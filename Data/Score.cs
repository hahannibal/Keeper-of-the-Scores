using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper_of_the_Scores
{
    public class Score
    {
        public override string ToString()
        {
            return $"Scorer:{Scorer}; Assist:{Assist}";
        }
        private Player _scorer;

        public Player Scorer
        {
            get { return _scorer; }
            set { _scorer = value; }
        }

        private Player _assist;

        public Player Assist
        {
            get { return _assist; }
            set { _assist = value; }
        }


        private DateTime _dateTime;

        public DateTime DateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }


    }
}

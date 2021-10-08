using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper_of_the_Scores.Data
{
    public class Options
    {
        public override string ToString()
        {
            return $"Settings!";
        }
        private string _apiKey;

        public string ApiKey
        {
            get { return _apiKey; }
            set { _apiKey = value; }
        }

        private string _teamSheetsID;

        public string TeamSheetsID
        {
            get { return _teamSheetsID; }
            set { _teamSheetsID = value; }
        }
    }
}

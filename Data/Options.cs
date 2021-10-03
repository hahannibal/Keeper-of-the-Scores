using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper_of_the_Scores.Data
{
    class Options
    {
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

        private string _savedTeamFile;

        public string SavedTeamsFile
        {
            get { return _savedTeamFile; }
            set { _savedTeamFile = value; }
        }

        private string _savedMatchFile;

        public string SavedMatchFile
        {
            get { return _savedMatchFile; }
            set { _savedMatchFile = value; }
        }


    }
}

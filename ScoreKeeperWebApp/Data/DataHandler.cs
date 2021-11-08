using System;
using System.Collections.Generic;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using System.IO;
using System.Xml.Serialization;

namespace ScoreKeeperWebApp.Data
{
    public class DataHandler
    {

        public DataHandler()
        {
            //ReadSettings();
            //ReadData();
            LoadTeams();
        }

        private Match _currentMatch;

        public Match CurrentMatch
        {
            get { return _currentMatch; }
            set { _currentMatch = value; }
        }


        private Options _settings;
        public Options Settings
        {
            get { return _settings; }
            set { _settings = value; }
        }

        private List<Team> _teamList;

        public List<Team> TeamList
        {
            get { return _teamList; }
            set { _teamList = value; }
        }
        private string _savedTeams = "Teams.xml";
        private string _savedMatches = "Matches.xml";
        public List<Match> savedMatches = new List<Match>();

        /// <summary>
        /// Reads the data from the goolge sheets
        /// </summary>
        /// <returns>A list of the teams with the players as Team objects list</returns>
        public void ReadData()
        {
            var apikey = Settings.ApiKey;
            var service = new SheetsService(new BaseClientService.Initializer
            {
                ApplicationName = "Keeper of the Score",
                ApiKey = apikey,
            });


            List<Team> teams = new List<Team>();

            var teamNameRange = $"teams!B1:1";
            var TeamName = service.Spreadsheets.Values.Get(Settings.TeamSheetsID, teamNameRange).Execute().Values;
            
            var range = $"teams!B2:ZZ";
            var PlayerNames = service.Spreadsheets.Values.Get(Settings.TeamSheetsID, range).Execute().Values;
            int counter = TeamName[0].Count; //counting the columns to get the number of teams;
            
            for (int i = 0; i < counter; i++) 
            {
                Team newTeam = new Team();

                newTeam.Players = new List<Player>();
                newTeam.TeamName = TeamName[0][i] as string;

                Console.WriteLine(newTeam.TeamName);
                foreach (var playerRow in PlayerNames)
                {
                    Player player = new Player();
                    if (playerRow.Count > i && playerRow[i] as string != "")
                    {
                        player.Name = playerRow[i] as string;
                        newTeam.Players.Add(player);
                    }
                }
                teams.Add(newTeam);



            }
            TeamList = teams;
            
        }

        /// <summary>
        /// Saving teams to an xml file
        /// </summary>
        public void SaveTeams(List<Team> teams)
        {
            if (File.Exists(_savedTeams) == false)
            {
                var filestream = File.Create(_savedTeams);
                filestream.Close();
            }
            var stream = new FileStream(_savedTeams, FileMode.Create);
            new XmlSerializer(typeof(List<Team>)).Serialize(stream, teams);
            stream.Close();
        }

        /// <summary>
        /// saving matches to an xml file
        /// </summary>
        public void SaveMatches()
        {
            if (File.Exists(_savedMatches) == false)
            {
                var filestream = File.Create(_savedMatches);
                filestream.Close();
            }
            var stream = new FileStream(_savedMatches, FileMode.Create);
            new XmlSerializer(typeof(List<Match>)).Serialize(stream, savedMatches);
            stream.Close();
        }

        /// <summary>
        /// loading matches to savedMatches for adding new ones to the list and to be able to check the history of matches
        /// </summary>
        public void LoadHistory()
        {
            if (File.Exists(_savedMatches))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Match>));
                TextReader reader = new StreamReader(_savedMatches);
                object obj = deserializer.Deserialize(reader);
                savedMatches = (List<Match>)obj;
                reader.Close();
            }
        }



        /// <summary>
        /// reading the settings/api key
        /// </summary>

        public void ReadSettings()
        {
                XmlSerializer deserializer = new XmlSerializer(typeof(Options));
                TextReader reader = new StreamReader("..\\ScoreKeeperWebApp\\Data\\XML\\settings.xml");
                object obj = deserializer.Deserialize(reader);
                _settings = (Options)obj;
                reader.Close();
            
        }

        /// <summary>
        /// Loading saved teams from XML file
        /// </summary>
        public void LoadTeams()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Team>));
            TextReader reader = new StreamReader("..\\ScoreKeeperWebApp\\Data\\XML\\Teams.xml");
            object obj = deserializer.Deserialize(reader);
            _teamList = (List<Team>)obj;
            reader.Close();
        }

        public void RemoveLast(Match currentMatch)
        {
            if (currentMatch.Scores.Count > 0)
            {
                currentMatch.Scores.RemoveAt(currentMatch.Scores.Count - 1);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using System.IO;
using System.Xml.Serialization;

namespace Keeper_of_the_Scores.Data
{
    public class DataHandler
    {
        /// <summary>
        /// Reads the data from the goolge sheets
        /// </summary>
        /// <returns>A list of the teams with the players as Team objects list</returns>
        public static List<Team> ReadData()
        {
            var apikey = File.ReadAllText("C:\\Users\\Tamas Kiss\\Desktop\\KoTS\\apikey.txt");
            var service = new SheetsService(new BaseClientService.Initializer
            {
                ApplicationName = "Keeper of the Score",
                ApiKey = apikey,
            });


            List<Team> teams = new List<Team>();

            var teamNameRange = $"teams!B1:1";
            var TeamName = service.Spreadsheets.Values.Get("1CUdylUqw3e3xnD0EYyIbzjwvDpqsIOIlK-edbQjgtOk", teamNameRange).Execute().Values;
            
            var range = $"teams!B2:ZZ";
            var PlayerNames = service.Spreadsheets.Values.Get("1CUdylUqw3e3xnD0EYyIbzjwvDpqsIOIlK-edbQjgtOk", range).Execute().Values;
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
            return teams;
        }
        private static string _savedTeams = "Teams.xml";
        private static string _savedMatches = "Matches.xml";
        public static List<Match> savedMatches = new List<Match>();

        /// <summary>
        /// Saving teams to an xml file
        /// </summary>
        public static void SaveTeams()
        {
            if (File.Exists(_savedTeams) == false)
            {
                var filestream = File.Create(_savedTeams);
                filestream.Close();
            }
            var stream = new FileStream(_savedTeams, FileMode.Create);
            new XmlSerializer(typeof(List<Team>)).Serialize(stream, ReadData());
            stream.Close();
        }

        /// <summary>
        /// saving matches to an xml file
        /// </summary>
        public static void SaveMatches()
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
        /// loading matches to savedMatches for adding new ones to the list and to be able to be able to check the history of matches
        /// </summary>
        public static void LoadHistory()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Match>));
            TextReader reader = new StreamReader(_savedMatches);
            object obj = deserializer.Deserialize(reader);
            savedMatches = (List<Match>)obj;
            reader.Close();
        }
    }
}

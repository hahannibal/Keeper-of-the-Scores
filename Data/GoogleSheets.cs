using System;
using System.Collections.Generic;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using System.IO;

namespace Keeper_of_the_Scores.Data
{
    public class GoogleSheets
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
            
            var range = $"teams!B2:AZ";
            var PlayerNames = service.Spreadsheets.Values.Get("1CUdylUqw3e3xnD0EYyIbzjwvDpqsIOIlK-edbQjgtOk", range).Execute().Values;
            int counter = TeamName[0].Count - 1; //counting the columns; -1, as the first column is the header
            
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

    }
}

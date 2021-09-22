using System;
using System.Collections.Generic;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using System.IO;

namespace Keeper_of_the_Scores.Data
{
    class GoogleSheets
    {
        public static List<Team> ReadData()
        {
            var apikey = File.ReadAllText("C:\\Users\\Tamas Kiss\\Desktop\\KoTS\\apikey.txt");
            var service = new SheetsService(new BaseClientService.Initializer
            {
                ApplicationName = "Keeper of the Score",
                ApiKey = apikey,
            });


            List<Team> teams = new List<Team>();

            var teamNameRange = $"teams!B1:T1";
            var teamNameRequest = service.Spreadsheets.Values.Get("1CUdylUqw3e3xnD0EYyIbzjwvDpqsIOIlK-edbQjgtOk", teamNameRange).Execute().Values;
            var range = $"teams!B2:T30";
            var request = service.Spreadsheets.Values.Get("1CUdylUqw3e3xnD0EYyIbzjwvDpqsIOIlK-edbQjgtOk", range).Execute().Values;
            var counter = service.Spreadsheets.Values.Get("1CUdylUqw3e3xnD0EYyIbzjwvDpqsIOIlK-edbQjgtOk", $"teams!A30").Execute().Values;
            int counterNumber = 0; 
            foreach (var row in counter)
            {
                int i =Int32.Parse(row[0] as string);
                counterNumber = i;
            }
            
            


            for (int i = 0; i < counterNumber; i++) //it doesn't read the last team, have to fix it! 
            {
                Team newTeam = new Team();
                newTeam.Players = new List<Player>();

                foreach (var row in teamNameRequest)
                {
                    newTeam.TeamName = row[i] as string;
                }
                foreach (var playerRow in request)
                {
                    Player player = new Player();
                    player.Name = playerRow[i] as string;
                    newTeam.Players.Add(player);
                }
                teams.Add(newTeam);
                

                
            }
            return teams;
            }

    }
}

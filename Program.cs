using System;
using System.Collections.Generic;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using System.IO;

namespace Keeper_of_the_Scores
{
    class Program
    {
        static void Main(string[] args)
        {
            Match newMatch = new Match();
            List<Team> teams = Data.DataHandler.ReadData();
            Data.DataHandler.SaveTeams(teams);
            Score newScore = new Score();
            newScore.Scorer = teams[18].Players[0];
            newScore.Assist = teams[18].Players[1];
            newScore.DateTime = DateTime.Now;

            newMatch.Team1 = teams[18];
            newMatch.Team2 = teams[1];
            newMatch.RefName = "testing";
            newMatch.Scores = new List<Score>();
            newMatch.Scores.Add(newScore);
            Data.DataHandler.savedMatches.Add(newMatch);
            Data.DataHandler.SaveMatches();

            Console.WriteLine($"{teams[18].TeamName} vs {teams[1].TeamName}");
            Console.WriteLine($"Wow! {newScore.Scorer.Name} scored with the help of {newScore.Assist.Name} at {newScore.DateTime}");

        }
    }
}

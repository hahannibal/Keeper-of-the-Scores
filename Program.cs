using System;
using System.Collections.Generic;

namespace Keeper_of_the_Scores
{
    class Program
    {
        static void Main(string[] args)
        {
            Teams team1 = new Teams();
            team1.Nationality = "Hungarian";
            team1.TeamName = "Hungary";
            Players hungarianPlayer1 = new Players();
            Players hungarianPlayer2 = new Players();
            hungarianPlayer1.Name = "Tamas";
            hungarianPlayer1.Number = 21;
            hungarianPlayer2.Name = "Dani";
            hungarianPlayer2.Number = 17;
            team1.players.Add(hungarianPlayer1);
            team1.players.Add(hungarianPlayer2);

            Teams team2 = new Teams();
            team2.Nationality = "Austrian";
            team2.TeamName = "Austria";
            Players austrianPlayer1 = new Players();
            Players austrianPlayer2 = new Players();
            austrianPlayer1.Name = "Florian";
            austrianPlayer1.Number = 07;
            austrianPlayer2.Name = "Levi";
            austrianPlayer2.Number = 13;
            team2.players.Add(austrianPlayer1);
            team2.players.Add(austrianPlayer2);

            Console.WriteLine($"{team1.TeamName} vs {team2.TeamName}");

            Score score = new Score();

            score.assister = team1.players[0];
            score.scorer = team1.players[1];
            score.dateTime = DateTime.Now;
            score.team = team1.TeamName;

            List<Score> team1Score = new List<Score>();
            List<Score> team2Score = new List<Score>();
            team1Score.Add(score);

            Console.WriteLine($"Wow! {score.scorer.Name} just made a point with the help of {score.assister.Name} for {score.team}! The current score is: {team1Score.Count} : {team2Score.Count}");
            Console.WriteLine($"This happened at {score.dateTime}");

        }
    }
}

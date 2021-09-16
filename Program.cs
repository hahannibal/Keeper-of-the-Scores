using System;
using System.Collections.Generic;

namespace Keeper_of_the_Scores
{
    class Program
    {
        static void Main(string[] args)
        {
            Match match = new Match();

            Team team1 = new Team();
            team1.Nationality = "Hungarian";
            team1.TeamName = "Hungary";
            
            Player hungarianPlayer1 = new Player();
            hungarianPlayer1.Name = "Tamas";
            hungarianPlayer1.Number = 21;

            Player hungarianPlayer2 = new Player();
            hungarianPlayer2.Name = "Dani";
            hungarianPlayer2.Number = 17;
            
            team1.Players.Add(hungarianPlayer1);
            team1.Players.Add(hungarianPlayer2);

            match.Team1 = team1;

            Team team2 = new Team();
            team2.Nationality = "Austrian";
            team2.TeamName = "Austria";
            
            Player austrianPlayer1 = new Player();
            austrianPlayer1.Name = "Florian";
            austrianPlayer1.Number = 07;

            Player austrianPlayer2 = new Player();
            austrianPlayer2.Name = "Levi";
            austrianPlayer2.Number = 13;

            team2.Players.Add(austrianPlayer1);
            team2.Players.Add(austrianPlayer2);

            match.Team2 = team2;

            Console.WriteLine($"{match.Team1.TeamName} vs {match.Team2.TeamName}");

            Score score = new Score();

            score.Assister = team1.Players[0];
            score.Scorer = team1.Players[1];
            score.DateTime = DateTime.Now;

            List<Score> team1Score = new List<Score>();
            List<Score> team2Score = new List<Score>();

            team1Score.Add(score);

            Console.WriteLine($"Wow! {score.Scorer.Name} just made a point with the help of {score.Assister.Name} for {team1.TeamName}! The current score is: {team1Score.Count} : {team2Score.Count}");
            Console.WriteLine($"This happened at {score.DateTime}");

            match.Team1Scores = team1Score;
            match.Team2Scores = team2Score;



        }
    }
}

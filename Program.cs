﻿using System;
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
            List<Team> teams = Data.GoogleSheets.ReadData();
            Console.WriteLine($"{teams[0].TeamName} vs {teams[1].TeamName}");
            Console.WriteLine($"Wow! {teams[0].Players[0].Name} scored with the help of {teams[0].Players[1].Name}");

        }
    }
}

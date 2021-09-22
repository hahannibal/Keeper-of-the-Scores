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
            var apikey = File.ReadAllText("C:\\Users\\Tamas Kiss\\Desktop\\KoTS\\apikey.txt");
            var service = new SheetsService(new BaseClientService.Initializer
            {
                ApplicationName = "Keeper of the Score",
                ApiKey = apikey,
            });

            SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get("1CUdylUqw3e3xnD0EYyIbzjwvDpqsIOIlK-edbQjgtOk", "B2:B20");
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            foreach (var row in values)
            {
                Console.WriteLine(row[0]);
            }
        }
    }
}

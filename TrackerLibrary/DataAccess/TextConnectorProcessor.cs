using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextConnect
{
    /// <summary>
    /// Contains extension methods and different namespace to keep those extension methods seperated
    /// 
    /// </summary>
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string fileName) 
        {
            //C:\Users\PawelBel\Desktop\CODES\PrizeModels.csv
            string a = ConfigurationManager.AppSettings["filePath"]; //look for the key "filePath"
            return a + $"\\{ fileName }" ;
        }

        public static List<string> LoadFile(this string file)//read all the lines from file or create a new one
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {

            List<PrizeModel> output = new List<PrizeModel>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(','); //string splits on ,

                PrizeModel p = new PrizeModel();
                p.Id = int.Parse(cols[0]); //first column will be an Id
                p.PlaceNumber = int.Parse(cols[0]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);
                output.Add(p);
            }
            return output;
        }
        public static List<PersonModel> ConvertToPersonModel(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();
            foreach (var line in lines)
            {
                string[] columns = line.Split(',');

                PersonModel p = new PersonModel();
                p.Id = int.Parse(columns[0]);
                p.Firstname = columns[1];
                p.LastName = columns[2];
                p.EmailAddres = columns[3];
                p.PhoneNumber = columns[4];
                output.Add(p);
            }
            return output;
        }

        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)//this
        {
            List<string> lines = new List<string>();
            foreach (PrizeModel p in models)//convert models to a list of strings
            {
                lines.Add($"{ p.Id },{p.PlaceNumber},{ p.PlaceName },{ p.PrizeAmount },{ p.PrizePercentage }");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);//write all the lines to a file;
        }
        public static void SaveToPeopleFile(this List<PersonModel> models, string fileName)
        {
            List<string> lines = new List<string>();
            foreach (var p in models)
            {
                lines.Add($"{p.Id },{p.Firstname},{p.LastName},{p.EmailAddres},{p.PhoneNumber}");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
    }
}

using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
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
    }
}

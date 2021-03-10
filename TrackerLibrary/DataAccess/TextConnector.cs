using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary.DataAccess
{
    class TextConnector : IDataConnection
    {
        // TODO - Wire up teh CreatePrize for text file

        //comma-separated values file is a delimited text file that uses a comma 
        //to separate values.Each line of the file is a data record.
        private const string PrizesFile = "PrizeModels.csv"; 
        public PrizeModel CreatePrize(PrizeModel model)
        {
            //load the text file
            //Convert the text to List<PrizeModel>
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels(); //find full file path of PF, load it and convert to a Prize models

            int currentId = prizes.OrderByDescending(x => x.Id).First().Id;//Find the max ID
            model.Id = (currentId + 1);

            //Add the new record with the new ID
            prizes.Add(model);

            //Convert the prizes to list<string>
            //Save the list<string> to the text file
            prizes.SaveToPrizeFile(PrizesFile);//data saved to a text file. File will be override

            return model; //this model is fully formed with the Id 
        }
    }
}

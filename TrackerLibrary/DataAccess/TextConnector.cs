using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    class TextConnector : IDataConnection
    {
        // TODO - Wire up teh CreatePrize for text file
        public PrizeModel CreatePrize(PrizeModel model)
        {
            //load the text file
            //Convert the text to List<PrizeModel>
            //Find the ID
            //Add the new record with the new ID
            //Convert the prizes to list<string>
            //Save the list<string> to the text file
            return model;
        }
    }
}

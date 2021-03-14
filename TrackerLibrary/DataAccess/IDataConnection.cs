using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public interface IDataConnection
    {
        PrizeModel CreatePrize(PrizeModel model);
        PersonModel CreatePerson(PersonModel model);
    }
}
//whoever implements IDataConnection will have a method called CreatePrize()
//but code in the method may be different
//We cal CreatePrize() and pass it PrizeModel and you get back a PrizeModel
//
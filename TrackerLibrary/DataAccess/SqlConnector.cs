using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

//@PlaceNumber int,
//	 @PlaceName nvarchar(250),
//	 @PrizeAmount money,
//    @PrizePercentage float,
//     @id int = 0 output

namespace TrackerLibrary.DataAccess
{
    class SqlConnector : IDataConnection
    {
        //TODO - Make the CreatePrize method actally save to the database
        /// <summary>
        /// Saves a new prize to the db
        /// </summary>
        /// <param name="model">The prize information</param>
        /// <returns>The prize information, including unique ID</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            //prevents memory loss
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
            {
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@PrizeAmount", model.PrizeAmount);
                p.Add("@PrizePercentage", model.PrizePercentage);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output); //id here is an output variable

                connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);  //run store procedure asssumin that thers no data coming back. For more rows Query not execute

                model.Id = p.Get<int>("@id"); //how to get this back using dapper

                return model;
 
            }
            return model;
        }
    }
}

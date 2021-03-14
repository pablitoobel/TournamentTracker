using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;
using System.Configuration;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }
        //so we use list because there can be more than one way to save data
        //plans have changed we use one of them.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public static void InitializeConnections(DatabaseType db) //bool bool to enum change
        {

            if (db == DatabaseType.Sql)
            {
                //TODO -vset up the SQL Connector properly
                SqlConnector sql = new SqlConnector();
                Connection = sql;
            }
            else if (db == DatabaseType.TextFile)
            {
                // TODO - Create the Text connection
                TextConnector txt = new TextConnector();
                Connection = txt;
            }
        }
        /// <summary>
        /// Pass string name for database to get connection String
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CnnString (string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
    //only method inside GlobalConfig can change it's items but everyone can read the value of Connections
}


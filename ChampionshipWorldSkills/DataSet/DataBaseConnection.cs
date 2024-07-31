using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ChampionshipWorldSkills.DataSet
{
    static class DataBaseConnection
    {
        public static SqlConnection Connection;

        public static void Connecting()
        {
            try
            {
                Connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
                Connection.Open();
            }
            catch
            {
                throw;
            }
        }
    }
}

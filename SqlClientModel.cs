using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AuthorizationApp
{
    public static class SqlClientModel
    {
        private static string _connectionString = "Data source = MANUCHO; initial catalog=MTUCI; integrated security=true";

        public static SqlConnection GetNewSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
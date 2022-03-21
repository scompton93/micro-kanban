using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace micro_kanban.Data
{
    public class SqlDataAccess
    {
        public string GetConnectionString(string name)
        {
            return File.ReadAllText("connstring.txt");
        }

        public List<T> LoadData<T, U>(string storedProceure, U parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(storedProceure, parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        public void SaveData<T>(string storedProceure, T parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection())
            {
                connection.Execute(storedProceure, parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}

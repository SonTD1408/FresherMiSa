using MISA.Fresher.API.Config;
using MISA.Fresher.API.Entities;
using MySqlConnector;
using Dapper;

namespace MISA.Fresher.API.Repositories
{
    public class InComeRepository
    {
        public List<InComes> getAll()
        {
            var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING);
            string sql = "select  * from Incomes";
            var res = mysqlConnection.Query<InComes>(sql);
            return res.ToList();
        }
    }
}

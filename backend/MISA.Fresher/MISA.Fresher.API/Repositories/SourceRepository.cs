using MISA.Fresher.API.Config;
using MISA.Fresher.API.Entities;
using MySqlConnector;
using Dapper;

namespace MISA.Fresher.API.Repositories
{
    public class SourceRepository
    {
        public List<Sources> getAll() {
            var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING);
            string sql = "select  * from Sources";
            var res = mysqlConnection.Query<Sources>(sql);
            return res.ToList();
        }
    }
}

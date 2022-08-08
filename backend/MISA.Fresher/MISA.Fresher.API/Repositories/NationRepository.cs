using MySqlConnector;
using Dapper;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Config;

namespace MISA.Fresher.API.Repositories
{
    public class NationRepository
    {
        public List<Nations> getAll()
        {
            var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING);
            string sql = "select * from Nations";
            var result = mysqlConnection.Query<Nations>(sql);
            return result.ToList();
        }
    }
}

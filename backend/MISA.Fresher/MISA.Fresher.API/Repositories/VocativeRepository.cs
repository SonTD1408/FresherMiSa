using MySqlConnector;
using Dapper;
using MISA.Fresher.API.Config;
using MISA.Fresher.API.Entities;

namespace MISA.Fresher.API.Repositories
{
    public class VocativeRepository
    {
        public List<Vocatives> getAll()
        {
            var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING);
            string sql = "select * from Vocatives";
            var result = mysqlConnection.Query<Vocatives>(sql);
            return result.ToList();
        }

    }
}

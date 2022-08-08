using MySqlConnector;
using Dapper;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Config;

namespace MISA.Fresher.API.Repositories
{
    public class CityRepository
    {
        public List<Cities> getAll(int nationID)
        {
            var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING);
            string sql = $"select * from Cities where NationID = {nationID}";
            var result = mysqlConnection.Query<Cities>(sql);
            return result.ToList();
        }
    }
}

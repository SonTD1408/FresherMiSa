using MySqlConnector;
using Dapper;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Config;

namespace MISA.Fresher.API.Repositories
{
    public class DistrictRepository
    {
        public List<Districts> getAll(int cityID)
        {
            var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING);
            string sql = $"select * from Districts where CityID = {cityID}";
            var result = mysqlConnection.Query<Districts>(sql);
            return result.ToList();
        }
    }
}

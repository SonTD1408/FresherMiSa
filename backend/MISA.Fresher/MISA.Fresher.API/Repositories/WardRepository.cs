using MySqlConnector;
using Dapper;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Config;

namespace MISA.Fresher.API.Repositories
{
    public class WardRepository
    {
        public List<Wards> getAll(int districtID)
        {
            var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING);
            string sql = $"select * from Wards where DistrictID = {districtID}";
            var result = mysqlConnection.Query<Wards>(sql);
            return result.ToList();
        }
    }
}

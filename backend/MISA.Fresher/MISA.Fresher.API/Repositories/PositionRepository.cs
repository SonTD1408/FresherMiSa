using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Config;
using MySqlConnector;
using Dapper;

namespace MISA.Fresher.API.Repositories
{
    public class PositionRepository
    {
        public List<Positions> getAll()
        {
            //kết nối db 
            var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING);
            string query = "select * from Positions";
            var result = mysqlConnection.Query<Positions>(query);
            return result.ToList();
        }
    }
}

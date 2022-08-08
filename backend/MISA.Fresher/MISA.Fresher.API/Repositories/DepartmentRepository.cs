using MISA.Fresher.API.Config;
using MySqlConnector;
using Dapper;
using MISA.Fresher.API.Entities;

namespace MISA.Fresher.API.Repositories
{
    public class DepartmentRepository
    {
        public List<Departments> getAll()
        {
            // kết nối db
            var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING);
            string sql = "select * from Departments";
            var result = mysqlConnection.Query<Departments>(sql);
            return result.ToList();
        }
    }
}

using MISA.Fresher.API.Config;
using MISA.Fresher.API.Entities;
using MySqlConnector;
using Dapper;

namespace MISA.Fresher.API.Repositories
{
    public class OrganizationTypeRepository
    {
        public List<OrganizationTypes> getAll()
        {
            var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING);
            string sql = "select  * from OrganizationTypes";
            var res = mysqlConnection.Query<OrganizationTypes>(sql);
            return res.ToList();
        }
    }
}

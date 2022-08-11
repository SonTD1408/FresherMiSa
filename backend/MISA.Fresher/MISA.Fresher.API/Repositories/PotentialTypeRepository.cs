using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Config;
using MySqlConnector;
using Dapper;
namespace MISA.Fresher.API.Repositories
{
    public class PotentialTypeRepository
    {
        public ActionResults<PotentialTypes> get()
        {
            try
            {
                using (var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING))
                {
                    string sql = "select * from PotentialTypes";
                    var res = mysqlConnection.Query<PotentialTypes>(sql);
                    var result = new ActionResults<PotentialTypes>();
                    if (res.Count() != 0)
                    {
                        result.DataList = res.ToList();
                        result.Status = 1;
                        result.StatusMsg = ResultMessage._SUCCESS_MSG;
                    }
                    else
                    {
                        result.Status = 0;
                        result.StatusMsg = ResultMessage._SUCCESS_NULL_MSG;
                    }
                    return result;
                }
            }
            catch (Exception)
            {
                return new ActionResults<PotentialTypes>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._REPOSITORY_EXCEPTION_MSG,
                };
            }
        }
    }
}

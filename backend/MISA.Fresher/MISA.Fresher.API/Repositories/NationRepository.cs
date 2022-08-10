using MySqlConnector;
using Dapper;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Config;
using MISA.Fresher.API.ActionResult;

namespace MISA.Fresher.API.Repositories
{
    public class NationRepository
    {
        /// <summary>
        /// hàm lấy dữ liệu từ bảng Nations
        /// createdby SONTD (10.08.2022)
        /// </summary>
        /// <returns></returns>
        public ActionResults<Nations> getAll()
        {
            try
            {
                using (var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING))
                {
                    //var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING);
                    string sql = "select * from Nations";
                    var result = mysqlConnection.Query<Nations>(sql);
                    if (result.Count() != 0)
                    {
                        var res = new ActionResults<Nations>()
                        {
                            DataList = result.ToList(),
                            Status = 1,
                            StatusMsg = ResultMessage._SUCCESS_MSG
                        };
                        return res;
                    }
                    else
                    {
                        var res = new ActionResults<Nations>()
                        {
                            Status = 1,
                            StatusMsg = ResultMessage._SUCCESS_NULL_MSG
                        };
                        return res;
                    } 
                }
            }
            catch (Exception e)
            {
                return new ActionResults<Nations>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._REPOSITORY_EXCEPTION_MSG
                };
            }
        }
    }
}

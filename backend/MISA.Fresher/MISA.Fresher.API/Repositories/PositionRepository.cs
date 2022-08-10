using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Config;
using MISA.Fresher.API.ActionResult;
using MySqlConnector;
using Dapper;

namespace MISA.Fresher.API.Repositories
{
    public class PositionRepository
    {
        /// <summary>
        /// hàm truy vấn lấy dữ liệu từ bảng chức vụ
        /// createdby SONTD (10.08.2022)
        /// </summary>
        /// <returns></returns>
        public ActionResults<Positions> getAll()
        {
            try
            {
                using (var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING))
                {
                    string sqlString = "select * from Positions";
                    var result = mysqlConnection.Query<Positions>(sqlString);
                    var res = new ActionResults<Positions>();
                    if (result.Count() != 0)
                    {
                        res.DataList = result.ToList();
                        res.Status = 1;
                        res.StatusMsg = ResultMessage._SUCCESS_MSG;
                        return res;
                    }
                    else
                    {
                        res.Status = 1;
                        res.StatusMsg = ResultMessage._SUCCESS_NULL_MSG;
                        return res;
                    }
                }
            }
            catch (Exception)
            {
                return new ActionResults<Positions>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._REPOSITORY_EXCEPTION_MSG
                };
            }
        }
    }
}

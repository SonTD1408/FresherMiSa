using MySqlConnector;
using Dapper;
using MISA.Fresher.API.Config;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.ActionResult;

namespace MISA.Fresher.API.Repositories
{
    public class VocativeRepository
    {
        /// <summary>
        /// hàm truy vấn lấy dữ liệu từ bảng xưng hô
        /// createdby SONTD (10.08.2022)
        /// </summary>
        /// <returns></returns>
        public ActionResults<Vocatives> getAll()
        {
            try
            {
                using (var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING))
                {
                    string sql = "select * from Vocatives";
                    var result = mysqlConnection.Query<Vocatives>(sql);
                    var res = new ActionResults<Vocatives>();
                    if (result.Count() != 0)
                    {
                        res.DataList = result.ToList();
                        res.Status = 1;
                        res.StatusMsg = ResultMessage._SUCCESS_MSG;
                    }
                    else
                    {
                        res.Status = 1;
                        res.StatusMsg = ResultMessage._SUCCESS_NULL_MSG;
                    }
                    return res;
                }
            }
            catch (Exception)
            {
                return new ActionResults<Vocatives>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._REPOSITORY_EXCEPTION_MSG
                };
            }
        }

    }
}

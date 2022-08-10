using MySqlConnector;
using Dapper;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Config;
using MISA.Fresher.API.ActionResult;
using System.Diagnostics;

namespace MISA.Fresher.API.Repositories
{
    public class CityRepository
    {
        /// <summary>
        /// hàm lấy dữ liệu từ bảng Cities
        /// createdby SONTD (10.08.2022)
        /// </summary>
        /// <param name="nationID"></param>
        /// <returns></returns>
        public ActionResults<Cities> getAll(Guid nationID)
        {
            using (var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING))
            {
                try
                {
                    //chuẩn bị query và param 
                    string sql = "select * from Cities where NationID = @NationID";
                    var param = new DynamicParameters();
                    param.Add("@NationID", nationID);

                    //query lấy kết quả từ db
                    var result = mysqlConnection.Query<Cities>(sql, param);
                    if (result.Count() != 0)
                    {
                        var res = new ActionResults<Cities>()
                        {
                            DataList = result.ToList(),
                            Status = 1,
                            StatusMsg = ResultMessage._SUCCESS_MSG
                        };
                        Debug.WriteLine(result);
                        return res;
                    }
                    else
                    {
                        var res = new ActionResults<Cities>()
                        {
                            Status = 1,
                            StatusMsg = ResultMessage._SUCCESS_NULL_MSG
                        };
                        return res;
                    }
                }
                catch (Exception e)
                {
                    return new ActionResults<Cities>()
                    {
                        Status = 0,
                        StatusMsg = ResultMessage._REPOSITORY_EXCEPTION_MSG
                    };
                }
            }
        }
    }
}

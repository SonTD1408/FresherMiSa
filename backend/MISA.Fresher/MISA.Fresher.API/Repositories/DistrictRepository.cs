using MySqlConnector;
using Dapper;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Config;
using MISA.Fresher.API.ActionResult;

namespace MISA.Fresher.API.Repositories
{
    public class DistrictRepository
    {
        /// <summary>
        /// hàm lấy dữ liệu từ bảng Districts
        /// createdby SONTD (10.08.2022)
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public ActionResults<Districts> getAll(Guid cityID)
        {
            using (var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING))
            {
                try
                {
                    //chuẩn bị query và param 
                    string sql = "select * from Districts where CityID = @CityID";
                    var param = new DynamicParameters();
                    param.Add("@CityID", cityID);

                    //query lấy kết quả từ db
                    var result = mysqlConnection.Query<Districts>(sql, param);
                    if (result.Count() != 0)
                    {
                        var res = new ActionResults<Districts>()
                        {
                            DataList = result.ToList(),
                            Status = 1,
                            StatusMsg = ResultMessage._SUCCESS_MSG
                        };
                        return res;
                    }
                    else
                    {
                        var res = new ActionResults<Districts>()
                        {
                            Status = 1,
                            StatusMsg = ResultMessage._SUCCESS_NULL_MSG
                        };
                        return res;
                    }
                }
                catch (Exception e)
                {
                    return new ActionResults<Districts>()
                    {
                        Status = 0,
                        StatusMsg = ResultMessage._REPOSITORY_EXCEPTION_MSG
                    };
                }
            }
        }
    }
}

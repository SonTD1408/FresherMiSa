using MySqlConnector;
using Dapper;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Config;
using MISA.Fresher.API.ActionResult;

namespace MISA.Fresher.API.Repositories
{
    public class WardRepository
    {
        /// <summary>
        /// hàm truy vấn từ bảng Wards
        /// createdby SONTD (10.08.2022)
        /// </summary>
        /// <param name="districtID"></param>
        /// <returns></returns>
        public ActionResults<Wards> getAll(Guid districtID)
        {
            using (var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING))
            {
                try
                {
                    //chuẩn bị query và param 
                    string sql = "select * from Wards where DistrictID = @DistrictID";
                    var param = new DynamicParameters();
                    param.Add("@DistrictID", districtID);

                    //query lấy kết quả từ db
                    var result = mysqlConnection.Query<Wards>(sql, param);
                    if (result.Count() != 0)
                    {
                        var res = new ActionResults<Wards>()
                        {
                            DataList = result.ToList(),
                            Status = 1,
                            StatusMsg = ResultMessage._SUCCESS_MSG
                        };
                        return res;
                    }
                    else
                    {
                        var res = new ActionResults<Wards>()
                        {
                            Status = 1,
                            StatusMsg = ResultMessage._SUCCESS_NULL_MSG
                        };
                        return res;
                    }
                }
                catch (Exception e)
                {
                    return new ActionResults<Wards>()
                    {
                        Status = 0,
                        StatusMsg = ResultMessage._REPOSITORY_EXCEPTION_MSG
                    };
                }
            }
        }
    }
}

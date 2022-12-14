using MISA.Fresher.API.Config;
using MySqlConnector;
using Dapper;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.ActionResult;

namespace MISA.Fresher.API.Repositories
{
    public class DepartmentRepository
    {
        /// <summary>
        /// hàm lấy tất cả  dữ liệu từ bảng Departments
        /// createdby SONTD (10.08.2022)
        /// </summary>
        /// <returns></returns>
        public ActionResults<Departments> GetAll()
        {
            try
            {
                using (var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING))
                {
                    //lệnh truy vấn
                    string sqlString = "select * from Departments";
                    // truy vân dữ liệu
                    var result = mysqlConnection.Query<Departments>(sqlString);
                    //trả dl về service 
                    var res = new ActionResults<Departments>();
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
            catch (Exception e)
            {
                return new ActionResults<Departments>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._REPOSITORY_EXCEPTION_MSG
                };
            }
        }
    }
}

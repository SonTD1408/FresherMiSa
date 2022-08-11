using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Config;
using MySqlConnector;
using Dapper;

namespace MISA.Fresher.API.Repositories
{
    public class CareerSaveRepository
    {
        public ActionResults<Guid> add(CareerSaves careerSaves)
        {
            try
            {
                using(var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING))
                {
                    string sql = "insert into CareerSaves(CareerSaveID, PotentialID, CareerID, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy) " +
                        "values(@CareerSaveID, @PotentialID,@CareerID,@CreatedDate,@CreatedBy,@ModifiedDate,@ModifiedBy)";
                    var param = new DynamicParameters();
                    param.Add("@CareerSaveID", careerSaves.CareerSaveID);
                    param.Add("@PotentialID", careerSaves.PotentialID);
                    param.Add("@CareerID", careerSaves.CareerID);
                    param.Add("@CreatedDate", careerSaves.CreatedDate);
                    param.Add("@CreatedBy", careerSaves.CreatedBy);
                    param.Add("@ModifiedDate",careerSaves.ModifiedDate);
                    param.Add("@ModifiedBy", careerSaves.ModifiedBy);

                    var res = mysqlConnection.Execute(sql, param);
                    var result = new ActionResults<Guid>();
                    if (res > 0)
                    {
                        result.Status = 2;
                        result.StatusMsg = ResultMessage._SUCCESS_MSG;
                        result.Data = careerSaves.CareerSaveID;
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
                return new ActionResults<Guid>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._REPOSITORY_EXCEPTION_MSG,
                }; 
            }
        }
    }
}

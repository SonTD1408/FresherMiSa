using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Config;
using MySqlConnector;
using Dapper;

namespace MISA.Fresher.API.Repositories
{
    public class FieldSaveRepository
    {
        public ActionResults<Guid> add(FieldSaves fieldSaves)
        {
            try
            {
                using (var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING))
                {
                    string sql = "insert into FieldSaves(FieldSaveID, PotentialID, FieldID, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy) " +
                        "values(@FieldSaveID, @PotentialID,@FieldID,@CreatedDate,@CreatedBy,@ModifiedDate,@ModifiedBy)";
                    var param = new DynamicParameters();
                    param.Add("@FieldSaveID", fieldSaves.FieldSaveID);
                    param.Add("@PotentialID", fieldSaves.PotentialID);
                    param.Add("@FieldID", fieldSaves.FieldID);
                    param.Add("@CreatedDate", fieldSaves.CreatedDate);
                    param.Add("@CreatedBy", fieldSaves.CreatedBy);
                    param.Add("@ModifiedDate", fieldSaves.ModifiedDate);
                    param.Add("@ModifiedBy", fieldSaves.ModifiedBy);

                    var res = mysqlConnection.Execute(sql, param);
                    var result = new ActionResults<Guid>();
                    if (res > 0)
                    {
                        result.Status = 2;
                        result.StatusMsg = ResultMessage._SUCCESS_MSG;
                        result.Data = fieldSaves.FieldSaveID;
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

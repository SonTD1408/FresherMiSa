using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Config;
using MySqlConnector;
using Dapper;

namespace MISA.Fresher.API.Repositories
{
    public class PotentialTypeSaveRepository
    {
        public ActionResults<Guid> add(PotentialTypeSaves potentialTypeSaves)
        {
            try
            {
                using (var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING))
                {
                    string sql = "insert into PotentialTypeSaves(PotentialTypeSaveID, PotentialID, PotentialTypeID, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy) " +
                        "values(@PotentialTypeSaveID, @PotentialID,@PotentialTypeID,@CreatedDate,@CreatedBy,@ModifiedDate,@ModifiedBy)";
                    var param = new DynamicParameters();
                    param.Add("@PotentialTypeSaveID", potentialTypeSaves.PotentialTypeSaveID);
                    param.Add("@PotentialID", potentialTypeSaves.PotentialID);
                    param.Add("@PotentialTypeID", potentialTypeSaves.PotentialTypeID);
                    param.Add("@CreatedDate", potentialTypeSaves.CreatedDate);
                    param.Add("@CreatedBy", potentialTypeSaves.CreatedBy);
                    param.Add("@ModifiedDate", potentialTypeSaves.ModifiedDate);
                    param.Add("@ModifiedBy", potentialTypeSaves.ModifiedBy);

                    var res = mysqlConnection.Execute(sql, param);
                    var result = new ActionResults<Guid>();
                    if (res > 0)
                    {
                        result.Status = 2;
                        result.StatusMsg = ResultMessage._SUCCESS_MSG;
                        result.Data = potentialTypeSaves.PotentialTypeSaveID;
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

using MISA.Fresher.API.Entities.DTO;
using MISA.Fresher.API.Config;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.ActionResult;
using MySqlConnector;
using Dapper;
using System.Text.Json;

namespace MISA.Fresher.API.Repositories
{
    public class PotentialRepository
    {
        /// <summary>
        /// hàm truy vấn vào db để lấy dữ liệu bảng potential
        /// </summary>
        /// <param name="skip"></param> bỏ bao nhiêu dl đầu
        /// <param name="take"></param> lấy bao nhiheeu dòng dữ liệu
        /// <param name="where"></param> lọc
        /// <param name="sort"></param> sắp xếp
        /// <returns></returns>
        public ActionResults<Paging> GetAll(int skip, int take, string where, string sort)
        {
            try
            {
                using (var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING))
                {

                    //chuẩn bị proc name
                    var procName = "Proc_Filter_Potentials";
                    //chuẩn bị parameter 
                    var param = new DynamicParameters();
                    param.Add("@$Skip", skip);
                    param.Add("@$Take", take);
                    param.Add("@$Where", where);
                    param.Add("@$Sort", sort);
                    //truy vấn
                    using(var res = mysqlConnection.QueryMultiple(procName, param, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        var paging = new Paging()
                        {
                            PotentialList = res.Read<PotentialDTO>().ToList(),
                            NumberOfRecord = res.Read<long>().Single(),
                        };
                        var result = new ActionResults<Paging>();
                        if (paging.NumberOfRecord > 0)
                        {
                            result.Status = 1;
                            result.StatusMsg = ResultMessage._SUCCESS_MSG;
                        }
                        else
                        {
                            result.StatusMsg = ResultMessage._SUCCESS_NULL_MSG;
                            result.Status = 0;
                        }
                        result.Data = paging;
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                return new ActionResults<Paging>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._REPOSITORY_EXCEPTION_MSG
                };
            }
        }

        /// <summary>
        /// repository truy vấn thêm 1 tiềm năng
        /// created by SONTD (11.08.2022)
        /// </summary>
        /// <param name="potential"></param>
        /// <returns></returns>
        public ActionResults<Guid> Add(Potentials potential)
        {
            try
            {
                using (var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING))
                {
                    // chuẩn bị param
                    var potentialType = JsonSerializer.Serialize(potential.PotentialTypes);
                    var param = new DynamicParameters();
                    param.Add("@PotentialID", potential.PotentialID);
                    param.Add("@PotentialCode", potential.PotentialCode);
                    param.Add("@LastName", potential.LastName);
                    param.Add("@FirstName", potential.FirstName);
                    param.Add("@FullName", potential.FullName);
                    param.Add("@PhoneNumber", potential.PhoneNumber);
                    param.Add("@OfficePhoneNumber", potential.OfficePhoneNumber);
                    param.Add("@OtherPhoneNumber", potential.OtherPhoneNumber);
                    param.Add("@Email", potential.Email);
                    param.Add("@OfficeEmail", potential.OfficeEmail);
                    param.Add("@TaxCode", potential.TaxCode);
                    param.Add("@Zalo", potential.Zalo);
                    param.Add("@Organization", potential.Organization);
                    param.Add("@BankAccount", potential.BankAccount);
                    param.Add("@BankName", potential.BankName);
                    param.Add("@FoundingDate", potential.FoundingDate);
                    param.Add("@Address", potential.Address);
                    param.Add("@NationID", potential.NationID);
                    param.Add("@CityID", potential.CityID);
                    param.Add("@DistrictID", potential.DistrictID);
                    param.Add("@WardID", potential.WardID);
                    param.Add("@ApartmentNumber", potential.ApartmentNumber);
                    param.Add("@RegionCode", potential.RegionCode);
                    param.Add("@PotentialDescription", potential.PotentialDescription);
                    param.Add("@IsCall", potential.IsCall);
                    param.Add("@IsSendEmail", potential.IsSendEmail);
                    param.Add("@Gender", potential.Gender);
                    param.Add("@DateOfBirth", potential.DateOfBirth);
                    param.Add("@Facebook", potential.Facebook);
                    param.Add("@IsShare", potential.IsShare);
                    param.Add("@VocativeID", potential.VocativeID);
                    param.Add("@DepartmentID", potential.DepartmentID);
                    param.Add("@PositionID", potential.PositionID);
                    param.Add("@SourceID", potential.SourceID);
                    param.Add("@OrganizationTypeID", potential.OrganizationTypeID);
                    param.Add("@TurnoverID", potential.TurnoverID);
                    param.Add("@PotentialTypes", JsonSerializer.Serialize(potential.PotentialTypes));
                    param.Add("@Careers", JsonSerializer.Serialize(potential.Careers));
                    param.Add("@Fields", JsonSerializer.Serialize(potential.Fields));
                    param.Add("@CreatedDate", potential.CreatedDate);
                    param.Add("@CreatedBy", potential.CreatedBy);
                    param.Add("@ModifiedDate", potential.ModifiedDate);
                    param.Add("@ModifiedBy", potential.ModifiedBy);

                    string sql = "insert into Potentials(PotentialID, PotentialCode, LastName, FirstName, FullName, PhoneNumber, OfficePhoneNumber, OtherPhoneNumber, Email, OfficeEmail, TaxCode, Zalo, Organization, BankAccount, BankName, FoundingDate, Address, NationID, CityID, DistrictID, WardID, ApartmentNumber, RegionCode, PotentialDescription, IsCall, IsSendEmail, Gender, DateOfBirth, Facebook, IsShare, VocativeID, DepartmentID, PositionID, SourceID, OrganizationTypeID, TurnoverID, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, PotentialTypes, Careers, Fields)" +
                        "values(@PotentialID, @PotentialCode, @LastName, @FirstName, @FullName, @PhoneNumber, @OfficePhoneNumber, @OtherPhoneNumber, @Email, @OfficeEmail, @TaxCode, @Zalo, @Organization, @BankAccount, @BankName, @FoundingDate, @Address, @NationID, @CityID, @DistrictID, @WardID, @ApartmentNumber, @RegionCode, @PotentialDescription, @IsCall, @IsSendEmail, @Gender, @DateOfBirth, @Facebook, @IsShare, @VocativeID, @DepartmentID, @PositionID, @SourceID, @OrganizationTypeID, @TurnoverID, @CreatedDate, @CreatedBy, @ModifiedDate, @ModifiedBy, @PotentialTypes, @Careers, @Fields)";

                    var res = mysqlConnection.Execute(sql, param);

                    if (res > 0)
                    {
                        var result = new ActionResults<Guid>()
                        {
                            Status = 2,
                            StatusMsg = ResultMessage._SUCCESS_MSG,
                            Data = potential.PotentialID,
                        };
                        return result;
                    }
                    else
                    {
                        var result = new ActionResults<Guid>()
                        {
                            Status = 0,
                            StatusMsg = ResultMessage._SUCCESS_NULL_MSG,
                        };
                        return result;
                    }

                }
            }
            catch (MySqlException me)
            {
                var ex = new ActionResults<Guid>();
                if (me.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    ex.Status = 0;
                    ex.StatusMsg = "PotentialCodeDuplicate";

                }
                else
                {
                    ex.Status = 0;
                    ex.StatusMsg = me.ToString();
                }
                return ex;
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

        /// <summary>
        /// repository truy vấn xóa 1 tiềm năng
        /// created by SONTD (11.08.2022)
        /// </summary>
        /// <param name="potentialID"></param>
        /// <returns></returns>
        public ActionResults<Guid> Delete(DynamicParameters param, string where)
        {
            try
            {
                using(var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING))
                {
                    string sql = "delete from Potentials "+where;
                    
                    var res = mysqlConnection.Execute(sql,param);
                    if (res>0)
                    {
                        var result = new ActionResults<Guid>()
                        {
                            Status = 2,
                            StatusMsg = ResultMessage._SUCCESS_MSG,
                        };
                        return result;
                    }
                    else
                    {
                        var result = new ActionResults<Guid>()
                        {
                            Status = 0,
                            StatusMsg = ResultMessage._SUCCESS_NULL_MSG,
                        };
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                return new ActionResults<Guid>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._REPOSITORY_EXCEPTION_MSG,
                };
            }
        }

        /// <summary>
        /// repository truy vấn lấy 1 tiềm năng theo id
        /// created by SONTD(15.08.2022)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResults<PotentialDTO> GetById(Guid id)
        {
            try
            {
                using(var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING))
                {
                    string sql = "select * from Potentials where PotentialID = @PotentialID";
                    var param = new DynamicParameters();
                    param.Add("@PotentialID",id);

                    var res = mysqlConnection.QueryFirstOrDefault<PotentialDTO>(sql, param);
                    return new ActionResults<PotentialDTO>()
                    {
                        Data = res,
                        Status =2,
                        StatusMsg=ResultMessage._SUCCESS_MSG,
                    };
                }
            }
            catch (Exception e)
            {
                return new ActionResults<PotentialDTO>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._REPOSITORY_EXCEPTION_MSG,
                };
            }
        }

        /// <summary>
        /// hàm xử lí logic cho update potentials api
        /// created by SONTD(15.08.2022)
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResults<Guid> Update(string query, DynamicParameters param)
        {
            try
            {
                using(var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING))
                {
                    var result = mysqlConnection.Execute(query, param);
                    var res = new ActionResults<Guid>();
                    if (result > 0)
                    {
                        res.Status = 1;
                        res.StatusMsg = ResultMessage._SUCCESS_MSG;
                    }
                    else
                    {
                        res.Status = 0;
                        res.StatusMsg = ResultMessage._SUCCESS_NULL_MSG;
                    }
                    return res;
                }
            }catch(Exception e)
            {
                return new ActionResults<Guid>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._REPOSITORY_EXCEPTION_MSG,
                };
            }
        }


        /// <summary>
        /// hàm gọi truy vấn vào db cho update nhiều bản ghi
        /// created by SONTD(15.08.2022)
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResults<int> MultiUpdate(string query, DynamicParameters param)
        {
            try
            {
                using (var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING))
                {
                    var result = mysqlConnection.Execute(query, param);
                    var res = new ActionResults<int>();
                    if (result > 0)
                    {
                        res.Data = result;
                        res.Status = 2;
                        res.StatusMsg = ResultMessage._SUCCESS_MSG;
                    }
                    else
                    {
                        res.Status = 0;
                        res.StatusMsg = ResultMessage._SUCCESS_NULL_MSG;
                    }
                    return res;
                }
            }
            catch (Exception e)
            {
                return new ActionResults<int>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._REPOSITORY_EXCEPTION_MSG,
                };
            }
        }

        /// <summary>
        /// hàm gọi query để láy ra code lớn nhất
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public ActionResults<string> NewCode(string sql)
        {
            try
            {
                using(var connection = new MySqlConnection(DBConfig._CONNECTION_STRING))
                {
                    var res = connection.QueryFirstOrDefault<string>(sql);
                    var result = new ActionResults<string>();
                    result.Data = res;

                    if (res != null)
                    {
                        result.Status = 2;
                        result.StatusMsg = ResultMessage._SUCCESS_MSG;
                    }
                    else
                    {
                        result.Status = 0;
                        result.StatusMsg = ResultMessage._SUCCESS_NULL_MSG;
                    }
                    return result;
                }
            }
            catch (Exception e)
            {
                return new ActionResults<string>()
                {
                    Status = 0,
                    StatusMsg = e.ToString(),
                };
            }
        }

        /// <summary>
        /// hàm check xem value của cột mình nhập có bị duplicate hay không
        /// </summary>
        /// <returns></returns>
        //public ActionResults<int> Duplicate(string query, DynamicParameters param)
        //{
        //    try
        //    {
        //        using (var connection = new MySqlConnection(DBConfig._CONNECTION_STRING))
        //        {
        //            var queryResult = connection.QueryFirstOrDefault<int>(query, param);
        //            var result = new ActionResults<int>();
        //            result.Data = queryResult;
        //            if (queryResult>0)
        //            {
        //                result.Status = 2;
        //                result.StatusMsg = ResultMessage._SUCCESS_MSG;
        //            }
        //            else
        //            {
        //                result.Status = 0;
        //                result.StatusMsg = ResultMessage._SUCCESS_NULL_MSG;
        //            }
        //            return result;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return new ActionResults<int>()
        //        {
        //            Status = 0,
        //            StatusMsg = e.ToString(),
        //        };
        //    }
        //}
    }
}

using MISA.Fresher.API.Repositories;
using MISA.Fresher.API.Entities.DTO;
using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Config;
using Dapper;
using System.Text.Json;
using System.Text;

namespace MISA.Fresher.API.Services
{
    public class PotentialService
    {
        /// <summary>
        /// hàm xử lí logic cho việc lấy dữ liệu potential
        /// </summary>
        /// <param name="pageSize"></param> số dòng trên trang
        /// <param name="pageNumber"></param> trang số
        /// <param name="where"></param> lọc
        /// <param name="sort"></param> sắp xếp
        /// <returns></returns>
        public ActionResults<Paging> GetAll(int pageSize, int pageNumber, string filter, FilterData[] filterData)
        {
            try
            {
                var where = new StringBuilder();
                where.Append(" where ");
                if (filter != null)
                {
                    where.Append($" ( PotentialCode like \'%{filter}%\' or  FullName like \'%{filter}%\' " +
                        $" or PhoneNumber like \'%{filter}%\' or OfficePhoneNumber like \'%{filter}%\' or Email like \'%{filter}%\' or OfficeEmail like \'%{filter}%\') ");
                }
                if (filterData.Length != 0)
                {
                    if (filter != null)
                    {
                        where.Append(" and ");
                    }
                    where.Append(" ( ");
                    for (int i=0; i<filterData.Length; i++)
                    {
                        if (filterData[i].FilterType == 0)
                        {
                            where.Append($" (`{filterData[i].ColumnName}` like \'%{filterData[i].ColumnValue}%\') and ");
                        }else if (filterData[i].FilterType == 1)
                        {
                            where.Append($" (`{filterData[i].ColumnName}` not like \'%{filterData[i].ColumnValue}%\') and ");
                        }else if (filterData[i].FilterType == 2)
                        {
                            where.Append($" (`{filterData[i].ColumnName}` = \'{filterData[i].ColumnValue}\') and ");
                        }
                        else if (filterData[i].FilterType == 3)
                        {
                            where.Append($" (`{filterData[i].ColumnName}` <> \'{filterData[i].ColumnValue}\') and ");
                        }
                    }
                    where.Append(" PotentialID like \'%%\') ");
                }
                var potentialRepository = new PotentialRepository();
                int skip = (pageNumber - 1) * pageSize;

                if (where.ToString() != " where ")
                {
                    return potentialRepository.GetAll(skip, pageSize, where.ToString(), "");
                }
                else
                {
                    return potentialRepository.GetAll(skip, pageSize, "", "");
                }
            }
            catch (Exception)
            {
                return new ActionResults<Paging>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG,
                };
            }
        }

        /// <summary>
        /// xử lí logic thêm 1 tiềm năng
        /// created by SONTD (11.08.2022)
        /// </summary>
        /// <param name="potential"></param>
        /// <returns></returns>
        public ActionResults<Guid> Add(Potentials potential)
        {
            try
            {
                //gọi repository 
                var potentialRepository = new PotentialRepository();
                var newID = Guid.NewGuid();
                var now = DateTime.Now;
                potential.PotentialID = newID;
                potential.CreatedDate = now;
                potential.ModifiedDate = now;
                return potentialRepository.Add(potential);
            }
            catch (Exception)
            {
                return new ActionResults<Guid>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG,
                };
            }
        }

        /// <summary>
        /// xử lí logic xóa 1 tiềm năng
        /// created by SONTD (11.08.2022)
        /// </summary>
        /// <param name="potentialID"></param>
        /// <returns></returns>
        public ActionResults<Guid> Delete(GetListIDDTO potentialIDList)
        {
            try
            {
                var repository = new PotentialRepository();
                var param = new DynamicParameters();
                string whereClause = "where PotentialID= \'000\' or";
                
                for (int i = 0; i < potentialIDList.ListID.Length; i++)
                {
                    var potentialID = potentialIDList.ListID[i];
                    param.Add("@id" + i.ToString(), potentialID);
                    whereClause += $" PotentialID=@id{i} or";
                }
                whereClause = whereClause.Remove(whereClause.Length - 2);
                var res = repository.Delete(param, whereClause);
                return res;
            }
            catch (Exception)
            {
                return new ActionResults<Guid>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG,
                };
            }
        }

        /// <summary>
        /// xử lí logic lấy ra 1 bản ghi theo id
        /// created by SONTD(14.08.2022)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResults<PotentialDTO> GetById(Guid id)
        {
            try
            {
                var repository = new PotentialRepository();
                var res = repository.GetById(id);
                if (res.Data.PotentialTypes != null)
                {
                    res.Data.PotentialTypesObj = JsonSerializer.Deserialize<PotentialTypes[]>(res.Data.PotentialTypes);
                }
                if (res.Data.Fields != null)
                {
                    res.Data.FieldsObj = JsonSerializer.Deserialize<Fields[]>(res.Data.Fields);
                }
                if (res.Data.Careers != null)
                {
                    res.Data.CareersObj = JsonSerializer.Deserialize<Careers[]>(res.Data.Careers);
                }
                return res;
            }
            catch (Exception)
            {
                return new ActionResults<PotentialDTO>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG,
                };
            }
        }

        /// <summary>
        /// hàm xử lí logic để update dữ liệu cho 1 tiềm năng
        /// created by SONTD(15.08.2022)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="potential"></param>
        /// <returns></returns>
        public ActionResults<Guid> Update(Guid id, UpdatePotentialDTO potential)
        {
            try
            {
                var param = new DynamicParameters();
                var now = DateTime.Now;
                potential.ModifiedDate = now;
                param.Add("@PotentialID", id);
                potential.PotentialTypes = JsonSerializer.Serialize(potential.PotentialTypesObj);
                string query = "update Potentials " +
                                "Set ";
                foreach (var prop in potential.GetType().GetProperties())
                {
                    if(prop.Name != "PotentialID" && prop.Name!="PotentialTypesObj" && prop.Name != "FieldsObj" && prop.Name != "CareersObj")
                    {
                        var value = prop.GetValue(potential, null);
                        param.Add("@" + prop.Name, value);

                        query += $"{prop.Name} = @{prop.Name}, ";
                        
                    }
                }
                string query1 = query.Remove(query.Length-2);
                string query2 = string.Concat(query1, " where PotentialID = @PotentialID");
                var repository = new PotentialRepository();
                var res = repository.Update(query2, param);
                return res;
            }
            catch (Exception)
            {
                return new ActionResults<Guid>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG,
                };
            }
        }

        /// <summary>
        /// xử lí logic cho api update nhiều bản ghi 1 lúc
        /// created by SONTD(15.08.2022)
        /// </summary>
        /// <param name="multiUpdatePotentialDTO"></param>
        /// <returns></returns>
        public ActionResults<int> MultiUpdate(MultiUpdatePotentialDTO multiUpdatePotentialDTO)
        {
            try
            {
                var query = new StringBuilder();
                var now = DateTime.Now;
                var param = new DynamicParameters();
                var listID = multiUpdatePotentialDTO.ListPotentialID;
                var columnName = multiUpdatePotentialDTO.ColumnName;
                var columnValueString = multiUpdatePotentialDTO.ColumnValueString;
                if (columnName == "Careers")
                {
                    columnValueString = JsonSerializer.Serialize(multiUpdatePotentialDTO.ColumnValueCareers);
                }
                else if (columnName == "Fields")
                {
                    columnValueString = JsonSerializer.Serialize(multiUpdatePotentialDTO.ColumnValueFields);
                }
                else if (columnName == "PotentialTypes")
                {
                    columnValueString = JsonSerializer.Serialize(multiUpdatePotentialDTO.ColumnValuePotentialTypes);
                }

                if (columnName == "IsSendEmail" || columnName == "IsCall")
                {
                    param.Add("@" + columnName, multiUpdatePotentialDTO.ColumnValueNumber);
                }
                else
                {
                    param.Add("@" + columnName, columnValueString);
                }
                query.Append($"update Potentials set {columnName} = @{columnName}, ModifiedDate=@ModifiedDate ");
                param.Add("@ModifiedDate", now);
                query.Append(" where PotentialID = \'00000000-0000-0000-0000-000000000000\' or ");
                for (int i = 0; i < listID.Length; i++)
                {
                    if (listID[i] != Guid.Empty)
                    {
                        if(i<listID.Length - 1)
                        {
                            query.Append($" PotentialID = @PotentialID{i} or ");
                        }
                        else
                        {
                            query.Append($" PotentialID = @PotentialID{i} ");
                        }
                        param.Add("@PotentialID" + i, listID[i]);
                    }
                }

                var repository = new PotentialRepository();
                var res = repository.MultiUpdate(query.ToString(), param);
                return res;
            }
            catch (Exception ex)
            {
                return new ActionResults<int>()
                {
                    Status = 0,
                    StatusMsg = ex.ToString(),
                };
            }
            //return res;
        }

        /// <summary>
        /// xử lí logic lấy code mới = code cũ lớn nhất +1
        /// created by SONTD(15.08.2022)
        /// </summary>
        /// <returns></returns>
        public ActionResults<string> NewCode()
        {
            try
            {
                string sql = "select p.PotentialCode from Potentials p where length(p.PotentialCode)=(select max(length(p1.PotentialCode)) from Potentials p1) order by p.PotentialCode DESC limit 0,1";
                var repository = new PotentialRepository();
                var res = repository.NewCode(sql);
                if (res.Data != null)
                {
                    long numberCode = 0;
                    long.TryParse(res.Data.Substring(3),out numberCode);
                    numberCode += 1;
                    res.Data = "TN-" + numberCode.ToString();
                }
                return res;
            }
            catch (Exception)
            {
                return new ActionResults<string>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG,
                };
            }
        }

        /// <summary>
        /// hàm xử lí logic để lấy dữ liệu cho file excel
        /// </summary>
        /// <param name="potentialIDList"></param>
        /// <param name="filter"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public ActionResults<Paging> ExportToExcel(Guid[] potentialIDList,
                                                   string filter,
                                                   int pageSize,
                                                   int pageNumber)
        {
            try
            {
                //chuẩn bị proc name
                var procName = "Proc_Filter_Potentials";
                var param = new DynamicParameters();
                var where = new StringBuilder();
                if (potentialIDList.Length > 0)
                {
                    where.Append(" where PotentialID in ( ");
                    for (int i = 0; i < potentialIDList.Length; i++)
                    {
                        if (i < potentialIDList.Length - 1)
                        {
                            where.Append($" \'{potentialIDList[i]}\', ");
                        }
                        else
                        {
                            where.Append($" \'{potentialIDList[i]}\' ");
                        }
                    }
                    where.Append(" ) ");
                }

                int skip = (pageNumber - 1) * pageSize;
                //chuẩn bị parameter 
                param.Add("@$Skip", skip);
                param.Add("@$Take", pageSize);
                param.Add("@$Where", where.ToString());
                param.Add("@$Sort", "");

                var repository = new PotentialRepository();
                var res = repository.ExportToExcel(procName, param);
                return res;
            }
            catch (Exception e)
            {
                return new ActionResults<Paging>()
                {
                    Status = 0,
                    StatusMsg = e.ToString(),
                };
            }
        }
    }
}

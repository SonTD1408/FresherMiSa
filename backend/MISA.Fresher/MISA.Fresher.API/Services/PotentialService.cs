using MISA.Fresher.API.Repositories;
using MISA.Fresher.API.Entities.DTO;
using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Config;
using Dapper;
using Newtonsoft.Json;

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
        public ActionResults<Paging> getAll(int pageSize, int pageNumber, string where, string sort)
        {
            try
            {
                var potentialRepository = new PotentialRepository();
                int take = (pageNumber - 1) * pageSize;
                return potentialRepository.getAll(take, pageSize, where, sort);
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
        public ActionResults<Guid> add(Potentials potential)
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
                return potentialRepository.add(potential);
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
        public ActionResults<Guid> delete(GetListIDDTO potentialIDList)
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
                var res = repository.delete(param, whereClause);
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
        public ActionResults<Potentials> getById(Guid id)
        {
            try
            {
                var repository = new PotentialRepository();
                return repository.getById(id);
            }
            catch (Exception)
            {
                return new ActionResults<Potentials>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG,
                };
            }
        }

        /// <summary>
        /// hàm xử lí logic để update dữ liệu cho 1 tiềm năng
        /// </summary>
        /// <param name="id"></param>
        /// <param name="potential"></param>
        /// <returns></returns>
        public ActionResults<Guid> update(Guid id, UpdatePotentialDTO potential)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@PotentialID", id);
                string query = "update Potentials " +
                                "Set ";
                foreach (var prop in potential.GetType().GetProperties())
                {
                    if(prop.Name != "PotentialID")
                    {
                        var value = prop.GetValue(potential, null);
                        if (value != null)
                        {
                            param.Add("@" + prop.Name, value);
                            query += $"{prop.Name} = @{prop.Name}, ";
                        } 
                    }
                }
                string query1 = query.Remove(query.Length-2);
                string query2 = string.Concat(query1, " where PotentialID = @PotentialID");
                var repository = new PotentialRepository();
                var res = repository.update(query2, param);
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
    }
}

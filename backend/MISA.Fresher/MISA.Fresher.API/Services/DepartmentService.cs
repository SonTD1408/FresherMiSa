using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Repositories;
using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Config;

namespace MISA.Fresher.API.Services
{
    public class DepartmentService
    {
        /// <summary>
        /// Hàm xử li logic lấy dữ liệu từ bảng Departments
        /// createdby SONTD (10.08.2022)
        /// </summary>
        /// <returns></returns>
        public ActionResults<Departments> GetAll()
        {
            try
            {
                var repository = new DepartmentRepository();
                return repository.GetAll();
            }
            catch (Exception)
            {
                return new ActionResults<Departments>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG,
                };
            }
        }
    }
}

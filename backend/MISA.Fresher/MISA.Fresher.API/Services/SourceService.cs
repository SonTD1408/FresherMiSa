using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Repositories;
using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Config;

namespace MISA.Fresher.API.Services
{
    public class SourceService
    {
        /// <summary>
        /// Hàm xử li logic lấy dữ liệu từ bảng nguồn gốc
        /// createdby SONTD (10.08.2022)
        /// </summary>
        /// <returns></returns>
        public ActionResults<Sources> getAll()
        {
            try
            {
                var sourceRepository = new SourceRepository();
                return sourceRepository.getAll();
            }
            catch (Exception)
            {
                return new ActionResults<Sources>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG
                };
            }
        }
    }
}

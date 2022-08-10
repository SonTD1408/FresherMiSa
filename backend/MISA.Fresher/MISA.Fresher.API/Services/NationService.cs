using MISA.Fresher.API.Repositories;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Config;

namespace MISA.Fresher.API.Services
{
    public class NationService
    {
        /// <summary>
        /// Hàm xử li logic lấy dữ liệu của bảng Nations
        /// createdby SONTD (19.08.2022)
        /// </summary>
        /// <returns></returns>
        public ActionResults<Nations> getAll()
        {
            try
            {
                var re = new NationRepository();
                return re.getAll();
            }
            catch (Exception)
            {
                return new ActionResults<Nations>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG
                };
            }
        }

    }
}

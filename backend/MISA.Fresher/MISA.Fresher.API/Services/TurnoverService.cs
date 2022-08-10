using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Repositories;
using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Config;

namespace MISA.Fresher.API.Services
{
    public class TurnoverService
    {
        /// <summary>
        /// Hàm xử li logic lấy dữ liệu từ bảng doanh thu
        /// createdby SONTD (10.08.2022)
        /// </summary>
        /// <returns></returns>
        public ActionResults<Turnovers> getAll()
        {
            try
            {
                var turnoverRepository = new TurnoverRepository();
                return turnoverRepository.getAll();
            }
            catch (Exception)
            {
                return new ActionResults<Turnovers>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG
                };
            }
        }
    }
}

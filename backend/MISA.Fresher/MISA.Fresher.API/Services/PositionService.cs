using MISA.Fresher.API.Repositories;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Config;

namespace MISA.Fresher.API.Services
{
    public class PositionService
    {
        /// <summary>
        /// Hàm xử li logic lấy dữ liệu từ bảng chức vụ
        /// createdby SONTD (10.08.2022)
        /// </summary>
        /// <returns></returns>
        public ActionResults<Positions> getAll()
        {
            try
            {
                var positionRepository = new PositionRepository();
                return positionRepository.getAll();
            }
            catch (Exception)
            {
                return new ActionResults<Positions>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG
                };
            }
        }
    }
}

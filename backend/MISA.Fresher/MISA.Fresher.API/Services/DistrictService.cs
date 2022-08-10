using MISA.Fresher.API.Repositories;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Config;

namespace MISA.Fresher.API.Services
{
    public class DistrictService
    {
        /// <summary>
        /// Hàm xử li logic lấy dữ liệu của bảng Districts
        /// createdby SONTD (19.08.2022)
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public ActionResults<Districts> getAll(Guid cityID)
        {
            try
            {
                var re = new DistrictRepository();
                return re.getAll(cityID);
            }
            catch (Exception)
            {
                return new ActionResults<Districts>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG
                };
            }
        }

    }
}

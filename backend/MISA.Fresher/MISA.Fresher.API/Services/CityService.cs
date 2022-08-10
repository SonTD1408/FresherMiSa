using MISA.Fresher.API.Repositories;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Config;

namespace MISA.Fresher.API.Services
{
    public class CityService
    {
        /// <summary>
        /// Hàm xử li logic lấy dữ liệu của bảng cities
        /// createdby SONTD (19.08.2022)
        /// </summary>
        /// <param name="nationID"></param>
        /// <returns></returns>
        public ActionResults<Cities> getAll(Guid nationID)
        {
            try
            {
                var re = new CityRepository();
                return re.getAll(nationID);
            }
            catch (Exception)
            {
                return new ActionResults<Cities>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG
                };
            }
        }

    }
}

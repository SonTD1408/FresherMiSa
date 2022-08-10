using MISA.Fresher.API.Repositories;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Config;

namespace MISA.Fresher.API.Services
{
    public class WardService
    {
        /// <summary>
        /// Hàm xử li logic lấy dữ liệu của bảng Wards
        /// createdby SONTD (19.08.2022)
        /// </summary>
        /// <param name="districtID"></param>
        /// <returns></returns>
        public ActionResults<Wards> getAll(Guid districtID)
        {
            try
            {
                var re = new WardRepository();
                return re.getAll(districtID);
            }
            catch (Exception)
            {
                return new ActionResults<Wards>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG
                };
            }
        }

    }
}

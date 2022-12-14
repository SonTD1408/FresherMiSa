using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Repositories;
using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Config;

namespace MISA.Fresher.API.Services
{
    public class VocativeService
    {
        /// <summary>
        /// Hàm xử li logic lấy dữ liệu từ bảng xưng hô
        /// createdby SONTD (10.08.2022)
        /// </summary>
        /// <returns></returns>
        public ActionResults<Vocatives> getAll()
        {
            try
            {
                var vocativeRpository = new VocativeRepository();
                return vocativeRpository.getAll();
            }
            catch (Exception)
            {
                return new ActionResults<Vocatives>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG
                };
            }
        }
    }
}

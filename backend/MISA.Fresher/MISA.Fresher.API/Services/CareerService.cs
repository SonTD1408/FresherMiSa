using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Config;
using MISA.Fresher.API.Repositories;

namespace MISA.Fresher.API.Services
{
    public class CareerService
    {
        public ActionResults<Careers> get()
        {
            try
            {
                var repository = new CareerRepository();
                return repository.get();
            }
            catch (Exception)
            {
                return new ActionResults<Careers>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG,
                };
            }
        }
    }
}

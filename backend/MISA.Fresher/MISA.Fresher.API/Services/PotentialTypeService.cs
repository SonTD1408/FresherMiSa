using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Config;
using MISA.Fresher.API.Repositories;

namespace MISA.Fresher.API.Services
{
    public class PotentialTypeService
    {
        public ActionResults<PotentialTypes> get()
        {
            try
            {
                var repository = new PotentialTypeRepository();
                return repository.get();
            }
            catch (Exception)
            {
                return new ActionResults<PotentialTypes>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG,
                };
            }
        }
    }
}

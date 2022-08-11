using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Config;
using MISA.Fresher.API.Repositories;

namespace MISA.Fresher.API.Services
{
    public class FieldService
    {
        public ActionResults<Fields> get()
        {
            try
            {
                var repository = new FieldRepository();
                return repository.get();
            }
            catch (Exception)
            {
                return new ActionResults<Fields>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG,
                };
            }
        }
    }
}

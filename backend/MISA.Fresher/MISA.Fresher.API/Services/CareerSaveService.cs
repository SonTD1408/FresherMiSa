using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Config;
using MISA.Fresher.API.Entities ;
using MISA.Fresher.API.Repositories;

namespace MISA.Fresher.API.Services
{
    public class CareerSaveService
    {
        public ActionResults<Guid> add(Guid careerID, Guid potentialID)
        {
            try
            {
                var newID = Guid.NewGuid();
                var now = DateTime.Now;
                var repository = new CareerSaveRepository();
                var careerSave = new CareerSaves()
                {
                    CareerSaveID = newID,
                    CareerID = careerID,
                    PotentialID = potentialID,
                    CreatedDate = now,
                    ModifiedDate = now
                };
                return repository.add(careerSave);
            }
            catch (Exception)
            {
                return new ActionResults<Guid>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG,
                };
            }
        }
    }
}

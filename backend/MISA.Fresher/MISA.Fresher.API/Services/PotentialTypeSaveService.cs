using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Config;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Repositories;

namespace MISA.Fresher.API.Services
{
    public class PotentialTypeSaveService
    {
        public ActionResults<Guid> add(Guid potentialTypeID, Guid potentialID)
        {
            try
            {
                var newID = Guid.NewGuid();
                var now = DateTime.Now;
                var repository = new PotentialTypeSaveRepository();
                var potentialTypeSave = new PotentialTypeSaves()
                {
                    PotentialTypeSaveID = newID,
                    PotentialTypeID = potentialTypeID,
                    PotentialID = potentialID,
                    CreatedDate = now,
                    ModifiedDate = now
                };
                return repository.add(potentialTypeSave);
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

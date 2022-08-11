using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Config;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Repositories;

namespace MISA.Fresher.API.Services
{
    public class FieldSaveService
    {
        public ActionResults<Guid> add(Guid fieldID, Guid potentialID)
        {
            try
            {
                var newID = Guid.NewGuid();
                var now = DateTime.Now;
                var repository = new FieldSaveRepository();
                var fieldSave = new FieldSaves()
                {
                    FieldSaveID = newID,
                    FieldID = fieldID,
                    PotentialID = potentialID,
                    CreatedDate = now,
                    ModifiedDate = now
                };
                return repository.add(fieldSave);
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

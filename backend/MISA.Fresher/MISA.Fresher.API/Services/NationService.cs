using MISA.Fresher.API.Repositories;
using MISA.Fresher.API.Entities;
namespace MISA.Fresher.API.Services
{
    public class NationService
    {
        public List<Nations> getAll()
        {
            var re = new NationRepository();
            return re.getAll();
        }
    }
}

using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Repositories;

namespace MISA.Fresher.API.Services
{
    public class VocativeService
    {
        public List<Vocatives> getAll()
        {
            var vocativeRpository = new VocativeRepository();
            return vocativeRpository.getAll();
        }
    }
}

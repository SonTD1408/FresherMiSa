using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Repositories;

namespace MISA.Fresher.API.Services
{
    public class InComeService
    {
        public List<InComes> getAll()
        {
            var re = new InComeRepository();
            return re.getAll();
        }
    }
}

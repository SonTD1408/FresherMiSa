using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Repositories;

namespace MISA.Fresher.API.Services
{
    public class SourceService
    {
        public List<Sources> getAll()
        {
            var re = new SourceRepository();
            return re.getAll();
        }
    }
}

using MISA.Fresher.API.Repositories;
using MISA.Fresher.API.Entities;
namespace MISA.Fresher.API.Services
{
    public class CityService
    {
        public List<Cities> getAll(int nationID)
        {
            var re = new CityRepository();
            return re.getAll(nationID);
        }
    }
}

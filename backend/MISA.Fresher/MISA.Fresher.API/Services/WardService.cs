using MISA.Fresher.API.Repositories;
using MISA.Fresher.API.Entities;
namespace MISA.Fresher.API.Services
{
    public class WardService
    {
        public List<Wards> getAll(int districtID)
        {
            var re = new WardRepository();
            return re.getAll(districtID);
        }
    }
}

using MISA.Fresher.API.Repositories;
using MISA.Fresher.API.Entities;
namespace MISA.Fresher.API.Services
{
    public class DistrictService
    {
        public List<Districts> getAll(int cityID)
        {
            var re = new DistrictRepository();
            return re.getAll(cityID);
        }
    }
}

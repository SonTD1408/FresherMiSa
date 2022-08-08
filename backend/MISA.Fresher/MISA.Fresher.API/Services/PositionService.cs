using MISA.Fresher.API.Repositories;
using MISA.Fresher.API.Entities;

namespace MISA.Fresher.API.Services
{
    public class PositionService
    {
        public List<Positions> getAll()
        {
            var positionRepository = new PositionRepository();
            return positionRepository.getAll();
        }
    }
}

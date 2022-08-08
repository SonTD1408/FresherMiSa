using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Repositories;

namespace MISA.Fresher.API.Services
{
    public class OrganizationTypeService
    {
        public List<OrganizationTypes> getAll()
        {
            var re = new OrganizationTypeRepository();
            return re.getAll();
        }
    }
}

using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Repositories;

namespace MISA.Fresher.API.Services
{
    public class DepartmentService
    {
        public List<Departments> getAll()
        {
            var departmentRepository = new DepartmentRepository();
            return departmentRepository.getAll();
        }
    }
}

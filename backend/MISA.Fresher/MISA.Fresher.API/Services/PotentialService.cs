using MISA.Fresher.API.Repositories;
using MISA.Fresher.API.Entities.DTO;

namespace MISA.Fresher.API.Services
{
    public class PotentialService
    {
        /// <summary>
        /// hàm xử lí logic cho việc lấy dữ liệu potential
        /// </summary>
        /// <param name="pageSize"></param> số dòng trên trang
        /// <param name="pageNumber"></param> trang số
        /// <param name="where"></param> lọc
        /// <param name="sort"></param> sắp xếp
        /// <returns></returns>
        public Paging getAll(int pageSize, int pageNumber, string where, string sort)
        {
            var potentialRepository = new PotentialRepository();
            int take = (pageNumber - 1) * pageSize;
            return potentialRepository.getAll(take, pageSize, where, sort);
        }
    }
}

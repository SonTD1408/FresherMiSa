using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Repositories;
using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Config;

namespace MISA.Fresher.API.Services
{
    public class OrganizationTypeService
    {
        /// <summary>
        /// Hàm xử li logic lấy dữ liệu từ bảng loại tổ chức
        /// createdby SONTD (10.08.2022)
        /// </summary>
        /// <returns></returns>
        public ActionResults<OrganizationTypes> getAll()
        {
            try
            {
                var organizationTypeRepository = new OrganizationTypeRepository();
                return organizationTypeRepository.getAll();
            }
            catch (Exception)
            {
                return new ActionResults<OrganizationTypes>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._SERVICE_EXCEPTION_MSG
                };
            }
        }
    }
}

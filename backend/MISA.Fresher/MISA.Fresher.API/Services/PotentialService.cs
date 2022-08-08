using MISA.Fresher.API.Repositories;
using MISA.Fresher.API.Entities.DTO;
using MISA.Fresher.API.Entities;
using Dapper;

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
    
        public int add(Potentials potential)
        {
            var param = new DynamicParameters();
            param.Add("@PotentialCode", potential.PotentialCode);
            param.Add("@VocativeID", potential.VocativeID);
            param.Add("@LastName", potential.LastName);
            param.Add("@FirstName", potential.FirstName);
            param.Add("@DepartmentID", potential.DepartmentID);
            param.Add("@PositionID", potential.PositionID);
            param.Add("@PhoneNumber", potential.PhoneNumber);
            param.Add("@OfficePhoneNumber", potential.OfficePhoneNumber);
            param.Add("@SourceID", potential.SourceID);
            param.Add("@Zalo", potential.Zalo);
            param.Add("@Email", potential.Email);
            param.Add("@OfficeEmail", potential.OfficeEmail);
            param.Add("@Taxcode", potential.Taxcode);
            param.Add("@OrganizationID", potential.OrganizationID);
            param.Add("@DescriptionP", potential.DescriptionP);
            param.Add("@Address", potential.Address);
            param.Add("@Tag", potential.Tag);
            param.Add("@SharedP", potential.SharedP);
            param.Add("@Facebook", potential.Facebook);
            param.Add("@NationID", potential.NationID);
            param.Add("@DistrictID", potential.DistrictID);
            param.Add("@CityID", potential.CityID);
            param.Add("@WardID", potential.WardID);
            param.Add("@Gender", potential.Gender);
            param.Add("@NoCall", potential.NoCall);
            param.Add("@NoEmail", potential.NoEmail);
            param.Add("@DateOfBirth", potential.DateOfBirth);

            //gọi repository 
            var potentialRepository = new PotentialRepository();
            return potentialRepository.Add(param);
        }
    }
}

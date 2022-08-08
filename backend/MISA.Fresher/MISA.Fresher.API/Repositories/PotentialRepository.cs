using MISA.Fresher.API.Entities.DTO;
using MISA.Fresher.API.Config;
using MySqlConnector;
using Dapper;


namespace MISA.Fresher.API.Repositories
{
    public class PotentialRepository
    {
        /// <summary>
        /// hàm truy vấn vào db để lấy dữ liệu bảng potential
        /// </summary>
        /// <param name="skip"></param> bỏ bao nhiêu dl đầu
        /// <param name="take"></param> lấy bao nhiheeu dòng dữ liệu
        /// <param name="where"></param> lọc
        /// <param name="sort"></param> sắp xếp
        /// <returns></returns>
        public Paging getAll(int skip, int take, string where, string sort)
        {
            //kết nối mysql
            var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING);
            //chuẩn bị proc name
            var procName = "Proc_Get_Potentials";
            //chuẩn bị parameter 
            var param = new DynamicParameters();
            param.Add("@$Skip", skip);
            param.Add("@$Take", take);
            param.Add("@$Where", where);
            param.Add("@$Sort", sort);
            //truy vấn
            var res = mysqlConnection.QueryMultiple(procName, param, commandType: System.Data.CommandType.StoredProcedure);

            //xử lí để truyền dữ liệu về service 
            List<PotentialDTO> result = res.Read<PotentialDTO>().ToList();
            var nor = res.Read<long>().Single();

            var page = new Paging()
            {
                PotentialList = result,
                NumberOfRecord = nor
            };

            return page;
        }
        

        public int Add(DynamicParameters param)
        {
            var mysqlConnection = new MySqlConnection(DBConfig._CONNECTION_STRING);
            string sql = "insert into Potentials(PotentialCode, VocativeID, LastName, FirstName, DepartmentID, PositionID, PhoneNumber, OfficePhoneNumber, SourceID, Zalo, Email, OfficeEmail, Taxcode, OrganizationID, DescriptionP, Address, Tag, SharedP, Facebook, NationID, CityID, DistrictID, WardID, Gender, NoCall, NoEmail, DateOfBirth)" +
                "values(@PotentialCode, @VocativeID, @LastName, @FirstName, @DepartmentID, @PositionID, @PhoneNumber, @OfficePhoneNumber, @SourceID, @Zalo, @Email, @OfficeEmail, @Taxcode, @OrganizationID, @DescriptionP, @Address, @Tag, @SharedP, @Facebook, @NationID, @CityID, @DistrictID, @WardID, @Gender, @NoCall, @NoEmail, @DateOfBirth)";

            var res = mysqlConnection.Execute(sql, param);
            
            return res;
        }
    }
}

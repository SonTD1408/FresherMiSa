namespace MISA.Fresher.API.Entities.DTO
{
    public class PotentialDTO
    {
        /// <summary>
        /// id của bảng tiềm năng
        /// </summary>
        public int PotentialID { get; set; }

        /// <summary>
        /// mã tiềm năng
        /// </summary>
        public string PotentialCode { get; set; }

        /// <summary>
        /// id vơi bảng xưng hô
        /// </summary>
        public int VocationID { get; set; }

        /// <summary>
        /// xưng hô
        /// </summary>
        public string Vocative { get; set; }

        /// <summary>
        /// tên
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// họ và tên đệm
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// id phòng ban
        /// </summary>
        public int DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        /// <summary>
        /// id chức vụ
        /// </summary>
        public int PositionID { get; set; }

        public string PositionName { get; set; }

        /// <summary>
        /// số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// số điện thoại cơ quan
        /// </summary>
        public string OfficePhoneNumber { get; set; }

        /// <summary>
        /// id nguồn gốc
        /// </summary>
        public int SourceID { get; set; }
        public string SourceName { get; set; }
        public string Zalo { get; set; }
        public string Email { get; set; }
        public string OfficeEmail { get; set; }
        public string Taxcode { get; set; }
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Tag { get; set; }
        public int Shared { get; set; }
        public string Facebook { get; set; }
        public int NationID { get; set; }
        public string NationName { get; set; }
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int WardID { get; set; }
        public string WardName { get; set; }
        public int Gender { get; set; }
        public int NoCall { get; set; }
        public int NoEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

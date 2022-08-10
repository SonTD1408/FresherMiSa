namespace MISA.Fresher.API.Entities
{
    public class Potentials
    {
        /// <summary>
        /// 1. id của bảng tiềm năng
        /// </summary>
        public Guid PotentialID { get; set; }

        /// <summary>
        /// 2. mã tiềm năng
        /// </summary>
        public string PotentialCode { get; set; }

        /// <summary>
        /// 3. họ và đệm
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 4. tên
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 5. họ và tên
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 6. số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 7. số điện thoại cơ quan
        /// </summary>
        public string OfficePhoneNumber { get; set; }

        /// <summary>
        /// 8. số điện thoại khác
        /// </summary>
        public string OtherPhoneNumber { get; set; }

        /// <summary>
        /// 9. email cá nhân
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 10. email cơ quan
        /// </summary>
        public string OfficeEmail { get; set; }

        /// <summary>
        /// 11. mã số thuế
        /// </summary>
        public string TaxCode { get; set; }

        /// <summary>
        /// 12. zalo
        /// </summary>
        public string Zalo { get; set; }

        /// <summary>
        /// 13. tổ chức
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// 14. tài khoản ngân hàng
        /// </summary>
        public string BankAccount { get; set; }

        /// <summary>
        /// 15. tên ngân hàng
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 16. ngày thành lập
        /// </summary>
        public DateTime FoundingDate { get; set; }

        /// <summary>
        /// 17. địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 18. id FK đến bảng quốc gia
        /// </summary>
        public Guid NationID { get; set; }

        /// <summary>
        /// 19. id FK đến bảng thành phố
        /// </summary>
        public Guid CityID { get; set; }

        /// <summary>
        /// 20. id FK đến bảng huyện
        /// </summary>
        public Guid DistrictID { get; set; }

        /// <summary>
        /// 21. id FK đến bảng phường/ xã
        /// </summary>
        public Guid WardID { get; set; }

        /// <summary>
        /// 22. số nhà, tên đường
        /// </summary>
        public string ApartmentNumber { get; set; }

        /// <summary>
        /// 23. mã vùng
        /// </summary>
        public string RegionCode { get; set; }

        /// <summary>
        /// 24. mô tả
        /// </summary>
        public string PotentialDescription { get; set; }

        /// <summary>
        /// 25. có gọi điện hay không
        /// </summary>
        public int IsCall { get; set; }

        /// <summary>
        /// 26. có được gửi email hay không
        /// </summary>
        public int IsSendEmail { get; set; }

        /// <summary>
        /// 27. giới tính
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 28. ngày sinh
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// 29. facebook
        /// </summary>
        public string Facebook { get; set; }

        /// <summary>
        /// 30. dùng chung
        /// </summary>
        public int IsShare { get; set; }

        /// <summary>
        /// 31. FK đến bảng xưng hô
        /// </summary>
        public Guid VocativeID { get; set; }

        /// <summary>
        /// 32. FK đên bảng phòng ban
        /// </summary>
        public Guid DepartmentID { get; set; }

        /// <summary>
        /// 33. FK đến bảng chức vụ
        /// </summary>
        public Guid PositionID { get; set; }

        /// <summary>
        /// 34. FK đến bảng nguồn gốc
        /// </summary>
        public Guid SourceID { get; set; }

        /// <summary>
        /// 35. FK đến bảng loại tổ chức
        /// </summary>
        public Guid OrganizationTypeID { get; set; }

        /// <summary>
        /// 36. FK đến bảng doanh thu
        /// </summary>
        public Guid TurnoverID { get; set; }

        /// <summary>
        /// 37. ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// 38. người tạo
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// 39. ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// 40. người sửa
        /// </summary>
        public string? ModifiedBy { get; set; }
    }
}

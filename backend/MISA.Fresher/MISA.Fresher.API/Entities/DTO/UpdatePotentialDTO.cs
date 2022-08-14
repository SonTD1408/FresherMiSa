namespace MISA.Fresher.API.Entities.DTO
{
    public class UpdatePotentialDTO
    {
        /// <summary>
        /// 1. id của bảng tiềm năng
        /// </summary>
        public Guid PotentialID { get; set; }

        /// <summary>
        /// 3. họ và đệm
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// 4. tên
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 5. họ và tên
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// 6. số điện thoại
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// 7. số điện thoại cơ quan
        /// </summary>
        public string? OfficePhoneNumber { get; set; }

        /// <summary>
        /// 8. số điện thoại khác
        /// </summary>
        public string? OtherPhoneNumber { get; set; }

        /// <summary>
        /// 9. email cá nhân
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// 10. email cơ quan
        /// </summary>
        public string? OfficeEmail { get; set; }

        /// <summary>
        /// 11. mã số thuế
        /// </summary>
        public string? TaxCode { get; set; }

        /// <summary>
        /// 12. zalo
        /// </summary>
        public string? Zalo { get; set; }

        /// <summary>
        /// 13. tổ chức
        /// </summary>
        public string? Organization { get; set; }

        /// <summary>
        /// 25. có gọi điện hay không
        /// </summary>
        public int? IsCall { get; set; }

        /// <summary>
        /// 26. có được gửi email hay không
        /// </summary>
        public int? IsSendEmail { get; set; }

        /// <summary>
        /// 27. giới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// 28. ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// 29. facebook
        /// </summary>
        public string? Facebook { get; set; }


        /// <summary>
        /// 31. FK đến bảng xưng hô
        /// </summary>
        public Guid? VocativeID { get; set; }

        /// <summary>
        /// 32. FK đên bảng phòng ban
        /// </summary>
        public Guid? DepartmentID { get; set; }

        /// <summary>
        /// 33. FK đến bảng chức vụ
        /// </summary>
        public Guid? PositionID { get; set; }

        /// <summary>
        /// 34. FK đến bảng nguồn gốc
        /// </summary>
        public Guid? SourceID { get; set; }

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
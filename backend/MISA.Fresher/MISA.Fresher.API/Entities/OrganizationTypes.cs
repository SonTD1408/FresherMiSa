namespace MISA.Fresher.API.Entities
{
    public class OrganizationTypes
    {
        /// <summary>
        /// id của bảng loại tổ chức
        /// </summary>
        public Guid OrganizationTypeID { get; set; }

        /// <summary>
        /// tên loại tổ chức
        /// </summary>
        public string OrganizationTypeName { get; set; }

        /// <summary>
        /// ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// người tạo
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// người sửa
        /// </summary>
        public string? ModifiedBy { get; set; }
    }
}

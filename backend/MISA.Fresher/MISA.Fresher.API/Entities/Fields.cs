namespace MISA.Fresher.API.Entities
{
    public class Fields
    {
        /// <summary>
        /// id của bảng 
        /// </summary>
        public Guid FieldID { get; set; }

        /// <summary>
        /// tên lĩnh vực
        /// </summary>
        public string FieldName { get; set; }

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

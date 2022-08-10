namespace MISA.Fresher.API.Entities
{
    public class Sources
    {
        /// <summary>
        /// id của bảng nguồn gốc
        /// </summary>
        public Guid SourceID { get; set; }

        /// <summary>
        /// tên nguồn gốc
        /// </summary>
        public string SourceName { get; set; }

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

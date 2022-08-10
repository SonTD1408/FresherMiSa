namespace MISA.Fresher.API.Entities
{
    public class Careers
    {
        /// <summary>
        /// id của bảng ngành nghề
        /// </summary>
        public Guid CareerID { get; set; }

        /// <summary>
        /// tên ngành nghề
        /// </summary>
        public string CareerName { get; set; }

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

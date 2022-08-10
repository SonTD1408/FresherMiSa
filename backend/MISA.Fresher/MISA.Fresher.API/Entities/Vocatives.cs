namespace MISA.Fresher.API.Entities
{
    public class Vocatives
    {
        /// <summary>
        /// id của bảng xưng hô
        /// </summary>
        public Guid VocativeID { get; set; }

        /// <summary>
        /// xưng hô
        /// </summary>
        public string VocativeName { get; set; }

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

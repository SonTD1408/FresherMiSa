namespace MISA.Fresher.API.Entities
{
    public class PotentialTypes
    {
        /// <summary>
        /// id của bảng loại tiềm năng
        /// </summary>
        public Guid PotentialTypeID { get; set; }

        /// <summary>
        /// tên loại tiềm năng
        /// </summary>
        public string PotentialTypeName { get; set; }

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

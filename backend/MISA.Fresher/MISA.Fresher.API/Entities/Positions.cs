namespace MISA.Fresher.API.Entities
{
    public class Positions
    {
        /// <summary>
        /// id của bảng chức vụ
        /// </summary>
        public Guid PositionID { get; set; }

        /// <summary>
        /// tên chức vụ
        /// </summary>
        public string PositionName { get; set; }

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

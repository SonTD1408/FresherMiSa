namespace MISA.Fresher.API.Entities
{
    public class Turnovers
    {
        /// <summary>
        /// id của bảng doanh thu
        /// </summary>
        public Guid TurnoverID { get; set; }

        /// <summary>
        /// doanh thu
        /// </summary>
        public string TurnoverName { get; set; }

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

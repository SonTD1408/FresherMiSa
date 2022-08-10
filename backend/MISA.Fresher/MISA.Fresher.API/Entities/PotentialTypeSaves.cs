namespace MISA.Fresher.API.Entities
{
    public class PotentialTypeSaves
    {
        /// <summary>
        /// id của bảng
        /// </summary>
        public Guid PotentialTypeSaveID { get; set; }

        /// <summary>
        /// FK đến bảng loại tiềm năng
        /// </summary>
        public Guid PotentialTypeID { get; set; }

        /// <summary>
        /// FK đến bảng tiềm năng
        /// </summary>
        public Guid PotentialID { get; set; }

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

namespace MISA.Fresher.API.Entities
{
    public class FieldSaves
    {
        /// <summary>
        /// id của bảng FieldSaves
        /// </summary>
        public Guid FieldSaveID { get; set; }

        /// <summary>
        /// FK đến bảng tiềm năng
        /// </summary>
        public Guid PotentialID { get; set; }

        /// <summary>
        /// FK đến bảng lĩnh vực
        /// </summary>
        public Guid FieldID { get; set; }

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

namespace MISA.Fresher.API.Entities
{
    public class CareerSaves
    {
        /// <summary>
        /// id của bảng careersave
        /// </summary>
        public Guid CareerSaveID { get; set; }

        /// <summary>
        /// FK đến bảng tiềm năng
        /// </summary>
        public Guid PotentialID { get; set; }

        /// <summary>
        /// FK đến bảng nghề nghiệp
        /// </summary>
        public Guid CareerID { get; set; }

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

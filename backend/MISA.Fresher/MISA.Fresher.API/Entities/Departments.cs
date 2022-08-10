namespace MISA.Fresher.API.Entities
{
    public class Departments
    {
        /// <summary>
        /// id của bảng phòng ban
        /// </summary>
        public Guid DepartmentID { get; set; }

        /// <summary>
        /// tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// ngày sửa
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// người sửa
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}

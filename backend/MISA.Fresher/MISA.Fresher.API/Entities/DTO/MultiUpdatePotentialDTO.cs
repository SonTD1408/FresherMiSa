namespace MISA.Fresher.API.Entities.DTO
{
    public class MultiUpdatePotentialDTO
    {
        /// <summary>
        /// mảng nhiều id của những bản ghi cần update
        /// </summary>
        public Guid[] ListPotentialID { get; set; }

        /// <summary>
        /// tên cột cần update
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// lưu giá trị update cho column kiểu string
        /// </summary>
        public string? ColumnValueString { get; set; }

    }
}

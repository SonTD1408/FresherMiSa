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

        /// <summary>
        /// lưu giá trị update cho column kiểu object careers
        /// </summary>
        public Careers[]? ColumnValueCareers { get; set; }

        /// <summary>
        /// lưu giá trị update cho column kiểu object fields
        /// </summary>
        public Fields[]? ColumnValueFields { get; set; }

        /// <summary>
        /// lưu giá trị update cho column kiểu object potentialTypes
        /// </summary>
        public PotentialTypes[]? ColumnValuePotentialTypes { get; set; }

        /// <summary>
        /// lưu giá trị update cho column kiểu giá trị int
        /// </summary>
        public int? ColumnValueNumber { get; set; }

    }
}

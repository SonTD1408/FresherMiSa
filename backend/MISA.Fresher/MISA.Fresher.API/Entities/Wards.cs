namespace MISA.Fresher.API.Entities
{
    public class Wards
    {
        /// <summary>
        /// id của bảng xã
        /// </summary>
        public Guid WardID { get; set; }

        /// <summary>
        /// tên phường xã
        /// </summary>
        public string WardName { get; set; }

        /// <summary>
        /// id FK đến bảng huyện
        /// </summary>
        public Guid DistrictID { get; set; }
    }
}

namespace MISA.Fresher.API.Entities
{
    public class Districts
    {
        /// <summary>
        /// id của bảng huyện
        /// </summary>
        public Guid DistrictID { get; set; }

        /// <summary>
        /// tên huyện
        /// </summary>
        public string DistrictName { get; set; }

        /// <summary>
        /// id FK đến bảng thành phố
        /// </summary>
        public Guid CityID { get; set; }
    }
}

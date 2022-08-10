namespace MISA.Fresher.API.Entities
{
    public class Cities
    {
        /// <summary>
        /// id của bảng thành phố
        /// </summary>
        public Guid CityID { get; set; }

        /// <summary>
        /// tên thành phố
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// id của FK đến bảng quốc gia
        /// </summary>
        public Guid NationID { get; set; }
    }
}

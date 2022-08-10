namespace MISA.Fresher.API.ActionResult
{
    public class ActionResults<T>
    {
        /// <summary>
        /// thuộc tính DataList để lưu thông tin khi data ở dạng list of ...
        /// </summary>
        public List<T> DataList { get; set; }

        /// <summary>
        /// thuộc tính Data để lưu data không ở dạng list
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Status có thực hiện thành công không hay nhảy vào exception
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// chuỗi msg dc trẩ về
        /// </summary>
        public string StatusMsg { get; set; }
    }
}

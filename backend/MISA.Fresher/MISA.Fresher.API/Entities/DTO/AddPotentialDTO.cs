using MISA.Fresher.API.Entities;

namespace MISA.Fresher.API.Entities.DTO
{
    public class AddPotentialDTO
    {
        /// <summary>
        /// thông tin về potentials
        /// </summary>
        public Potentials Potential { get; set; }

        /// <summary>
        /// thông tin về nghề nghiệp của tiềm năng
        /// </summary>
        public List<GetIDDTO>? Career { get; set; }

        /// <summary>
        /// thông tin về lĩnh vực tổ chức của tiềm năng
        /// </summary>
        public List<GetIDDTO>? Field { get; set; }

        /// <summary>
        /// loại tiềm năng
        /// </summary>
        public List<GetIDDTO>? PotentialType { get; set; }
    }
}

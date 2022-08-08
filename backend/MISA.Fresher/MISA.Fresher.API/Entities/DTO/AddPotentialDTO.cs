using MISA.Fresher.API.Entities;

namespace MISA.Fresher.API.Entities.DTO
{
    public class AddPotentialDTO
    {
        public Potentials Potential { get; set; }
        public Organizations Organization { get; set; }
        public List<GetIDDTO> OrganizationCareer { get; set; }
        public List<GetIDDTO> Field { get; set; }
        public List<GetIDDTO> PotentialType { get; set; }
    }
}

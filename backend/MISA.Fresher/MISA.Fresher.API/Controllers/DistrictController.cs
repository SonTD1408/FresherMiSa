using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Services;
namespace MISA.Fresher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        [HttpGet]
        public IActionResult getAll([FromQuery] int cityID)
        {
            var ser = new DistrictService();
            return Ok(ser.getAll(cityID));
        }
    }
}

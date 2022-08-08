using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Services;
namespace MISA.Fresher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        [HttpGet]
        public IActionResult getAll([FromQuery] int nationID)
        {
            var ser = new CityService();
            return Ok(ser.getAll(nationID));
        }
    }
}

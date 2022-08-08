using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Services;
namespace MISA.Fresher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardController : ControllerBase
    {
        [HttpGet]
        public IActionResult getAll([FromQuery] int districtID)
        {
            var ser = new WardService();
            return Ok(ser.getAll(districtID));
        }
    }
}

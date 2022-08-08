using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Services;
namespace MISA.Fresher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationController : ControllerBase
    {
        [HttpGet]
        public IActionResult getAll()
        {
            var ser = new NationService();
            return Ok(ser.getAll());
        }
    }
}

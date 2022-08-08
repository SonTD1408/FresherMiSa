using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.API.Services;

namespace MISA.Fresher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VocativeController : ControllerBase
    {
        [HttpGet]
        public  IActionResult getAll()
        {
            var vocativeService = new VocativeService();
            return Ok(vocativeService.getAll());
        }
    }
}

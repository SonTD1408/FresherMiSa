using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.API.Services;

namespace MISA.Fresher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceController : ControllerBase
    {
        [HttpGet]
        public IActionResult getAll()
        {
            var sourceService = new SourceService();
            return Ok(sourceService.getAll());
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.API.Services;

namespace MISA.Fresher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        [HttpGet]
        public IActionResult getPosition()
        {
            var positionService = new PositionService();
            return StatusCode(StatusCodes.Status200OK, positionService.getAll());
        }
    }
}

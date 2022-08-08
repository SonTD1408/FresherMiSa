using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.API.Services;

namespace MISA.Fresher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InComeController : ControllerBase
    {
        [HttpGet]
        public IActionResult getAll()
        {
            var incomeService = new InComeService();
            return Ok(incomeService.getAll());
        }
    }
}

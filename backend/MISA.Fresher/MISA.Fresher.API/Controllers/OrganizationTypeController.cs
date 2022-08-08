using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.API.Services;

namespace MISA.Fresher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationTypeController : ControllerBase
    {
        [HttpGet]
        public IActionResult getAll()
        {
            var orService = new OrganizationTypeService();
            return Ok(orService.getAll());
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.API.Services;

namespace MISA.Fresher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public IActionResult getAll()
        {
            var departmentService = new DepartmentService();
            return Ok(departmentService.getAll());
        }
    }
}

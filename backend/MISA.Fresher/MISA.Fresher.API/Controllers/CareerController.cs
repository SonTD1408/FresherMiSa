using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.API.Services;
using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Config;
using MISA.Fresher.API.Entities;

namespace MISA.Fresher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareerController : ControllerBase
    {
        /// <summary>
        /// api lấy tất cả dữ liệu careers
        /// createdby SONTD(11.08.2022)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var careerService = new CareerService();
                return Ok(careerService.get());
            }
            catch (Exception)
            {
                var ex = new ActionResults<Careers>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._CONTROLLER_EXCEPTION_MSG
                };
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.API.Services;
using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Config;

namespace MISA.Fresher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationController : ControllerBase
    {
        /// <summary>
        /// api lấy dữ liệu từ bảng Nations
        /// createdby SONTD (10.08.2022)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult getAll()
        {

            try
            {
                var service = new NationService();
                return Ok(service.getAll());
            }
            catch (Exception)
            {
                var tmp = new ActionResults<object>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._CONTROLLER_EXCEPTION_MSG,
                };
                return StatusCode(StatusCodes.Status400BadRequest, tmp);
            }
        }
    }
}

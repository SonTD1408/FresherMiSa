using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.API.Services;
using MISA.Fresher.API.Config;
using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Entities;

namespace MISA.Fresher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        /// <summary>
        /// api lấy tất cả dữ liệu chức vụ
        /// createdby SONTD(10.08.2022)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult getPosition()
        {
            try
            {
                var positionService = new PositionService();
                return Ok(positionService.getAll());
            }
            catch (Exception)
            {
                var ex = new ActionResults<Positions>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._CONTROLLER_EXCEPTION_MSG
                };
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Services;
using MISA.Fresher.API.Config;
using MISA.Fresher.API.ActionResult;
namespace MISA.Fresher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        /// <summary>
        /// api lấy dữ liệu từ bảng Cities
        /// createdby SONTD (19.08.2022)
        /// </summary>
        /// <param name="nationID"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult getAll([FromQuery] Guid nationID)
        {
            try
            {
                var ser = new CityService();
                return Ok(ser.getAll(nationID));
            }
            catch (Exception)
            {
                var tmp = new ActionResults<Cities>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._CONTROLLER_EXCEPTION_MSG,
                };
                return StatusCode(StatusCodes.Status400BadRequest, tmp);
            }
        }
    }
}

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
    public class DistrictController : ControllerBase
    {
        /// <summary>
        /// api lấy dữ liệu từ bảng Districts
        /// createdby SONTD (19.08.2022)
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult getAll([FromQuery] Guid cityID)
        {
            try
            {
                var ser = new DistrictService();
                return Ok(ser.getAll(cityID));
            }
            catch (Exception)
            {
                var tmp = new ActionResults<Districts>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._CONTROLLER_EXCEPTION_MSG,
                };
                return StatusCode(StatusCodes.Status400BadRequest, tmp);
            }

        }
    }
}

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
    public class WardController : ControllerBase
    {
        /// <summary>
        /// api lấy dữ liệu từ bảng Wards
        /// createdby SONTD (19.08.2022)
        /// </summary>
        /// <param name="districtID"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult getAll([FromQuery] Guid districtID)
        {
            try
            {
                var ser = new WardService();
                return Ok(ser.getAll(districtID));
            }
            catch (Exception)
            {
                var tmp = new ActionResults<Wards>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._CONTROLLER_EXCEPTION_MSG,
                };
                return StatusCode(StatusCodes.Status400BadRequest, tmp);
            }
        }
    }
}

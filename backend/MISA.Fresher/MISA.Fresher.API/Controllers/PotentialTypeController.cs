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
    public class PotentialTypeController : ControllerBase
    {
        /// <summary>
        /// api lấy tất cả dữ liệu PotentialTypes
        /// createdby SONTD(11.08.2022)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var potentialTypeService = new PotentialTypeService();
                return Ok(potentialTypeService.get());
            }
            catch (Exception)
            {
                var ex = new ActionResults<PotentialTypes>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._CONTROLLER_EXCEPTION_MSG
                };
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
    }
}

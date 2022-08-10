using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.API.Services;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Config;

namespace MISA.Fresher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VocativeController : ControllerBase
    {
        /// <summary>
        /// api lấy tất cả dữ liệu Vocatives
        /// createdby SONTD(10.08.2022)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public  IActionResult getAll()
        {
            try
            {
                var vocativeService = new VocativeService();
                return Ok(vocativeService.getAll());
            }
            catch (Exception)
            {
                var ex = new ActionResults<Vocatives>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._CONTROLLER_EXCEPTION_MSG,
                };
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
    }
}

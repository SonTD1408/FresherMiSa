using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.API.Services;
using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Config;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Entities.DTO;

namespace MISA.Fresher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PotentialController : ControllerBase
    {
        /// <summary>
        /// hàm lấy tất cả potential
        /// </summary>
        /// <param name="pageSize"></param> số lượng potential trên 1 trang
        /// <param name="pageNumber"></param>trang số mây
        /// <param name="where"></param> lọc
        /// <param name="sort"></param> sắp xếp
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllPotentials([FromQuery] string? sort,
                                            [FromQuery] string? where,
                                            [FromQuery] int pageSize = 50,
                                            [FromQuery] int pageNumber = 1)
        {
            try
            {
                var potentialService = new PotentialService();

                return StatusCode(StatusCodes.Status200OK, potentialService.GetAll(pageSize, pageNumber, where, sort));
            }
            catch (Exception e)
            {
                var ex = new ActionResults<Paging>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._CONTROLLER_EXCEPTION_MSG,
                };
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

        /// <summary>
        /// controller thêm 1 tiềm năng
        /// created by SONTD (11.08.2022)
        /// </summary>
        /// <param name="addPotentialDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] AddPotentialDTO addPotentialDTO)
        {
            try
            {
                //lưu vào bảng potential 
                var potentialService = new PotentialService();
                var res = potentialService.Add(addPotentialDTO.Potential);

                return StatusCode(StatusCodes.Status201Created, res);
            }
            catch (Exception e)
            {
                var ex = new ActionResults<Guid>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._CONTROLLER_EXCEPTION_MSG,
                };
                return StatusCode(StatusCodes.Status201Created, ex);

            }
        }

        /// <summary>
        /// controller xóa 1 tiềm năng
        /// created by SONTD (11.08.2022)
        /// </summary>
        /// <param name="potentialID"></param>
        /// <returns></returns>
        [HttpPost("multiDelete")]
        public IActionResult Delete([FromBody] GetListIDDTO potentialIDList)
        {
            try
            {
                var service = new PotentialService();
                var result = service.Delete(potentialIDList);
                return Ok(result);
            }
            catch (Exception)
            {
                var ex = new ActionResults<Guid>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._CONTROLLER_EXCEPTION_MSG,
                };
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

        /// <summary>
        /// hàm lấy ra 1 bản ghi theo id
        /// created by SONTD(14.08.2022)
        /// </summary>
        /// <param name="potentialID"></param>
        /// <returns></returns>
        [HttpGet("{potentialID}")]
        public IActionResult GetById([FromRoute] Guid potentialID)
        {
            try
            {
                var service = new PotentialService();
                return Ok(service.GetById(potentialID));    
            }
            catch (Exception)
            {
                var ex = new ActionResults<PotentialDTO>()
                {
                    Status =0,
                    StatusMsg = ResultMessage._CONTROLLER_EXCEPTION_MSG,
                };
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

        /// <summary>
        /// hàm update 1 potential theo id
        /// created by SONTD(14.08.2022)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="potential"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdatePotentialDTO potential)
        {
            try
            {
                var service = new PotentialService();
                var res = service.Update(id, potential);
                return Ok(res);
            }
            catch (Exception)
            {
                var ex = new ActionResults<Guid>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._CONTROLLER_EXCEPTION_MSG,
                };
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

        /// <summary>
        /// hàm update nhiều tiềm năng
        /// created by SONTD(15.08.2022)
        /// </summary>
        /// <param name="multiUpdatePotentialDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult MultiUpdate([FromBody] MultiUpdatePotentialDTO multiUpdatePotentialDTO)
        {
            try
            {
                var service = new PotentialService();
                return Ok(service.MultiUpdate(multiUpdatePotentialDTO));
            }
            catch (Exception)
            {
                var ex = new ActionResults<Guid>()
                {
                    Status = 0,
                    StatusMsg = ResultMessage._CONTROLLER_EXCEPTION_MSG,
                };
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

        /// <summary>
        /// hàm lấy new code = code lớn nhất + 1
        /// </summary>
        /// <returns></returns>
        [HttpGet("NewCode")]        
        public IActionResult NewCode()
        {
            try
            {
                var service = new PotentialService();
                var res = service.NewCode();
                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (Exception e)
            {
                var res = new ActionResults<string>()
                {
                    Status = 0,
                    StatusMsg = e.ToString(),
                };
                return StatusCode(StatusCodes.Status400BadRequest, res);
            }
        }

        //[HttpGet("Duplication")]
        //public IActionResult Duplicate(string columnName , string columnValue)
        //{
        //    try
        //    {
        //        var service = new PotentialService();
        //        return Ok(service.Duplicate(columnName, columnValue));
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, e);
        //    }
        //}
    }
}

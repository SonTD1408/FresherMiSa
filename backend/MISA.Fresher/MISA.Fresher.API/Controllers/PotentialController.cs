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

                return StatusCode(StatusCodes.Status200OK, potentialService.getAll(pageSize, pageNumber, where, sort));
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
        public IActionResult add([FromBody] AddPotentialDTO addPotentialDTO)
        {
            try
            {
                //lưu vào bảng potential 
                var potentialService = new PotentialService();
                var res1 = potentialService.add(addPotentialDTO.Potential);

                if (res1.Status != 0)
                {
                    //lưu ngành nghề vào bảng careerSaves
                    var careerSaveData = addPotentialDTO.Career; 
                    if (careerSaveData != null)
                    {
                        var careerSaveService = new CareerSaveService();
                        foreach(var item in careerSaveData)
                        {
                            var res2 = careerSaveService.add(item.ID, res1.Data);
                        }
                    }

                    //lưu lĩnh vực vào bảng FieldSaves
                    var fieldSaveData = addPotentialDTO.Field;
                    if (fieldSaveData != null)
                    {
                        var fieldSaveService = new FieldSaveService();
                        foreach (var item in fieldSaveData)
                        {
                            var res3 = fieldSaveService.add(item.ID, res1.Data);
                        }
                    }

                    //lưu ngành nghề vào bảng careerSaves
                    var potentialTypeSaveData = addPotentialDTO.PotentialType;
                    if(potentialTypeSaveData != null)
                    {
                        var potentialTypeSaveService = new PotentialTypeSaveService();
                        foreach (var item in potentialTypeSaveData)
                        {
                            var res2 = potentialTypeSaveService.add(item.ID, res1.Data);
                        }
                    }
                }

                return StatusCode(StatusCodes.Status201Created, res1);
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
        public IActionResult delete([FromBody] GetListIDDTO potentialIDList)
        {
            try
            {
                var service = new PotentialService();
                var result = service.delete(potentialIDList);
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
        public IActionResult getById([FromRoute] Guid potentialID)
        {
            try
            {
                var service = new PotentialService();
                return Ok(service.getById(potentialID));    
            }
            catch (Exception)
            {
                var ex = new ActionResults<Potentials>()
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
        public IActionResult update([FromRoute] Guid id, [FromBody] UpdatePotentialDTO potential)
        {
            var service = new PotentialService();
            var res = service.update(id, potential);
            return Ok(res);
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.API.Services;

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

                return StatusCode(StatusCodes.Status200OK, potentialService.getAll(pageSize,pageNumber, where, sort));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status200OK,"e001");
            }
        }
        
        
    }
}
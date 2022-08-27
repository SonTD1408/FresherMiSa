using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.API.Services;
using MISA.Fresher.API.ActionResult;
using MISA.Fresher.API.Config;
using MISA.Fresher.API.Entities;
using MISA.Fresher.API.Entities.DTO;
using ClosedXML.Excel;

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
        [HttpPost("filter")]
        public IActionResult GetAllPotentials([FromQuery] string? sort,
                                            [FromQuery] string? filter,
                                            [FromQuery] int pageSize = 50,
                                            [FromQuery] int pageNumber = 1)
        {
            try
            {
                var potentialService = new PotentialService();

                return StatusCode(StatusCodes.Status200OK, potentialService.GetAll(pageSize, pageNumber, filter, sort));
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
                return Ok(res);
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


        [HttpPost("ExportToExcel")]
        public IActionResult ExportToExcel( [FromBody]  Guid[]? potentialIDList,
                                            [FromQuery] string? filter,
                                            [FromQuery] int pageSize = -1,
                                            [FromQuery] int pageNumber = 1)
        {
            try
            {
                var service = new PotentialService();
                var res = service.ExportToExcel(potentialIDList, filter, pageSize, pageNumber);
                if (res.Data.PotentialList.Count() >0)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Potential");
                        var currentRow = 1;

                        #region Header
                        worksheet.Cell(currentRow, 1).Value = "Mã tiềm năng";
                        worksheet.Cell(currentRow, 2).Value = "Họ và tên";
                        worksheet.Cell(currentRow, 3).Value = "Xưng hô";
                        worksheet.Cell(currentRow, 4).Value = "Phòng ban";
                        worksheet.Cell(currentRow, 5).Value = "Chức vụ";
                        worksheet.Cell(currentRow, 6).Value = "SDT cá nhân";
                        worksheet.Cell(currentRow, 7).Value = "SDT cơ quan";
                        worksheet.Cell(currentRow, 8).Value = "Email cá nhân";
                        worksheet.Cell(currentRow, 9).Value = "Email cơ quan";
                        worksheet.Cell(currentRow, 10).Value = "Tổ chức";
                        worksheet.Cell(currentRow, 11).Value = "Địa chỉ";
                        worksheet.Cell(currentRow, 12).Value = "Tỉnh/Thành phố";
                        worksheet.Cell(currentRow, 13).Value = "Quận/Huyện";
                        worksheet.Cell(currentRow, 14).Value = "Phường/Xã";
                        worksheet.Cell(currentRow, 15).Value = "Nguồn gốc";
                        worksheet.Cell(currentRow, 16).Value = "Loại hình";
                        worksheet.Cell(currentRow, 17).Value = "Mô tả";
                        worksheet.Cell(currentRow, 18).Value = "Doanh thu";
                        worksheet.Cell(currentRow, 19).Value = "Facebook";
                        #endregion

                        #region Body
                        foreach (var potential in res.Data.PotentialList)
                        {
                            currentRow++;
                            worksheet.Cell(currentRow, 1).Value = potential.PotentialCode;
                            worksheet.Cell(currentRow, 2).Value = potential.FullName;
                            worksheet.Cell(currentRow, 3).Value = potential.VocativeName;
                            worksheet.Cell(currentRow, 4).Value = potential.DepartmentName;
                            worksheet.Cell(currentRow, 5).Value = potential.PositionName;
                            worksheet.Cell(currentRow, 6).Value = potential.PhoneNumber;
                            worksheet.Cell(currentRow, 7).Value = potential.OfficePhoneNumber;
                            worksheet.Cell(currentRow, 8).Value = potential.Email;
                            worksheet.Cell(currentRow, 9).Value = potential.OfficeEmail;
                            worksheet.Cell(currentRow, 10).Value = potential.Organization;
                            worksheet.Cell(currentRow, 11).Value = potential.Address;
                            worksheet.Cell(currentRow, 12).Value = potential.CityName;
                            worksheet.Cell(currentRow, 13).Value = potential.DistrictName;
                            worksheet.Cell(currentRow, 14).Value = potential.WardName;
                            worksheet.Cell(currentRow, 15).Value = potential.SourceName;
                            worksheet.Cell(currentRow, 16).Value = potential.OrganizationTypeName;
                            worksheet.Cell(currentRow, 17).Value = potential.PotentialDescription;
                            worksheet.Cell(currentRow, 18).Value = potential.TurnoverName;
                            worksheet.Cell(currentRow, 19).Value = potential.Facebook;
                        }
                        #endregion

                        using (var stream = new MemoryStream())
                        {
                            workbook.SaveAs(stream);
                            var content = stream.ToArray();

                            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Potentials.xlsx");
                        }
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e);
            }
        }
    }
}

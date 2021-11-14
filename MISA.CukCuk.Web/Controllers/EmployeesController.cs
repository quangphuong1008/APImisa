using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.Controllers
{
    /// <summary>
    /// API nhân viên
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BaseEntitiesController<Employee>
    {
        #region Declare
        /// <summary>
        /// Service nhân viên thực hiện việc xử lý các nghiệp vụ cần có của nhân viên
        /// </summary>
        IEmployeeService _employeeService;
        #endregion
        #region Constructor
        public EmployeesController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion

        #region Method

        /// <summary>
        /// Phương thức lấy ra danh sách nhân viên
        /// </summary>
        /// <returns>Trả về danh sách nhân viên</returns>
        ///  CreatedBy : DDHung(8/11/2021)
        public override IActionResult Get()
        {
            var employees = _employeeService.GetEmployees();
            return Ok(employees);
        }

        /// <summary>
        /// Lấy dữ liệu danh sách nhân viên theo các tiêu chí
        /// </summary>
        /// <param name="specs">Theo mã hoặc tên nhân viên</param>
        /// <param name="departmentId">Id của phòng ban</param>
        /// <param name="positionId">Id của vị trí</param>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy : DDHung(8/11/2021)
        [HttpGet("filter")]
        public IActionResult GetEmployeesFilter([FromQuery] string specs , [FromQuery] Guid? departmentId ,[FromQuery] Guid? positionId)
        {
            return Ok(_employeeService.GetEmployeesFilter(specs, departmentId, positionId));
        }

        /// <summary>
        /// Lấy danh sách nhân viên của trang (page) hiện tại
        /// </summary>
        /// <param name="currentPage">Trang hiện tại</param>
        /// <param name="pageSize">Số lượng record trên 1 trang</param>
        /// <returns>Danh sách nhân viên của trang hiện tại</returns>
        [HttpGet("paging")]
        public IActionResult GetEmployeeInCurrentPage(int currentPage , int pageSize)
        {
            return Ok(_employeeService.GetEmployeeInCurrentPage(currentPage, pageSize));
        }

        #endregion
    }
}

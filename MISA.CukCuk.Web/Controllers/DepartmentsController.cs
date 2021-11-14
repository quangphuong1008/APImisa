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
    /// API Phòng ban
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseEntitiesController<Department>
    {
        IDepartmentService _departmentService;
        public DepartmentsController(IDepartmentService departmentService) : base(departmentService)
        {
            _departmentService = departmentService;
        }
    }
}

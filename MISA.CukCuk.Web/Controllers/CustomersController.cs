using Microsoft.AspNetCore.Mvc;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using MISA.ApplicationCore;
using MISA.ApplicationCore.Interface;
using MISA.ApplicationCore.Entity;

namespace MISA.CukCuk.Web.Controllers
{
    /// <summary>
    /// API danh mục khách hàng
    /// CreatedBy : DDHung (3/11/2021)
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : BaseEntitiesController<Customer>
    {
        ICustomerService _customerService;
        public CustomersController(ICustomerService customerService) : base(customerService)
        {
            _customerService = customerService;
        }
    }
}

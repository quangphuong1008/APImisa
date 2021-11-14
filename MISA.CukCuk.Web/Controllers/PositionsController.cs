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
    /// API vị trí công việc
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PositionsController : BaseEntitiesController<Position>
    {
        IPositionService _positionService;
        public PositionsController(IPositionService positionService):base(positionService)
        {
            _positionService = positionService;
        }
    }
}

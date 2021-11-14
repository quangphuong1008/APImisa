using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.Controllers
{
    /// <summary>
    /// API lớp Base dùng chung
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>

    [Route("api/[controller]")]
    [ApiController]
    public class BaseEntitiesController<TEntity> : ControllerBase
    {
        IBaseService<TEntity> _baseService;
        public BaseEntitiesController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            var entities = _baseService.GetEntities();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var entity = _baseService.GetEntityById(id);
            return Ok(entity);
        }

        [HttpPost]
        public IActionResult Post(TEntity entity)
        {
            var serviceResult = _baseService.AddEntity(entity);
            if(serviceResult.MisaCode == MisaEnum.NotValid)
            {
                return BadRequest(serviceResult);
            }    
            return StatusCode(201 , serviceResult);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var rowAffects = _baseService.DeleteEntity(id);
            return Ok(rowAffects);
        }

        [HttpPut("{id}")]
        public IActionResult Put( [FromRoute]string id , [FromBody]TEntity entity)
        {
            var keyProperty = entity.GetType().GetProperty($"{typeof(TEntity).Name}Id");
            if(keyProperty.PropertyType == typeof(Guid))
            {
                keyProperty.SetValue(entity, Guid.Parse(id));
            }
            else if(keyProperty.PropertyType == typeof(int))
            {
                keyProperty.SetValue(entity, int.Parse(id));
            }
            else
            {
                keyProperty.SetValue(entity, id);
            }
            var serviceResult = _baseService.UpdateEntity(entity);
            if (serviceResult.MisaCode == MisaEnum.NotValid)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

    }
}

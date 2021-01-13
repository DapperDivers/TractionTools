using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TractionTools.Models;
using TractionTools.Repository.Interfaces;

namespace TractionTools.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TRepository> : ControllerBase
    where TEntity : class, BaseModel

    where TRepository : IBaseRepository<TEntity>
    {        
        private readonly TRepository repository;        

        public BaseController(TRepository repository)
        {
            this.repository = repository;
        }


        // GET: api/[controller]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await repository.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var genericObj = await repository.Get(id);
            if (genericObj == null)
            {
                return NotFound();
            }
            return genericObj;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity genericObj)
        {
            if (id != genericObj.Id)
            {
                return BadRequest();
            }
            await repository.Update(genericObj);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity genericObj)
        {
            await repository.Add(genericObj);
            return CreatedAtAction("Get", new { id = genericObj.Id }, genericObj);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var genericObj = await repository.Delete(id);
            if (genericObj == null)
            {
                return NotFound();
            }
            return genericObj;
        }
    }
}





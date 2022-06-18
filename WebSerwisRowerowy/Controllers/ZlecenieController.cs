using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSerwisRowerowy.Models;
using WebSerwisRowerowy.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebSerwisRowerowy.Controllers
{
    [Route("api/zlecenie")]
    [ApiController]
    [Authorize]
    public class ZlecenieController : ControllerBase
    {
        private readonly IZlecenieService _zlecenieService;

        public ZlecenieController(IZlecenieService zlecenieService)
        {
            _zlecenieService = zlecenieService;
        }


        // GET: api/zlecenie
        [HttpGet]
        public ActionResult<IEnumerable<ZlecenieModel>> GetAll()
        {
            var zlecenia = _zlecenieService.GetAll();
            return Ok(zlecenia);
        }

        // GET api/<ZlecenieController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<ZlecenieModel> Get([FromRoute]int id)
        {
            var zlecenia = _zlecenieService.GetById(id);
            return Ok(zlecenia);
        }

        // POST api/<ZlecenieController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateZlecenie([FromBody] ZlecenieModel zlecenieModel)
        {
            
            var id = _zlecenieService.Create(zlecenieModel);
            return Created($"/api/zlecenia/{id}", null);
        }

        // PUT api/<ZlecenieController>/5
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute]int id, [FromBody] ZlecenieModel zlecenieModel)
        {
            _zlecenieService.Update(id, zlecenieModel);
            return Ok();

        }

        // DELETE api/<ZlecenieController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute]int id)
        {
            _zlecenieService.Delete(id);
            return NoContent();
        }
    }
}

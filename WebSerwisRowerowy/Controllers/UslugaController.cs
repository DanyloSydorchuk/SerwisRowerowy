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
    [Route("api/usluga")]
    [ApiController]
    [Authorize]
    public class UslugaController : ControllerBase
    {
        private readonly IUslugaService _uslugaService;

        public UslugaController(IUslugaService uslugaService)
        {
            _uslugaService = uslugaService;
        }

        // GET: api/<UslugaController>
        [HttpGet]
        public ActionResult<IEnumerable<UslugaModel>> GetAll()
        {
            var uslugi = _uslugaService.GetAll();
            return Ok(uslugi);
        }

        // GET api/<UslugaController>/5
        [HttpGet("{id}")]
        public ActionResult<UslugaModel> Get([FromRoute]int id)
        {
            var uslugi = _uslugaService.GetById(id);
            return Ok(uslugi);
        }

        // POST api/<UslugaController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateUsluga([FromBody] UslugaModel uslugaModel)
        {
            var id = _uslugaService.Create(uslugaModel);
            return Created($"/api/usluga/{id}", null);
        }

        // PUT api/<UslugaController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Update([FromRoute]int id, [FromBody] UslugaModel uslugaModel)
        {
            _uslugaService.Update(id, uslugaModel);
            return Ok();
        }

        // DELETE api/<UslugaController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute]int id)
        {
            _uslugaService.Delete(id);
            return NoContent();
        }
    }
}

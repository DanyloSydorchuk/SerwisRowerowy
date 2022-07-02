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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class KlientController : ControllerBase
    {
        private readonly IKlientService _klientService;

        public KlientController(IKlientService klientService)
        {
            _klientService = klientService;
        }

        // GET: api/<KlientController>
        [HttpGet]
        public ActionResult<IEnumerable<KlientModel>> GetAll()
        {
            var klienci = _klientService.GetAll();
            return Ok(klienci);
        }

        // GET api/<KlientController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<KlientModel> Get([FromRoute]int id)
        {
            var klienci = _klientService.GetById(id);
            return Ok(klienci);
        }

        // POST api/<KlientController>
        [HttpPost]
        public ActionResult CreateKlient([FromBody] KlientModel klientModel)
        {
            var id = _klientService.Create(klientModel);
            return Created($"/api/usluga/{id}", null);
        }

        // PUT api/<KlientController>/5
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute]int id, [FromBody] KlientModel klientModel)
        {
            _klientService.Update(id, klientModel);
            return Ok();
        }

        // DELETE api/<KlientController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute]int id)
        {
            _klientService.Delete(id);
            return NoContent();
        }
    }
}

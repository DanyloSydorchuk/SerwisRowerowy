using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSerwisRowerowy.Models;
using WebSerwisRowerowy.Services;

namespace WebSerwisRowerowy.Controllers
{
    [Route("api/pracownik")]
    [ApiController]
    [Authorize(Roles= "Admin")]
    public class PracownikController : ControllerBase
    {
        private readonly IPracownikService _pracownikService;

        public PracownikController(IPracownikService pracownikService)
        {
            _pracownikService = pracownikService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PracownikModel>> GetAll()
        {
            var pracownicy = _pracownikService.GetAll();
            return Ok(pracownicy);
        }

        [HttpGet("{id}")]
        public ActionResult<PracownikModel> Get([FromRoute] int id)
        {
            var pracownik = _pracownikService.GetById(id);
            return Ok(pracownik);
        }

        [HttpPost]
        public ActionResult CreatePracownik([FromBody] PracownikModel pracownikModel)
        {

            var id = _pracownikService.Create(pracownikModel);
            return Created($"/api/zlecenia/{id}", null);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] PracownikModel pracownikModel)
        {
            _pracownikService.Update(id, pracownikModel);
            return Ok();

        }


        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _pracownikService.Delete(id);
            return NoContent();
        }
    }
}

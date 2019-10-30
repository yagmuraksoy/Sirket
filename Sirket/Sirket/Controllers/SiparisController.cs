using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sirket.Models;
using Sirket.Services;

namespace Sirket.Controllers
{
    [Route("[controller]")]
    public class SiparisController : Controller
    {
        private readonly ISiparisRepository _sR;

       public SiparisController(ISiparisRepository sR)
        {
            _sR = sR;
        }
        
        [HttpGet]
        public IEnumerable<Siparis> Get()
        {
            return _sR.GetAll();
        }
        
        [HttpGet("{id}", Name = "GetSiparis")]
        public IActionResult Get(int id)
        {
            var s = _sR.GetById(id);
            if (s == null)
            {
                return NotFound();
            }

            return Ok(s);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]Siparis value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            var createdSiparis = _sR.Add(value);

            return CreatedAtRoute("GetProductOrder", new { id = createdSiparis.Id }, createdSiparis);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Siparis value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            
            var note = _sR.GetById(id);


            if (note == null)
            {
                return NotFound();
            }

            value.Id = id;
            _sR.Update(value);


            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var s = _sR.GetById(id);
            if (s == null)
            {
                return NotFound();
            }
            _sR.Delete(s);
            
            return NoContent();
        }
    }
}
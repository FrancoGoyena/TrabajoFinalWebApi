using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using SWProvincias_Goyena.Data;
using SWProvincias_Goyena.Models;

namespace SWProvincias_Goyena.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        private readonly DBProvinciasContext context;

        public ProvinciaController(DBProvinciasContext context)
        {
            this.context = context;
        }

        //GET: api/provincia
        [HttpGet]
        public ActionResult<IEnumerable<Provincia>> Get()
        {
            return context.Provincias.ToList();
        }

        //POST api/provincia
        [HttpPost]
        public ActionResult Post(Provincia provincia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Provincias.Add(provincia);
            context.SaveChanges();
            return Ok();
        }

        //PUT api/provincia/2
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Provincia provincia)
        {
            if (id != provincia.IdProvincia)
            {
                return BadRequest();
            }
            context.Entry(provincia).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
        //DELETE api/provincia/1
        [HttpDelete("{id}")]
        public ActionResult<Provincia> Delete(int id)
        {
            var provincia = (from a in context.Provincias
                         where a.IdProvincia == id
                         select a).SingleOrDefault();
            if (provincia == null)
            {
                return NotFound();
            }
            context.Provincias.Remove(provincia);
            context.SaveChanges();
            return provincia;
        }

    }
}

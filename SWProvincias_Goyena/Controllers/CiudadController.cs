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
    public class CiudadController : ControllerBase
    {
        private readonly DBProvinciasContext context;

        public CiudadController(DBProvinciasContext context)
        {
            this.context = context;
        }

        //GET: api/ciudad
        [HttpGet]
        public ActionResult<IEnumerable<Ciudad>> Get()
        {
            return context.Ciudades.ToList();
        }

        //POST api/ciudad
        [HttpPost]
        public ActionResult Post(Ciudad ciudad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Ciudades.Add(ciudad);
            context.SaveChanges();
            return Ok();
        }

        //PUT api/ciudad/2
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ciudad ciudad)
        {
            if (id != ciudad.IdCiudad)
            {
                return BadRequest();
            }
            context.Entry(ciudad).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
        //DELETE api/ciudad/1
        [HttpDelete("{id}")]
        public ActionResult<Ciudad> Delete(int id)
        {
            var ciudad = (from a in context.Ciudades
                             where a.IdCiudad == id
                             select a).SingleOrDefault();
            if (ciudad == null)
            {
                return NotFound();
            }
            context.Ciudades.Remove(ciudad);
            context.SaveChanges();
            return ciudad;
        }
    }
}

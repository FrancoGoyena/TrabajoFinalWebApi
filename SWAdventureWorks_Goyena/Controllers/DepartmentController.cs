using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using SWAdventureWorks_Goyena.Models;

namespace SWAdventureWorks_Goyena.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AdventureWorks2019Context context;
        public DepartmentController(AdventureWorks2019Context context)
        {
            this.context = context;
        }


        //GET: api/department
        [HttpGet]
        public ActionResult<IEnumerable<Department>> Get()
        {
            
            return context.Departments.ToList();
        }

        //GET api/department/5
        [HttpGet("{id}")]
        public ActionResult<Department> GetById(int id)
        {
            Department department = (from a in context.Departments
                                where a.DepartmentId == id
                           select a).SingleOrDefault();
            return department;
        }

        //GET api/name/nombre
        [HttpGet("name/{nombre}")]
        public ActionResult<Department> GetByName(string nombre)
        {
            Department department = (from a in context.Departments
                                     where a.Name == nombre
                                     select a).SingleOrDefault();
            return department;
        }

        //POST api/department
        [HttpPost]
        public ActionResult Post(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Departments.Add(department);
            context.SaveChanges();
            return Ok();
        }

        //PUT api/department/2
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Department department)
        {
            if (id != department.DepartmentId)
            {
                return BadRequest();
            }
            context.Entry(department).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
        //DELETE api/department/1
        [HttpDelete("{id}")]
        public ActionResult<Department> Delete(int id)
        {
            var department = (from a in context.Departments
                         where a.DepartmentId == id
                         select a).SingleOrDefault();
            if (department == null)
            {
                return NotFound();
            }
            context.Departments.Remove(department);
            context.SaveChanges();
            return department;
        }
    }
}

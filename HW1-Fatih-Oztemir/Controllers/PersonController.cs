using HW1_Fatih_Oztemir.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HW1_Fatih_Oztemir.Controllers
{
    [Route("api/Person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private static readonly List<Person> Persons = new List<Person>
        {
           new Person
           {
               Id=1,
               Name="Fatih",
               Surname="Öztemir",
               DepartmentId=1,
               BirthDate=DateTime.Now.AddYears(-25)
           },
           new Person
           {
               Id=2,
               Name="Alex",
               Surname="De Souza",
               DepartmentId=2,
               BirthDate=DateTime.Now.AddYears(-46)
           },
           new Person
           {
               Id=3,
               Name="Tuncay ",
               Surname="Şanlı",
               DepartmentId=1,
               BirthDate=DateTime.Now.AddYears(-45)
           },
           new Person
           {
               Id=4,
               Name="Diego",
               Surname="Lugano",
               DepartmentId=1,
               BirthDate=DateTime.Now.AddYears(-49)
           },
           new Person
           {
               Id=5,
               Name="Volkan ",
               Surname="Demirel",
               DepartmentId=1,
               BirthDate=DateTime.Now.AddYears(-40)
           }
        };
        [Route("{id}")]
        [HttpGet]
        public IActionResult Get([FromRoute] int id)
        {
            var person = Persons.FirstOrDefault(p => p.Id == id);
            return Ok(person);
        }
        [HttpGet]
        public IActionResult Get()
        {
            var persons = Persons.ToList();
            return Ok(persons);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            if (ModelState.IsValid)
            {
                Persons.Add(person);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] PersonUpdateDto person)
        {
            var findResult = Persons.Find(p => p.Id == id);
            if (findResult == null)
            {
                return NotFound();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    return Ok(findResult);
                }
                else
                {
                    return StatusCode(400);
                }
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var findResult = Persons.Find(p => p.Id == id);
            if (findResult == null)
            {
                return StatusCode(404);
            }
            Persons.Remove(findResult);
            return StatusCode(200);
        }
        [HttpGet("GetByPersonName")]
        public IActionResult GetByPersonName([FromQuery] string name)
        {
            if (name.Length > 0)
                return Ok(GetDynamicOperation(p => p.Name == name));
            return BadRequest();
        }
        //method
        private List<Person> GetDynamicOperation(Func<Person, bool> filter) 
        {
            return Persons.Where(filter).ToList();
        }
    }
}

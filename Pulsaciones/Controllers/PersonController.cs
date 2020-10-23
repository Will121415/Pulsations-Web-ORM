using System.Reflection.Metadata.Ecma335;
using BLL;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Pulsaciones.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using DAL;

 
namespace Pulsaciones.Controllers
{
    [Route("api/[controller]")]  // api/Persona
    [ApiController]
    public class PersonController: ControllerBase
    {
        private readonly PersonService personService;
        public PersonController(PulsationsContext context)
        {
            personService = new PersonService(context);
        }

        // POST: api/Person
        [HttpPost]
        public ActionResult<PersonViewModel> Save(PersonInputModel personInput)
        {   
            Person person = MapPerson(personInput);
            ServiceResponse  response = personService.Save(person);

            if(response.Error) return BadRequest(response.Message);
            return Ok(response.Person);

        }

        private Person MapPerson(PersonInputModel personInput)
        {
            var person = new Person
            {
                Identification = personInput.Identification,
                Name = personInput.Name,
                Sex = personInput.Sex,
                Age =  personInput.Age
            };
            return person;
        }
        // GET: api/Person
        [HttpGet]
        public ActionResult<IEnumerable<PersonViewModel>> GetList()
        {
            ConsultPersonResponse response = personService.GetList();

            if(response.Error) BadRequest(response.Message);
            var personas  = response.Persons.Select(p => new PersonViewModel(p));

            return Ok(personas);
        }

        [HttpGet("{identification}")]
        public ActionResult<PersonViewModel> SearchById(string identification)
        {
            ServiceResponse response =  personService.SearchById(identification);

            if(response.Person == null) return NotFound("Persona no encontrada!");
            var personViewModel = new PersonViewModel(response.Person);
            return Ok(personViewModel);
        }

        [HttpDelete("{identification}")]
        public ActionResult<PersonViewModel> Delete(string identification)
        {   ServiceResponse response = personService.Delete(identification);
            if(response.Person == null) return BadRequest(response.Message);
            return Ok(response.Person);
        }
        
        [HttpPut]
        public ActionResult<PersonViewModel> Modify(PersonInputModel personInput)
        {
            Person person = MapPerson(personInput);
            ServiceResponse response =  personService.Modidy(person);
            if(response.Error) return BadRequest(response.Message);
            return Ok(response.Person);

        }
    }
}
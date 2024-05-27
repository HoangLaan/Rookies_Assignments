using Asp.NetAPIAssignment02.WebApp.Dto;
using Asp.NetAPIAssignment02.WebApp.Models;
using Asp.NetAPIAssignment02.WebApp.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetAPIAssignment02.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(PersonModel))]
        [ProducesResponseType(400)]
        public List<PersonModel> GetAll() {
            return _personService.GetAllPersons();
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(PersonDto))]
        [ProducesResponseType(400)]
        public IActionResult AddPerson([FromBody] PersonDto personDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (personDto == null)
                return BadRequest();
            _personService.AddPerson(personDto);
            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(PersonModel))]
        [ProducesResponseType(404)]
        public IActionResult UpdatePerson(Guid id, [FromBody] PersonDto personDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_personService.IsExist(id))
                return BadRequest();
            _personService.UpdatePerson(id, personDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeletePerson(Guid id)
        {
            if (!_personService.IsExist(id))
                return BadRequest();
            _personService.DeletePerson(id);
            return Ok();
        }
        [HttpGet("filter")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult FilterPeople([FromQuery] string firstName  = "", [FromQuery] string lastName = "", [FromQuery] GenderType? gender = null, [FromQuery] string birthPlace = "")
        {
            return Ok(_personService.FilterPerson(firstName, lastName, gender, birthPlace));
        }
    }

}

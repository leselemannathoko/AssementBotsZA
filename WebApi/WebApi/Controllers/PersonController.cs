using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonRepository _personRepository;

        public object Datecreated { get; private set; }

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<People>> GetPeople(int id)
        {
            var people = await _personRepository.Get(id);
            if (people == null)
                return NotFound();
            return Ok(people);
                
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<People>>> GetPeople() 
        {
            var people = await _personRepository.GetAll();
            return Ok(people);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePeople(CreatePeopleDto createPeopleDto)
        {
             var people = new People
            {
                Name = createPeopleDto.Name,
                Email = createPeopleDto.Email,
                Surname = createPeopleDto.Surname,
                ProgrammingLanguage = createPeopleDto.ProgrammingLanguage,
                Datecreated = DateTime.Now
            };

            await _personRepository.Add(people);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePeople(int id)
        {
            await _personRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePeople(int id, UpdatePeopleDto updatePeopleDto)
        {
            var people = new People
            {   
                Id = id,
                Name = updatePeopleDto.Name,
                Email = updatePeopleDto.Email,
                Surname = updatePeopleDto.Surname,
                ProgrammingLanguage = updatePeopleDto.ProgrammingLanguage,
            };

          await _personRepository.update(people);
          return Ok();
        }
    }
}

using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IUserService _service;
        public PersonController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public IEnumerable<PersonDto> GetPersonByBuilding(string id)
        {
            return _service.GetPeopleListByBuilding(id);
        }

        [HttpGet]
        public IEnumerable<PersonDto> GetPeopleBySomeInfo(string fullName, int? internalNumber, int? personelCode)
        {
            return _service.GetPeopleListByInputFilter(fullName, internalNumber, personelCode);
        }
        [HttpPut]
        public int UpdatePerson(PersonDto person)
        {
            _service.UpdatePerson(person);
            return person.Id;

        }

        [HttpPost]
        public PersonDto AddPerson(PersonDto person)
        {
            _service.AddPerson(person);
            return person;
        }


        [HttpDelete]
        public void DeletePerson(int id)
        {
            _service.DeletePerson(id);

        }
    }
}

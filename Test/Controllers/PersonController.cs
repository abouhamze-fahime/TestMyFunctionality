using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;
        public PersonController(IPersonService service)
        {
            _service = service;
        }
        [HttpGet]
        public IEnumerable<Person> GetPersonByBuilding(string id)
        {
           return _service.GetPeopleListByBuilding(id);
        }

        [HttpGet]
        public IEnumerable<Person>GetPeopleBySomeInfo(string fullName, int? internalNumber, int? personelCode)
        {
          return  _service.GetPeopleListByInputFilter(fullName, internalNumber, personelCode);
        }
        [HttpPut]
        public int  UpdatePerson(Person person)
        {
            _service.UpdatePerson(person);
            return person.Id;

        }

        [HttpPost]
        public Person AddPerson(Person person)
        {
            _service.AddPerson(person);
            return person;
        }


        [HttpDelete]
        public void DeletePerson(int id )
        {
            _service.DeletePerson(id);

        }
    }
}

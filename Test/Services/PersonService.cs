using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;
using Test.PersonDbcontext;

namespace Test.Services
{
    public class PersonService : IPersonService
    {
        private readonly AppDbContext _context;
        public PersonService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Person> AddPerson(Person person)
        {
           await _context.Person.AddAsync(person);
            return person;
        }

        public void DeletePerson(int personId)
        {
            var person = _context.Person.FirstOrDefault(p => p.Id == personId);
            person.IsDeleted = true;
            _context.Person.Remove(person);
            
        }

        public IEnumerable<Person> GetPeopleListByBuilding(string buildingId)
        {
           return _context.Person.Where(p => p.Building == buildingId && !p.IsDeleted).Select(p => p);
        }

        public IEnumerable<Person> GetPeopleListByInputFilter(string fullName, int? InternalNumber, int? PersonelCode)
        {
            var personlst = _context.Person.Where(p => (p.FullName == fullName || p.InternalNumber == InternalNumber || p.PersonelCode == PersonelCode) && !p.IsDeleted);
            return personlst;
        }

        public  int UpdatePerson(Person person)
        {
            var person1 =  _context.Person.FirstOrDefault(p => p.Id == person.Id && !p.IsDeleted);
            _context.Entry(person1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return person1.Id;
        }
    }
}

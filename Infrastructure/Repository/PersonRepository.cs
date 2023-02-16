using Domain.Models;
using Domain.UserRepository;
using Infrastructure.Test2DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
   public class PersonRepository :IUserRepository
    {
        private readonly TestAppDbContext _context;
        public PersonRepository(TestAppDbContext context)
        {
            _context = context;
        }
        public async Task<User> AddPerson(User person)
        {
            await _context.Users.AddAsync(person);
            return person;
        }

        public void DeletePerson(int personId)
        {
            var person = _context.Users.FirstOrDefault(p => p.Id == personId);
            person.IsDeleted = true;
            _context.Users.Remove(person);

        }

        public IEnumerable<User> GetPeopleListByBuilding(string buildingId)
        {
            return _context.Users.Where(p => p.Building == buildingId && !p.IsDeleted).Select(p => p);
        }

        public IEnumerable<User> GetPeopleListByInputFilter(string fullName, int? InternalNumber, int? PersonelCode)
        {
            var personlst = _context.Users.Where(p => (p.FullName == fullName || p.InternalNumber == InternalNumber || p.PersonelCode == PersonelCode) && !p.IsDeleted);
            return personlst;
        }

        public int UpdatePerson(User person)
        {
            var person1 = _context.Users.FirstOrDefault(p => p.Id == person.Id && !p.IsDeleted);
            _context.Entry(person1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return person1.Id;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

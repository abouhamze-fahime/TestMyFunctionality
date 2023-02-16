using Application.Dto;
using Application.Interface;
using AutoMapper;
using Domain.Models;
using Domain.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
   public class UserService:IUserService
    {
        private readonly IUserRepository _context;
        private readonly IMapper _mapper;
        public UserService(IUserRepository context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PersonDto> AddPerson(PersonDto person)
        {
            var person1 = _mapper.Map<User>(person);
            await _context.AddPerson(person1);
            _context.Save();
            return person;
        }

        public void DeletePerson(int personId)
        {
           
             _context.DeletePerson(personId);
            _context.Save();

        }

        public IEnumerable<PersonDto> GetPeopleListByBuilding(string buildingId)
        {


            var personLst= _context.GetPeopleListByBuilding(buildingId);
          return  _mapper.Map<IEnumerable<PersonDto>>(personLst);

        }

        public IEnumerable<PersonDto> GetPeopleListByInputFilter(string fullName, int? InternalNumber, int? PersonelCode)
        {
            var personlst = _context.GetPeopleListByInputFilter(fullName, InternalNumber, PersonelCode);

            return _mapper.Map<IEnumerable<PersonDto>>(personlst); 
        }

        public int UpdatePerson(PersonDto person)
        {
            var person1 = _mapper.Map<User>(person);
            _context.UpdatePerson(person1);
            _context.Save();
            return person1.Id;
        }
    }
}

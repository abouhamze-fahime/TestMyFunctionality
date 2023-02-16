using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
  public  interface IUserService
    {
        IEnumerable<PersonDto> GetPeopleListByBuilding(string buildingId);
        IEnumerable<PersonDto> GetPeopleListByInputFilter(string fullName, int? InternalNumber, int? PersonelCode);
        Task<PersonDto> AddPerson(PersonDto person);
        int UpdatePerson(PersonDto person);
        void DeletePerson(int personId);
    }
}

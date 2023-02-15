using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Services
{
  public  interface IPersonService
    {
         IEnumerable<Person> GetPeopleListByBuilding(string buildingId);
         IEnumerable<Person> GetPeopleListByInputFilter(string fullName, int? InternalNumber, int? PersonelCode);

         Task<Person> AddPerson(Person person);
         int UpdatePerson(Person person);
         void DeletePerson(int personId);
    }
}

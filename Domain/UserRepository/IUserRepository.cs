using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserRepository
{
    public interface IUserRepository
    {

        IEnumerable<User> GetPeopleListByBuilding(string buildingId);
        IEnumerable<User> GetPeopleListByInputFilter(string fullName, int? InternalNumber, int? PersonelCode);
        Task<User> AddPerson(User person);
        int UpdatePerson(User person);
        void DeletePerson(int personId);
        public void Save();
    }
}

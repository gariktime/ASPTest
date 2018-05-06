using ASPTest.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPTest.DAL.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);

        void Edit(User user);

        void Delete(int id);

        User FindById(int id);

        IQueryable<User> GetUsers();

        void Save();
    }
}

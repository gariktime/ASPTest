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

        User FindById(int id);

        List<User> GetUsers();

        void Save();
    }
}

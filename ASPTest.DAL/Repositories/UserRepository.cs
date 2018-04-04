using ASPTest.DAL.EF;
using ASPTest.DAL.Entities;
using ASPTest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPTest.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserContext userDb = null;

        public UserRepository(UserContext userContext)
        {
            userDb = userContext;
        }

        public void Add(User user)
        {
            userDb.Users.Add(user);
        }

        public User FindById(int id)
        {
            return userDb.Users.Find(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return userDb.Users.AsEnumerable();

        }

        public void Save()
        {
            userDb.SaveChanges();
        }
    }
}

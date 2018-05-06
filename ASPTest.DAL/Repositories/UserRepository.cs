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

        public void Edit(User user)
        {
            userDb.Entry(user).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            User user = userDb.Users.FirstOrDefault(p => p.Id == id);
            if (user != null)
                userDb.Users.Remove(user);
            else
                throw new ArgumentException();
        }

        public User FindById(int id)
        {
            return userDb.Users.FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<User> GetUsers()
        {
            return userDb.Users.AsNoTracking().AsQueryable();
        }

        public void Save()
        {
            userDb.SaveChanges();
        }
    }
}

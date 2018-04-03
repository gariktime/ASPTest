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
        public DepartmentContext depDb = null;

        public UserRepository(UserContext userContext, DepartmentContext departmentContext)
        {
            userDb = userContext;
            depDb = departmentContext;
        }

        public void Add(User user)
        {
            userDb.Users.Add(user);
        }

        public User FindById(int id)
        {
            var user = userDb.Users.Join(depDb.Departments,
                c => c.DepartmentId,
                d => d.Id,
                (c, d) => new User
                {
                    Id = c.Id,
                    UserName = c.UserName,
                    DepartmentId = c.DepartmentId,
                    Department = new Department() { Id = d.Id, Title = d.Title }
                });
            return (User)user;
        }

        public List<User> GetUsers()
        {
            //var users = userDb.Users.Join(depDb.Departments,
            //    c => c.DepartmentId,
            //    d => d.Id,
            //    (c, d) => new User
            //    {
            //        Id = c.Id,
            //        UserName = c.UserName,
            //        DepartmentId = c.DepartmentId,
            //        Department = new Department() { Id = d.Id, Title = d.Title }
            //    }).ToList();
            //return users;

            return userDb.Users.ToList();
        }

        public void Save()
        {
            userDb.SaveChanges();
        }
    }
}
